using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.UserThemeSettingService
{

	public interface IUserThemeSettingService
	{
		UserThemeSettingModel GetUserThemeSettings(string username);
		Task<UserThemeSettingModel> UpsertUserThemeAsync(UserThemeSettingModel model);
		Task<UserThemeSettingModel> UpdateUserBackgroundImages(string username, string imageURLBlob);
		Task<UserThemeSettingModel> UpdateUserImagesHeaderLogo(string username, string imageURLBlob);
		Task<UserThemeSettingModel> ResetUserThemes(string username);
	}
	
}