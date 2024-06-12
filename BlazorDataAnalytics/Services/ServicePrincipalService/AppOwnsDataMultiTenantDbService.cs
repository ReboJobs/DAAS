using System.Collections.Generic;
using System.Linq;
using BlazorDataAnalytics.Models;
using Microsoft.PowerBI.Api.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.ServicePrincipalService
{

  public class AppOwnsDataMultiTenantDbService : IAppOwnsDataMultiTenantDbService{

    // private readonly DataAnalyticsDBContext dbContext;

        public AppOwnsDataMultiTenantDbService(DataAnalyticsDBContext context) {
     // dbContext = context;
    }

    public AppProfile CreateProfile(AppProfile Profile) {
            using (var context = new DataAnalyticsDBContext())
            {
                context.Profiles.Add(Profile);
                context.SaveChanges();
                return Profile;
            }
    }

    public IList<AppProfile> GetProfiles() {

            // get app identity
            using (var context = new DataAnalyticsDBContext())
            {
                var profiles = context.Profiles
                       .Select(Profile => Profile)
                       .OrderBy(Profile => Profile.ProfileName)
                       .ToList();

                // populate Tenants collection
                foreach (var profile in profiles)
                {
                    profile.Tenants =
                      context.ServicePrincipalTenants.Where(tenant => tenant.Profile.ProfileName == profile.ProfileName).ToList();
                }

                return profiles;
            }
    }

    public IList<AppProfile> GetProfilesInPool() {

            // get app identity
            using (var context = new DataAnalyticsDBContext())
            {
                return context.Profiles
                       .Select(Profile => Profile)
                       .Where(Profile => Profile.Exclusive == false)
                       .OrderBy(Profile => Profile.ProfileName)
                       .ToList();
            }
    }

    public AppProfile GetProfile(int id) {
            using (var context = new DataAnalyticsDBContext())
            {
                var profile = context.Profiles.Where(profile => profile.Id == id).First();
                profile.Tenants = context.ServicePrincipalTenants.Where(tenant => tenant.ProfileId == profile.Id).ToList();
                return profile;
            }
    }
        public bool checkExist(string ProfileName)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var profile = context.Profiles.Where(profile => profile.ProfileName == ProfileName).FirstOrDefault();
                return profile != null;
            }
        }
        public AppProfile GetProfileById(string profId)
     {
            using (var context = new DataAnalyticsDBContext())
            {
                var profile = context.Profiles.Where(profile => profile.ProfileId == profId).First();
                profile.Tenants = context.ServicePrincipalTenants.Where(tenant => tenant.ProfileId == profile.Id).ToList();
                return profile;
            }
      }
     public void DeleteProfile(int ProfileId) {
            using (var context = new DataAnalyticsDBContext())
            {
                var servicePrincipalProfile = context.Profiles.Where(profile => profile.Id == ProfileId).First();
                context.Profiles.Remove(servicePrincipalProfile);
                context.SaveChanges();
                return;
            }
    }

    public string GetNextProfileName() {
            using (var context = new DataAnalyticsDBContext())
            {
                var appNames = context.Profiles.Select(servicePrincipalProfile => servicePrincipalProfile.ProfileName).ToList();
                string baseName = "GenericProfile";
                string nextName;
                int counter = 0;
                do
                {
                    counter += 1;
                    nextName = baseName + counter.ToString("00");
                }
                while (appNames.Contains(nextName));
                return nextName;
            }
    }

        public string GetNextTenantName()
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var appNames = context.ServicePrincipalTenants.Select(tenant => tenant.Name).ToList();
                string baseName = "ServicePrincipalTenants";
                string nextName;
                int counter = 0;
                do
                {
                    counter += 1;
                    nextName = baseName + counter.ToString("00");
                }
                while (appNames.Contains(nextName));
                return nextName;
            }
        }


        public AppProfile GetNextProfileInPool() {
      var AppOwnsDataMultiTenant = GetProfiles().Where(servicePrincipalProfile => servicePrincipalProfile.Exclusive == false);
      if (AppOwnsDataMultiTenant.Count() == 0) {
        return null;
      }
      IList<int> counts = AppOwnsDataMultiTenant.Select(servicePrincipalProfile => servicePrincipalProfile.Tenants.Count()).ToList();
      int minCount = counts.Min();
      return AppOwnsDataMultiTenant.Where(servicePrincipalProfile => servicePrincipalProfile.Tenants.Count() == minCount).First();
    }

    public void OnboardNewTenant(ServicePrincipalTenant tenant) {
            using (var context = new DataAnalyticsDBContext())
            {
                context.ServicePrincipalTenants.Add(tenant);
                context.SaveChanges();
            }
    }
    public void UpdateTenant(ServicePrincipalTenant tenant)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var tenantData = context.ServicePrincipalTenants.Where(x => x.Id == tenant.Id).FirstOrDefault();
                tenantData.Name = tenant.Name;
                tenantData.DatabaseUserName = tenant.DatabaseUserName;
                tenantData.DatabaseUserPassword = tenant.DatabaseUserPassword;
                tenantData.DatabaseServer = tenant.DatabaseServer;
                tenantData.ProfileId = tenant.ProfileId;
                context.SaveChanges();
            }
        }

        public IList<ServicePrincipalTenant> GetTenants() {
            using (var context = new DataAnalyticsDBContext())
            {
                return context.ServicePrincipalTenants
             .Select(tenant => tenant).OrderBy(tenant => tenant.Name)
             .OrderBy(tenant => tenant.Name).ToList();
            }
    }

    public ServicePrincipalTenant GetTenant(int id) {
            using (var context = new DataAnalyticsDBContext())
            {
                var tenant = context.ServicePrincipalTenants.Where(tenant => tenant.Id == id).First();
                tenant.Profile = context.Profiles.Where(profile => profile.Id == tenant.ProfileId).First();
                return tenant;
            }
    }

    public Boolean TenantAlreadyExists(string TenantName) {
            using (var context = new DataAnalyticsDBContext())
            {
                var response = context.ServicePrincipalTenants.Where(tenant => tenant.Name == TenantName);
                return (response.Count() > 0);
            }
    }

    public void DeleteTenant(ServicePrincipalTenant tenant) {
            using (var context = new DataAnalyticsDBContext())
            {
                context.ServicePrincipalTenants.Remove(tenant);
                context.SaveChanges();
                return;
            }
    }

        public AppProfile GetProfileById(int id)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var profile = context.Profiles.Where(profile => profile.Id == id).First();
                profile.Tenants = context.ServicePrincipalTenants.Where(tenant => tenant.ProfileId == id).ToList();
                return profile;
            }
        }
    }

}
