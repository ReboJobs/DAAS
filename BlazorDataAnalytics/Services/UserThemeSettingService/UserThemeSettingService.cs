using Persistence.Config.Entities;
using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Enums;

namespace BlazorDataAnalytics.Services.UserThemeSettingService
{
	public class UserThemeSettingService : IUserThemeSettingService
	{
		//private readonly DataAnalyticsDBContext context;
		private readonly IConfiguration _config;

		public UserThemeSettingService(
		DataAnalyticsDBContext db,
		IConfiguration config)
		{
	//		context = db;
			_config = config;
		}


		public UserThemeSettingModel GetUserThemeSettings(string username)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				int customerTenantId = 0;
				UserThemeSetting userThemeDb = null;
				var customerUser = context.CustomerUsers.Where(x => x.UserName == username).FirstOrDefault();
				if (customerUser != null)
				{
					customerTenantId = context.CustomerUserGroups.FirstOrDefault(x => context.CustomerUserAssignGroups.Any(a => a.CustomerUserId == customerUser.Id && a.CustomerUserGroupId == x.Id)) != null ? context.CustomerUserGroups.FirstOrDefault(x => context.CustomerUserAssignGroups.Any(a => a.CustomerUserId == customerUser.Id && a.CustomerUserGroupId == x.Id)).CustomerTenantId ?? 0 : 0;
				}

				var userTheme = context.UserThemeSettings
					.Where(wr => wr.CustomerTenantId == customerTenantId)
					.Select(x => new UserThemeSettingModel
					{

						Id = x.Id,
						UserName = x.UserName,
						DashboardColorHex = x.DashboardColorHex,
						DashboardFontColorHex = x.DashboardFontColorHex,
						NavigationColorHex = x.NavigationColorHex,
						NavigationFontColorHex = x.NavigationFontColorHex,
						BackgroundColorHex = x.BackgroundColorHex,
						BackgroundFontColorHex = x.BackgroundFontColorHex,
						HeaderImageLogoUrl = x.HeaderImageLogoUrl,
						BackgroundImageLogoUrl = x.BackgroundImageLogoUrl,
						IsBackgroundImage = x.IsBackgroundImage,
						SwitchTheme = x.SwitchTheme

					}).FirstOrDefault();

				return userTheme;
			}
		
		}

		public async Task<UserThemeSettingModel> UpsertUserThemeAsync(UserThemeSettingModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				int customerTenantId = 0;
				UserThemeSetting userThemeDb = null;
				var customerUser = context.CustomerUsers.Where(x => x.UserName == model.UserName).FirstOrDefault();
				if (customerUser != null)
				{
					customerTenantId = context.CustomerUserGroups.FirstOrDefault(x => context.CustomerUserAssignGroups.Any(a => a.CustomerUserId == customerUser.Id && a.CustomerUserGroupId == x.Id)).CustomerTenantId ?? 0;
					userThemeDb = context.UserThemeSettings.FirstOrDefault(x => x.CustomerTenantId == customerTenantId);
				}

				if (userThemeDb != null)
				{
					userThemeDb.CustomerTenantId = customerTenantId;
					userThemeDb.DashboardColorHex = model.DashboardColorHex;
					userThemeDb.DashboardFontColorHex = model.DashboardFontColorHex;
					userThemeDb.NavigationColorHex = model.NavigationColorHex;
					userThemeDb.NavigationFontColorHex = model.NavigationFontColorHex;
					userThemeDb.BackgroundColorHex = model.BackgroundColorHex;
					userThemeDb.BackgroundFontColorHex = model.BackgroundFontColorHex;
					userThemeDb.IsBackgroundImage = model.IsBackgroundImage;
					userThemeDb.SwitchTheme = model.SwitchTheme;
				}
				else
				{
					userThemeDb = new UserThemeSetting
					{
						CustomerTenantId = customerTenantId,
						UserName = model.UserName,
						DashboardColorHex = model.DashboardColorHex,
						DashboardFontColorHex = model.DashboardFontColorHex,
						NavigationColorHex = model.NavigationColorHex,
						NavigationFontColorHex = model.NavigationFontColorHex,
						BackgroundColorHex = model.BackgroundColorHex,
						BackgroundFontColorHex = model.BackgroundFontColorHex,
						IsBackgroundImage = model.IsBackgroundImage,
						SwitchTheme = model.SwitchTheme
					};

					context.UserThemeSettings.Add(userThemeDb);
				}

				await context.SaveChangesAsync();
				model.Id = userThemeDb.Id;

				return model;
			}
		}
		public async Task<UserThemeSettingModel> UpdateUserImagesHeaderLogo(string username,string imageURLBlob)
        {
			using (var context = new DataAnalyticsDBContext())
			{
				int customerTenantId = 0;
				UserThemeSettingModel model = new UserThemeSettingModel();
				UserThemeSetting userThemeDb = null;
				var customerUser = context.CustomerUsers.Where(x => x.UserName == username).FirstOrDefault();
				if (customerUser != null)
				{
					customerTenantId = context.CustomerUserGroups.FirstOrDefault(x => context.CustomerUserAssignGroups.Any(a => a.CustomerUserId == customerUser.Id && a.CustomerUserGroupId == x.Id)).CustomerTenantId ?? 0;
					userThemeDb = context.UserThemeSettings.FirstOrDefault(x => x.CustomerTenantId == customerTenantId);
				}
				if (userThemeDb != null)
				{
					userThemeDb.HeaderImageLogoUrl = imageURLBlob;
				}
				else
				{
					userThemeDb = new UserThemeSetting
					{
						CustomerTenantId = customerTenantId,
						UserName = username,
						DashboardColorHex = string.Empty,
						DashboardFontColorHex = string.Empty,
						NavigationColorHex = string.Empty,
						NavigationFontColorHex = string.Empty,
						BackgroundColorHex = string.Empty,
						BackgroundFontColorHex = string.Empty,
						HeaderImageLogoUrl = imageURLBlob,
						IsBackgroundImage = false,
					};

					context.UserThemeSettings.Add(userThemeDb);
				}
				await context.SaveChangesAsync();
				model.Id = userThemeDb.Id;

				return model;
			}
		}
		public async Task<UserThemeSettingModel> UpdateUserBackgroundImages(string username, string imageURLBlob)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				int customerTenantId = 0;
				UserThemeSettingModel model = new UserThemeSettingModel();
				UserThemeSetting userThemeDb = null;
				var customerUser = context.CustomerUsers.FirstOrDefault(x => x.UserName == username);
				if (customerUser != null)
				{
					customerTenantId = context.CustomerUserGroups.Where(x => context.CustomerUserAssignGroups.Any(a => a.CustomerUserId == customerUser.Id && a.CustomerUserGroupId == x.Id)).FirstOrDefault().CustomerTenantId ?? 0;
					userThemeDb = context.UserThemeSettings.FirstOrDefault(x => x.CustomerTenantId == customerTenantId);
				}
				if (userThemeDb != null)
				{
					userThemeDb.BackgroundImageLogoUrl = imageURLBlob;
				}
				else
				{
					userThemeDb = new UserThemeSetting
					{
						CustomerTenantId = customerTenantId,
						UserName = username,
						DashboardColorHex = string.Empty,
						DashboardFontColorHex = string.Empty,
						NavigationColorHex = string.Empty,
						NavigationFontColorHex = string.Empty,
						BackgroundColorHex = string.Empty,
						BackgroundFontColorHex = string.Empty,
						BackgroundImageLogoUrl = imageURLBlob,
						IsBackgroundImage = false,
					};

					context.UserThemeSettings.Add(userThemeDb);
				}
				await context.SaveChangesAsync();
				model.Id = userThemeDb.Id;

				return model;
			}
		}

		public async Task<UserThemeSettingModel> ResetUserThemes(string username)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				int customerTenantId = 0;
				UserThemeSettingModel model = new UserThemeSettingModel();
				UserThemeSetting userThemeDb = null;
				var customerUser = context.CustomerUsers.FirstOrDefault(x => x.UserName == username);
				if (customerUser != null)
				{
					customerTenantId = context.CustomerUserGroups.Where(x => context.CustomerUserAssignGroups.Any(a => a.CustomerUserId == customerUser.Id && a.CustomerUserGroupId == x.Id)).FirstOrDefault().CustomerTenantId ?? 0;
					userThemeDb = context.UserThemeSettings.FirstOrDefault(x => x.CustomerTenantId == customerTenantId);
				}

				if (userThemeDb != null)
				{
					userThemeDb.CustomerTenantId = customerTenantId;
					userThemeDb.DashboardColorHex = model.DashboardColorHex;
					userThemeDb.DashboardFontColorHex = model.DashboardFontColorHex;
					userThemeDb.NavigationColorHex = model.NavigationColorHex;
					userThemeDb.NavigationFontColorHex = model.NavigationFontColorHex;
					userThemeDb.BackgroundColorHex = model.BackgroundColorHex;
					userThemeDb.BackgroundFontColorHex = model.BackgroundFontColorHex;
					userThemeDb.IsBackgroundImage = model.IsBackgroundImage;
					userThemeDb.BackgroundImageLogoUrl = model.BackgroundImageLogoUrl;
					userThemeDb.HeaderImageLogoUrl = model.HeaderImageLogoUrl;
				}
				await context.SaveChangesAsync();
				model.Id = userThemeDb.Id;

				return model;
			}
		}
	}
}