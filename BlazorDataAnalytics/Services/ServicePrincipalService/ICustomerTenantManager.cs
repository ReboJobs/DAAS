using BlazorDataAnalytics.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.PowerBI.Api.Models;
using Persistence.Config.Entities;
using BlazorDataAnalytics.Models.ServicePrincipalModel;

namespace BlazorDataAnalytics.Services.ServicePrincipalService
{

  public interface ICustomerTenantManager
    {


        public IList<AppProfile> GetAppProfiles();

        public AppProfile GetAppProfile(int ProfileName);

        public IList<ServicePrincipalProfile> GetPowerBiProfiles();

        public void DeleteProfile(AppProfile ProfileId);

        public string GetNextProfileName();
        public AppProfile CreateProfile(string ProfileName, bool Exclusive = false);

        public IList<ServicePrincipalTenant> GetTenants();
        public CustomerTenantDetails GetTenantDetails(int id);



        public OnboardTenantModel GetOnboardTenantModel();

        public void OnboardTenant(string TenantName, string DatabaseServer, string DatabaseName, string DatabaseUserName, string DatabaseUserPassword, string ProfileName, string Exclusive);
        public void UpdateTenant(ServicePrincipalTenant tenant);

        public void DeleteTenant(int id );

        public EmbeddedReportViewModel GetEmbeddedReportViewModel(int id);

  }
}