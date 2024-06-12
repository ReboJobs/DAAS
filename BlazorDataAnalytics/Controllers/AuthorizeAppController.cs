using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Services.BlobStorageService;
using BlazorDataAnalytics.Services.UserReportCardImageService;
using BlazorDataAnalytics.Services.UserThemeSettingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using Blazored.SessionStorage;
using Blazored.LocalStorage;
using Xero.NetStandard.OAuth2.Client;
using Xero.NetStandard.OAuth2.Config;
using BlazorDataAnalytics.Services.UserVaultService;
using Xero.NetStandard.OAuth2.Token;
using Newtonsoft.Json;


namespace BlazorDataAnalytics.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthorizeAppController : Controller
    {
        private readonly ILogger<FileController> _logger;
        private readonly ILocalStorageService _sessionStorageService;
        private readonly IUserVaultService _userVaultService;
        private readonly IConfiguration _config;

        public AuthorizeAppController(ILogger<FileController> logger, ILocalStorageService sessionStorageService, IUserVaultService userVaultService, IConfiguration config)
        {
            _logger = logger;
            _sessionStorageService = sessionStorageService;
            _userVaultService = userVaultService;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> XeroCallback(string code, string state)
        {
            try
            {
                int userVaultId = Convert.ToInt32(state);

                string? baseUrl = $"{Request.Scheme}://{Request.Host.Value.ToString()}{Request.PathBase.Value}";
                string callbackUri = baseUrl + "/api/AuthorizeApp/XeroCallback";
                //var userVaultAppDetails = await _userVaultService.GetUserVaultAppDetails(userVaultId);

                var ClientId = _config.GetSection("Xero:ClientId").Value;
                var ClientSecret = _config.GetSection("Xero:ClientSecret").Value;

                if (ClientId == null)
                {
                    //return BadRequest("User Vault configuration not found.");
                    return Content(CreateDialog("XUser Vault configuration not found."), "text/html");
                }
                XeroConfiguration xconfig = new XeroConfiguration
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret,
                    CallbackUri = new Uri(callbackUri),
                    Scope = "offline_access accounting.transactions openid profile email accounting.contacts accounting.settings files",
                    State = state
                };

                var client = new XeroClient(xconfig);
                XeroOAuth2Token xeroToken = (XeroOAuth2Token)await client.RequestAccessTokenPkceAsync(code, TokenUtilities.GetCodeVerifier());

                var payLoad = JsonConvert.SerializeObject(xeroToken);

                var userVaultAppDetail = new UserVaultAppDetailModel
                {
                    UserVaultId = userVaultId,
                    ClientId = ClientId,
                    ClientSecret = ClientSecret,
                    AccessToken = xeroToken.AccessToken,
                    RefreshToken = xeroToken.RefreshToken,
                    DateTokenExpiredUtc = xeroToken.ExpiresAtUtc,
                    IdToken = xeroToken.IdToken,
                    PayLoadData = payLoad
                };

                await _userVaultService.UpdateUserAppDetailTokenAsync(userVaultAppDetail);

                return Content(CreateDialog("Xero Access Token Verified"), "text/html");
            } catch (Exception ex)
            {
                return Content(CreateDialog(ex.Message), "text/html");
            }

        }


        private string CreateDialog(string messages)
        {
            string htmlDialog =
              "<html lang = 'en'>"
              + "<head>"
              + "<script src = 'https://cdnjs.cloudflare.com/ajax/libs/jquery/3.0.0/jquery.min.js'></script>"
              + "<script src = 'https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.js'></script>"
              + "<link rel ='stylesheet' href = 'https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.css' />"
              + "<script>"
              + "$(document).ready(function() { $('#ex1').modal({ closeExisting: false, fadeDuration: 100, escapeClose: false, clickClose: false, showClose: false }); "
              + "$('#btnClose').click(function() { window.close(); }); });"
              + " </script></head>"
              + $"<body> <div id = 'ex1' class='modal'> <p>{messages}</p> <a id = 'btnClose' href='#' rel='modal:close'>Close</a> </div> </body>"
              + "</html>";


            return htmlDialog; 
        }
    }
}