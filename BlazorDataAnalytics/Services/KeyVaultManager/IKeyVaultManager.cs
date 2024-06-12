using Azure.Security.KeyVault.Secrets;
using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.KeyVaultManager
{
    public interface IKeyVaultManager
    {
        Task<KeyVaultSecret> GetSecret(string secretName);
        Task<KeyVaultSecret> SetSecret(UserVaultModel model);
        Task<KeyVaultSecret> UpdateSecret(UserVaultModel model);
        Task DeleteSecret(string userVaultId);
        Task SetSecretValue(UserVaultModel model);
    }

}