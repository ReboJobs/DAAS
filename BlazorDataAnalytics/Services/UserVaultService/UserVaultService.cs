using Azure.Security.KeyVault.Secrets;
using BlazorDataAnalytics.Enums;
using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Services.KeyVaultManager;
using BlazorDataAnalytics.Services.UserVaultService;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.UserVaultService
{
    public class UserVaultService : IUserVaultService
    {
     //   private readonly DataAnalyticsDBContext context;
        private readonly IKeyVaultManager keyVaultManager;

        public UserVaultService(IKeyVaultManager _keyVaultManager, DataAnalyticsDBContext db)
        {
            _keyVaultManager = keyVaultManager;
         //   context = db;
        }

		public async Task<UserVaultModel> UpsertUserVaultAsync(UserVaultModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				try
				{
					var userVaultDB = context.UserVaults.FirstOrDefault(x => x.Id == model.Id);

					if (userVaultDB != null)
					{
						userVaultDB.SystemId = (byte)model.System;
						userVaultDB.Description = model.Description;
						userVaultDB.ContentType = model.ContentType;
						userVaultDB.CustomerTenantId = model.CustomerTenantID;
					}
					else
					{
						userVaultDB = new UserVault
						{
							SystemId = (byte)model.System,
							Description = model.Description,
							DateCreated = System.DateTime.Now,
							ContentType = model.ContentType,
							CustomerTenantId = model.CustomerTenantID,
							IsActive = true,
						};

						context.UserVaults.Add(userVaultDB);
					}

					await context.SaveChangesAsync();
					model.Id = userVaultDB.Id;

					return model;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public async Task<UserVaultAppDetailModel> UpsertUserVaultAppDetailAsync(UserVaultAppDetailModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				try
				{
					var userVaulAppDetailtDB = context.UserVaultAppDetails.FirstOrDefault(x => x.UserVaultId == model.UserVaultId);

					if (userVaulAppDetailtDB != null)
					{
						userVaulAppDetailtDB.ClientId = model.ClientId;
						userVaulAppDetailtDB.ClientSecret = model.ClientSecret;
						userVaulAppDetailtDB.CallBackUrl = model.CallBackUrl;
						userVaulAppDetailtDB.ServerName = model.ServerName;
						userVaulAppDetailtDB.DatabaseName = model.DatabaseName;
						userVaulAppDetailtDB.UserName = model.UserName;
						userVaulAppDetailtDB.UserPassword = model.UserPassword;
						userVaulAppDetailtDB.IsBackUpToCustomer = model.IsBackUpToCustomer;
						userVaulAppDetailtDB.DatalakeConString = model.DatalakeConString;
						userVaulAppDetailtDB.Warehouse = model.Warehouse;
						userVaulAppDetailtDB.KeepDataSecretKey = model.KeepDataSecretKey;
						userVaulAppDetailtDB.KeepDataStorageAccountName = model.KeepDataStorageAccountName;
						userVaulAppDetailtDB.KeepDataContainerName = model.KeepDataContainerName;
						userVaulAppDetailtDB.IsKeepData = model.IsKeepData;
						userVaulAppDetailtDB.IsStoreInQTX = model.IsStoreInQTX;
						userVaulAppDetailtDB.SecurityToken = model.SecurityToken;
						userVaulAppDetailtDB.APIVersion = model.APIVersion;
						userVaulAppDetailtDB.Tables = model.Tables;
						userVaulAppDetailtDB.RecurrenceNo = model.RecurrenceNo;
						userVaulAppDetailtDB.RecurrenceDesc = model.RecurrenceDesc;
						//userVaulAppDetailtDB.RefreshToken = model.;
						//userVaultDB.CustomerTenantId = model.CustomerTenantID;d
					}
					else
					{
						userVaulAppDetailtDB = new UserVaultAppDetail
						{
							UserVaultId = model.UserVaultId,
							ClientId = model.ClientId,
							ClientSecret = model.ClientSecret,
							ServerName = model.ServerName,
							DatabaseName = model.DatabaseName,
							UserName = model.UserName,
							UserPassword = model.UserPassword,
							IsBackUpToCustomer = model.IsBackUpToCustomer,
							DatalakeConString = model.DatalakeConString,
							Warehouse = model.Warehouse,
							KeepDataSecretKey = model.KeepDataSecretKey,
							KeepDataStorageAccountName = model.KeepDataStorageAccountName,
							KeepDataContainerName = model.KeepDataContainerName,
							IsKeepData = model.IsKeepData,
							IsStoreInQTX = model.IsStoreInQTX,
							SecurityToken = model.SecurityToken,
							APIVersion = model.APIVersion,
							Tables = model.Tables,
							RecurrenceNo = model.RecurrenceNo,
							RecurrenceDesc = model.RecurrenceDesc
						};

						context.UserVaultAppDetails.Add(userVaulAppDetailtDB);
					}

					await context.SaveChangesAsync();
					model.Id = userVaulAppDetailtDB.Id;

					return model;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public async Task UpdateUserAppDetailTokenAsync(UserVaultAppDetailModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				try
				{
					var userVaulAppDetailtDB = context.UserVaultAppDetails.FirstOrDefault(x => x.UserVaultId == model.UserVaultId);

					if (userVaulAppDetailtDB != null)
					{
						userVaulAppDetailtDB.AccessToken = model.AccessToken;
						userVaulAppDetailtDB.RefreshToken = model.RefreshToken;
						userVaulAppDetailtDB.DateTokenExpiredUtc = model.DateTokenExpiredUtc;
						userVaulAppDetailtDB.IdToken = model.IdToken;
						userVaulAppDetailtDB.PayLoadData = model.PayLoadData;
						await context.SaveChangesAsync();
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public async Task DeletetUserVaultAsync(int userVaultId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				try
				{
					var userVaultDB = context.UserVaults.FirstOrDefault(x => x.Id == userVaultId);

					if (userVaultDB != null)
					{
						context.UserVaults.Remove(userVaultDB);
					}
					await context.SaveChangesAsync();

				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public async Task<List<UserVaultModel>> SearchUserVault(string text,int? customerTenantId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var userVaultModel = context.UserVaults
			.Where(s => s.IsActive == true
					 && (s.Id.ToString().Contains(text) || s.Description.Contains(text) || string.IsNullOrEmpty(text) && s.CustomerTenantId == customerTenantId))
			.Select(x => new UserVaultModel
			{
				Id = x.Id,
				ContentType = x.ContentType,
				Description = x.Description ?? String.Empty,
				System = (EnumSystem)x.SystemId,
				ConnectorTypeId = context.SystemNames.FirstOrDefault(s => s.Id == x.SystemId).ConnectorTypeId,
				CustomerTenantID = x.CustomerTenantId
			}).OrderByDescending(x => x.Id).ToList();

				foreach (var userVault in userVaultModel)
				{
					userVault.UserVaultAppDetail = await GetUserVaultAppDetails(userVault.Id);
				}

				return userVaultModel;
			}
		}

		public async Task<List<UserVaultModel>> SearchUserVault(int? customerTenantId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var userVaultModel = context.UserVaults
			.Where(s => s.IsActive == true
					 && s.CustomerTenantId == customerTenantId)
			.Select(x => new UserVaultModel
			{
				Id = x.Id,
				ContentType = x.ContentType,
				Description = x.Description ?? String.Empty,
				System = (EnumSystem)x.SystemId,
				ConnectorTypeId = context.SystemNames.FirstOrDefault(s => s.Id == x.SystemId).ConnectorTypeId,
				CustomerTenantID = x.CustomerTenantId
			}).OrderByDescending(x => x.Id).ToList();

				foreach (var userVault in userVaultModel)
				{
					userVault.UserVaultAppDetail = await GetUserVaultAppDetails(userVault.Id);
				}

				return userVaultModel;
			}
		}

		public async Task<UserVaultAppDetailModel> GetUserVaultAppDetails(int? userVaultId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var userVaultAppDetail = context.UserVaultAppDetails.
										Select(x => new UserVaultAppDetailModel
										{
											Id = x.Id,
											ClientId = x.ClientId,
											ClientSecret = x.ClientSecret,
											AccessToken = x.AccessToken,
											RefreshToken = x.RefreshToken,
											UserVaultId = x.UserVaultId,
											DateTokenExpiredUtc = x.DateTokenExpiredUtc,
											IsBackUpToCustomer = x.IsBackUpToCustomer,
											DatalakeConString = x.DatalakeConString,
											IsKeepData = x.IsKeepData,
											IsStoreInQTX = x.IsStoreInQTX,
											KeepDataSecretKey = x.KeepDataSecretKey,
											KeepDataStorageAccountName = x.KeepDataStorageAccountName,
											KeepDataContainerName = x.KeepDataContainerName,
											ServerName = x.ServerName,
											DatabaseName = x.DatabaseName,
											UserName = x.UserName,
											UserPassword = x.UserPassword,
											SecurityToken = x.SecurityToken,
											APIVersion = x.APIVersion,
											Tables = x.Tables,
											PayLoadData = x.PayLoadData,
											RecurrenceNo = x.RecurrenceNo,
											RecurrenceDesc = x.RecurrenceDesc
										}).FirstOrDefault(c => c.UserVaultId == userVaultId) ?? new UserVaultAppDetailModel();
				return userVaultAppDetail;
			}
		}

		public async Task<UserVaultAppDetailModel> GetUserVaultAppDetailsV2(int? userVaultId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var userVaultAppDetail = await context.UserVaultAppDetails.
										Select(x => new UserVaultAppDetailModel
										{
											Id = x.Id,
											ClientId = x.ClientId,
											ClientSecret = x.ClientSecret,
											AccessToken = x.AccessToken,
											RefreshToken = x.RefreshToken,
											UserVaultId = x.UserVaultId,
											DateTokenExpiredUtc = x.DateTokenExpiredUtc,
											IsBackUpToCustomer = x.IsBackUpToCustomer,
											DatalakeConString = x.DatalakeConString,
											IsKeepData = x.IsKeepData,
											IsStoreInQTX = x.IsStoreInQTX,
											KeepDataSecretKey = x.KeepDataSecretKey,
											KeepDataStorageAccountName = x.KeepDataStorageAccountName,
											KeepDataContainerName = x.KeepDataContainerName,
											ServerName = x.ServerName,
											DatabaseName = x.DatabaseName,
											UserName = x.UserName,
											UserPassword = x.UserPassword,
											SecurityToken = x.SecurityToken,
											APIVersion = x.APIVersion,
											Tables = x.Tables,
											PayLoadData = x.PayLoadData
										}).Where(c => c.UserVaultId == userVaultId).FirstOrDefaultAsync();
				return userVaultAppDetail;
			}
		}


		public List<CommonEnumModel> GetSystems()
		{
			using (var context = new DataAnalyticsDBContext())
			{
				return context.SystemNames
			.Select(x => new CommonEnumModel
			{
				Id = (int)x.Id,
				Name = x.Name,
				ConnectorTypeId = x.ConnectorTypeId,
			}).ToList() ?? new List<CommonEnumModel>();
			}
		}

		public List<string> GetTableNames()
		{
			using (var context = new DataAnalyticsDBContext())
			{

				return context.TableListHistory.Select(x => x.TableName).ToList();
			}
	
		}

		public  async Task AddTableHistory(List<string> history)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var ListHIstory = history.Select(x => new TableListHistory { TableName = x }).ToList();
				context.TableListHistory.AddRange(ListHIstory);
				await context.SaveChangesAsync();
			}
		}

		public async Task<UserVaultModel> GetUserVaultById(int userVaultId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				return await context.UserVaults
			.Where(s => s.IsActive == true
					 && s.Id == userVaultId)
			.Select(x => new UserVaultModel
			{
				Id = x.Id,
				ContentType = x.ContentType,
				Description = x.Description ?? String.Empty,
				System = (EnumSystem)x.SystemId,
				ConnectorTypeId = context.SystemNames.FirstOrDefault(s => s.Id == x.SystemId).ConnectorTypeId,
			}).FirstOrDefaultAsync();
			}
		}
	}
}