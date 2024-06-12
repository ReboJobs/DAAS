using System.Collections.Generic;
using System.Linq;
using BlazorDataAnalytics.Models;
using Microsoft.PowerBI.Api.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.ServicePrincipalService
{

  public interface IAppOwnsDataMultiTenantDbService {



        public AppProfile CreateProfile(AppProfile Profile);

        public IList<AppProfile> GetProfiles();

        public IList<AppProfile> GetProfilesInPool();
        public bool checkExist(string ProfileName);
        public AppProfile GetProfile(int ProfileName);

        public AppProfile GetProfileById(int id);

        public void DeleteProfile(int ProfileId);

        public string GetNextProfileName();

        public string GetNextTenantName();

        public AppProfile GetNextProfileInPool();

        public void OnboardNewTenant(ServicePrincipalTenant tenant);
        public void UpdateTenant(ServicePrincipalTenant tenant);

        public IList<ServicePrincipalTenant> GetTenants();

        public ServicePrincipalTenant GetTenant(int tenantId);

        public Boolean TenantAlreadyExists(string TenantName);
        public void DeleteTenant(ServicePrincipalTenant tenant);

  }

}
