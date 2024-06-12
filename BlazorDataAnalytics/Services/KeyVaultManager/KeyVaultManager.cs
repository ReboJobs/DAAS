using Azure.Security.KeyVault.Secrets;
using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Services.KeyVaultManager;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Persistence.Config.Entities;
using SecretProperties = Azure.Security.KeyVault.Secrets.SecretProperties;

namespace BlazorDataAnalytics.Services.KeyVaultManager
{
    public class KeyVaultManager : IKeyVaultManager
    {

        private readonly SecretClient _secretClient;
        private readonly DataAnalyticsDBContext _db;

        public KeyVaultManager(SecretClient secretClient, DataAnalyticsDBContext db)
        {
            _secretClient = secretClient;
            _db = db;
        }

        public async Task<KeyVaultSecret> GetSecret(string secretName)
        {
            try
            {
                KeyVaultSecret keyValueSecret = await _secretClient.GetSecretAsync(secretName);
                return keyValueSecret;
            }
            catch
            {
                return null;
            }

        }

        public async Task<KeyVaultSecret> UpdateSecret(UserVaultModel model)
        {
            try
            {
                using (var context = new DataAnalyticsDBContext())
                {

                    var userValueDb = context.UserVaults.Where(x => x.Id == model.Id).FirstOrDefault();
                    if (userValueDb != null)
                    {
                        KeyVaultSecret keyValueSecret = await GetSecret(userValueDb?.Id.ToString());
                        if (keyValueSecret != null)
                        {
                            keyValueSecret.Properties.ContentType = model.ContentType;
                            SecretProperties updatedSecretProperties = await _secretClient.UpdateSecretPropertiesAsync(keyValueSecret.Properties);
                        }

                        return keyValueSecret;
                    }
                    else
                    {
                        return await SetSecret(model);
                    }
                }
            }

            catch
            {
                throw;
            }

        }

        public async Task<KeyVaultSecret> SetSecret(UserVaultModel model)
        {
            try
            {

                KeyVaultSecret keyValueSecret = await _secretClient.SetSecretAsync(model.Id.ToString(), model.ConnectionString);

                keyValueSecret.Properties.ContentType = model.ContentType;
                SecretProperties updatedSecretProperties = await _secretClient.UpdateSecretPropertiesAsync(keyValueSecret.Properties);

                return keyValueSecret;
            }

            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task SetSecretValue(UserVaultModel model)
        {
            try
            {
                KeyVaultSecret keyValueSecret = await _secretClient.SetSecretAsync(model.Id.ToString(), model.UserVaultAppDetail.KeepDataSecretKey);
                keyValueSecret.Properties.ContentType = model.ContentType;
                SecretProperties updatedSecretProperties = await _secretClient.UpdateSecretPropertiesAsync(keyValueSecret.Properties);
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteSecret(string userVaultId)
        {
            try
            {
                var operation = await _secretClient.StartDeleteSecretAsync(userVaultId);
                await operation.WaitForCompletionAsync();
               // await _secretClient.PurgeDeletedSecretAsync(userVaultId);
            }
            catch
            {
                //throw;
            }

        }

    }
}