using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Models.ServicePrincipalModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.PowerBI.Api.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.ServicePrincipalService
{

  public class CustomerTenantManager: ICustomerTenantManager
    {

    private PowerBiServiceApi powerBiServiceApi;
    private AppOwnsDataMultiTenantDbService appOwnsDataMultiTenantDbService;

    public CustomerTenantManager(AppOwnsDataMultiTenantDbService appOwnsDataMultiTenantDbService) {
      this.powerBiServiceApi = powerBiServiceApi;
      this.appOwnsDataMultiTenantDbService = appOwnsDataMultiTenantDbService;
    }

    public IList<AppProfile> GetAppProfiles() {
      return this.appOwnsDataMultiTenantDbService.GetProfiles();
    }

    public AppProfile GetAppProfile(int ProfileId ){
      return this.appOwnsDataMultiTenantDbService.GetProfile(ProfileId);
    }

    public IList<ServicePrincipalProfile> GetPowerBiProfiles() {
      return this.powerBiServiceApi.GetProfiles();
    }

    public void DeleteProfile(AppProfile Profile) {
      this.powerBiServiceApi.DeleteProfile(Profile.ProfileId);
      this.appOwnsDataMultiTenantDbService.DeleteProfile(Profile.Id);
    }

    public string GetNextProfileName() {
      return this.appOwnsDataMultiTenantDbService.GetNextProfileName();
    }

    public AppProfile CreateProfile(string ProfileName, bool Exclusive = false) {

      ServicePrincipalProfile servicePrincipalProfile = this.powerBiServiceApi.CreateProfile(ProfileName);

      AppProfile appProfile = new AppProfile {
        ProfileId = servicePrincipalProfile.Id.ToString(),
        ProfileName = ProfileName,
        Created = DateTime.Now,
        Exclusive = Exclusive
      };

      return this.appOwnsDataMultiTenantDbService.CreateProfile(appProfile);
    }

    public IList<ServicePrincipalTenant> GetTenants() {
      return this.appOwnsDataMultiTenantDbService.GetTenants();
    }

    public CustomerTenantDetails GetTenantDetails(int  id) {
      var tenant = appOwnsDataMultiTenantDbService.GetTenant(id);
      return powerBiServiceApi.GetTenantDetails(tenant);
    }

    public OnboardTenantModel GetOnboardTenantModel() {

      string suggestedTenantName = this.appOwnsDataMultiTenantDbService.GetNextTenantName();
      var profilesInPool = this.appOwnsDataMultiTenantDbService.GetProfilesInPool();

      var model = new OnboardTenantModel {
        TenantName = suggestedTenantName,
        ProfileOptions = profilesInPool.Select(profile => new SelectListItem {
          Text = profile.ProfileName,
          Value = profile.Id.ToString()
        }).ToList(),
        DatabaseOptions = new List<SelectListItem> {
          new SelectListItem{ Text="DataAnalyticsDB", Value="DataAnalyticsDB" }
        },
        SuggestedDatabase = "DataAnalyticsDB"
      };

      return model;

    }

    public void OnboardTenant(string TenantName, string DatabaseServer, string DatabaseName, string DatabaseUserName, string DatabaseUserPassword, string ProfileName, string Exclusive) {

      //if (string.IsNullOrEmpty(ProfileName)) {
      //  ProfileName = TenantName;
      //}

      //var tenant = new ServicePrincipalTenant {
      //  Name = TenantName,
      //  DatabaseServer = DatabaseServer,
      //  DatabaseName = DatabaseName,
      //  DatabaseUserName = DatabaseUserName,
      //  DatabaseUserPassword = DatabaseUserPassword,
      //};

      //if (Exclusive.Equals("True")) {
      //  AppProfile profile = CreateProfile(TenantName, true);
      //  tenant.Profile = profile;
      //}
      //else {
      //  tenant.Profile = GetAppProfile(tenant.ProfileId);
      //}

      //tenant = this.powerBiServiceApi.OnboardNewTenant(tenant.Name, tenant.Profile.ProfileId);
      //tenant.Created = DateTime.Now.AddHours(0); // no time offset for local dev
      //this.appOwnsDataMultiTenantDbService.OnboardNewTenant(tenant);

    }

    public void DeleteTenant(int id) {

      var tenant = this.appOwnsDataMultiTenantDbService.GetTenant(id);
      
      bool exclusiveProfile = tenant.Profile.Exclusive;
      string profileId = tenant.Profile.ProfileId;

      this.powerBiServiceApi.DeleteWorkspace(tenant);
      this.appOwnsDataMultiTenantDbService.DeleteTenant(tenant);

      if(exclusiveProfile) {
        DeleteProfile(tenant.Profile);
      }

    }

    public EmbeddedReportViewModel GetEmbeddedReportViewModel(int id) {
      var tenant = this.appOwnsDataMultiTenantDbService.GetTenant(id);
      return this.powerBiServiceApi.GetReportEmbeddingData(tenant).Result;
    }

        public void UpdateTenant(ServicePrincipalTenant tenant)
        {
            this.appOwnsDataMultiTenantDbService.UpdateTenant(tenant);
        }
    }
}