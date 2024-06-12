using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;
namespace BlazorDataAnalytics.Services.ReportThemesService
{
	public interface IReportTheme
	{
		Task<List<ReportThemeModel>> GetReportTheme(int CustomerTenant, int reportDBId);
		Task<bool> CheckExist(int CustomerTenant, int reportDBId, string name);
		Task SetAsDefaultTheme(int CustomerTenant, int reportDBId, string name);
		Task<ReportThemeModel> CreateOrUpdateReportTheme(ReportThemeModel theme);
		Task DeleteTheme(int id);
	}
}
