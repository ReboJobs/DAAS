
using System.Threading.Tasks;
using BlazorDataAnalytics.Models;
//using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;


namespace BlazorDataAnalytics.Services.UserSecurityService
{

    public interface IUserSecurityService
    {
        Task<bool> GetUserAccessAdminRole(string userName);
        Task<UserNameGroupRolesModel> GetUserNameGroupRoles(string userName);
        Task<bool> CheckUserGroupRole(string userName, string roleCode);
        Task<List<CustomerUserModel>> SearchCustomerUsers(string text, int customerTenantId = 0);
        Task<List<CustomerTenantModel>> GetAllCustomerTenants();
        Task<List<CustomerTenantModel>> GetAllCustomerTenantsByUserName(string userName);
        Task<List<CustomerUserGroupModel>> GetCustomerGroupTenants(int customerTenantId);
        Task<CustomerTenantModel> GetCustomerTenants(int? customerTenantId);
        Task<CustomerUserModel> UpsertCustomerUsers(CustomerUserModel model);
        Task DeleteCustomerUser(int customerUserId);
        Task<List<CustomerUserGroupRoleModel>> GetUseRolesByCustomerTenantId(int customerTenantid, int customerGroupId);
        Task<List<CustomerUserGroupRoleModel>> GetAppliedUserRolesByCustomerCustomerGroupId(int customerGroupId);
        Task AppliedRoleInCustomerUserGroup(int? customerUserGroupId, int? customerUserRoleId);
        Task DeleteRoleInCustomerUserGroup(int? customerUserGroupRolesId);
        Task<CustomerTenantModel> UpsertCustomerTenant(CustomerTenantModel customerTenantModel);
        Task<CustomerUserGroupModel> UpsertCustomerUserGroup(CustomerUserGroupModel customerUserGroupModel);
        Task UpsertCustomerAssignGroup(int customerUserId, List<int?> customerUserGroupIds);
        Task<string> InsertCustomerUserRoleByName(CustomerUserRole customerUserRole);
    }
}
    