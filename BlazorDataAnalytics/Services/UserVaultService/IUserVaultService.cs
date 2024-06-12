using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.UserVaultService
{
    public interface IUserVaultService
    {
        Task<UserVaultModel> UpsertUserVaultAsync(UserVaultModel model);
        Task<List<UserVaultModel>> SearchUserVault(string text,int? customerTenantId);
        Task DeletetUserVaultAsync(int userVaultId);
        Task<UserVaultAppDetailModel> UpsertUserVaultAppDetailAsync(UserVaultAppDetailModel model);
        Task<UserVaultAppDetailModel> GetUserVaultAppDetails(int? userVaultId);
        Task UpdateUserAppDetailTokenAsync(UserVaultAppDetailModel model);
        List<CommonEnumModel> GetSystems();
        Task<List<UserVaultModel>> SearchUserVault(int? customerTenantId);
        List<string> GetTableNames();
        Task AddTableHistory(List<string> history);
        Task<UserVaultAppDetailModel> GetUserVaultAppDetailsV2(int? userVaultId);
        Task<UserVaultModel> GetUserVaultById(int userVaultId);
    }

}