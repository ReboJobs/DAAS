using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Services.UserService;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Persistence.Config.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;

namespace BlazorDataAnalytics.Hubs
{
    public class ChatHub : Hub
    {
        private IUserService _userService;
        private IConfiguration _configuration;

        public ChatHub(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        static Dictionary<string,string> CurrentConnections = new Dictionary<string, string>();
        private static List<User> Users = new List<User>();
        public override async Task OnConnectedAsync()
        {
            var enabledCapacity = _configuration.GetSection("EnableCapacity").Value;
            if (enabledCapacity != "Enabled")
            {
                return;
            }
            if (Context.User.Identity.IsAuthenticated)
            {
                var id = Context.ConnectionId;
                CurrentConnections.Add(id, Context.User.Identity.Name);
                var user = new UserModel { Email = Context.User.Identity.Name, Active = true };
                await _userService.UpsertUserActiveAsync(user);
                //resume capacity
                try
                {
                    string CapacityResource = "https://management.azure.com";
                    string ResumeCapacitiesURL = _configuration.GetSection("CapacityResumeApiUrl").Value;
                    var clientId = _configuration.GetSection("AzureAd:ClientId").Value;
                    var secret = _configuration.GetSection("AzureAd:ClientSecret").Value;
                    var oauthUrl = _configuration.GetSection("AzureAd:Instance").Value + _configuration.GetSection("workSpaceId").Value + "/oauth2/token";
                    var content = new FormUrlEncodedContent(new Dictionary
                                        <string, string> {
                          { "client_id", clientId},
                          { "client_secret", secret},
                          { "grant_type", "client_credentials" },
                          { "resource", CapacityResource},
                          { "scope", "user_impersonation"}
                        });

                    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(oauthUrl))
                    {
                        Content = content
                    };

                    var _httpClient = new HttpClient();
                    using (var response = await _httpClient.SendAsync(httpRequestMessage))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseStream = await response.Content.ReadAsStringAsync();

                            AnalyticsTokenModel analyticsToken = JsonConvert.DeserializeObject<AnalyticsTokenModel>(responseStream);

                            var _httpClient3 = new HttpClient();
                            _httpClient3.DefaultRequestHeaders.Add("Authorization", "Bearer " + analyticsToken.access_token);

                            var httpRequestMessage33 = new HttpRequestMessage(HttpMethod.Post, new Uri(ResumeCapacitiesURL)) { };

                            using (var response3 = await _httpClient3.SendAsync(httpRequestMessage33))
                            {
                                var responseStream33 = await response3.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
                catch (Exception ex) { }

            }
            await base.OnConnectedAsync();
        }

        public override async  Task OnDisconnectedAsync(Exception? exception)
        {
            var enabledCapacity = _configuration.GetSection("EnableCapacity").Value;
            if (enabledCapacity != "Enabled")
            {
                return;
            }
            if (Context.User.Identity.IsAuthenticated)
            {

                foreach (var item in CurrentConnections.Where(kvp => kvp.Key.Equals(Context.ConnectionId)).ToList())
                {
                    CurrentConnections.Remove(item.Key);
                }

                var userExists = (CurrentConnections.Where(kvp => kvp.Value.Equals(Context.User.Identity.Name)).Count() > 0) ? true : false;

                if (!userExists)
                {
                    var user = new UserModel { Email = Context.User.Identity.Name, Active = false };
                    await _userService.UpsertUserActiveAsync(user);

                    bool atLeastOne = await _userService.IsAtLeastOneUserActive();
                    if (!atLeastOne)
                    {
                        //suspend capacity
                        try
                        {
                            string CapacityResource = "https://management.azure.com";
                            string SuspendCapacitiesURL = _configuration.GetSection("CapacitySuspendApiUrl").Value;

                            var clientId = _configuration.GetSection("AzureAd:ClientId").Value;
                            var secret = _configuration.GetSection("AzureAd:ClientSecret").Value;
                            var oauthUrl = _configuration.GetSection("AzureAd:Instance").Value + _configuration.GetSection("workSpaceId").Value + "/oauth2/token";
                            var content = new FormUrlEncodedContent(new Dictionary<string, string> {
                                      { "client_id", clientId},
                                      { "client_secret", secret},
                                      { "grant_type", "client_credentials" },
                                      { "resource", CapacityResource},
                                      { "scope", "user_impersonation"}
                                    });

                            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(oauthUrl))
                            {
                                Content = content
                            };

                            var _httpClient = new HttpClient();
                            using (var response = await _httpClient.SendAsync(httpRequestMessage))
                            {
                                if (response.IsSuccessStatusCode)
                                {
                                    var responseStream = await response.Content.ReadAsStringAsync();

                                    AnalyticsTokenModel analyticsToken = JsonConvert.DeserializeObject<AnalyticsTokenModel>(responseStream);

                                    var _httpClient3 = new HttpClient();
                                    _httpClient3.DefaultRequestHeaders.Add("Authorization", "Bearer " + analyticsToken.access_token);

                                    var httpRequestMessage33 = new HttpRequestMessage(HttpMethod.Post, new Uri(SuspendCapacitiesURL)) { };

                                    using (var response3 = await _httpClient3.SendAsync(httpRequestMessage33))
                                    {
                                        var responseStream33 = await response3.Content.ReadAsStringAsync();
                                    }
                                }
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
