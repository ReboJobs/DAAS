using BlazorDataAnalytics.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Config.Entities;
namespace BlazorDataAnalytics.Services.ReportThemesService
{
	public class ReportThemeService : IReportTheme
	{
		private readonly DataAnalyticsDBContext _db;

		public ReportThemeService(DataAnalyticsDBContext db) { 
		
			this._db=db;
		}

		public async Task<ReportThemeModel> CreateOrUpdateReportTheme(ReportThemeModel theme)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var obj = context.ReportThemes.Where(x => x.ID == theme.ID).FirstOrDefault();
				if (obj == null)
				{
					obj = new ReportThemes();
					obj.IsDefaultTheme = theme.IsDefaultTheme;
					obj.ReportDBID = theme.ReportDBID;
					obj.Theme = theme.Theme;
					obj.CreatorUserName = theme.CreatorUserName;
					obj.CreatedDate = theme.CreatedDate;
					obj.CustomerTenantId = theme.CustomerTenantId;
					obj.ThemeName = theme.ThemeName;
					context.ReportThemes.Add(obj);

				}
				else
				{

					obj.IsDefaultTheme = theme.IsDefaultTheme;
					obj.ReportDBID = theme.ReportDBID;
					obj.Theme = theme.Theme;
					obj.CustomerTenantId = theme.CustomerTenantId;
					obj.ThemeName = theme.ThemeName;
					obj.CreatorUserName = theme.CreatorUserName;

					context.Update(obj);
				}
				try
				{
					await context.SaveChangesAsync();
				}
				catch (Exception ex) { }
				return theme;
			}
		}

		public async Task DeleteTheme(int id)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var obj = context.ReportThemes.Where(x => x.ID == id).FirstOrDefault();
				if (obj != null)
				{
					context.ReportThemes.Remove(obj);
					await context.SaveChangesAsync();
				}
			}
		}

		public async Task<List<ReportThemeModel>> GetReportTheme(int CustomerTenant, int reportDBId)
		{
			using (var context = new DataAnalyticsDBContext())
			{

				var data = context.ReportThemes.Where(x => x.CustomerTenantId == CustomerTenant && x.ReportDBID == reportDBId)
					  .Select(x =>
					  new ReportThemeModel
					  {
						  CreatedDate = x.CreatedDate,
						  CreatorUserName = x.CreatorUserName,
						  Theme = x.Theme,
						  ThemeName = x.ThemeName,
						  IsDefaultTheme = x.IsDefaultTheme,
						  CustomerTenantId = x.CustomerTenantId,
						  ReportDBID = x.ReportDBID,
						  ID = x.ID
					  }).ToList();
				return data;
			}

		}

		public async Task<bool> CheckExist(int CustomerTenant, int reportDBId, string name)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var data = context.ReportThemes.Where(x => x.CustomerTenantId == CustomerTenant && x.ReportDBID == reportDBId && x.ThemeName.Trim() == name.Trim()).FirstOrDefault() != null;
				return data;
			}
		}

		public async Task SetAsDefaultTheme(int CustomerTenant, int reportDBId, string name)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var data = context.ReportThemes.Where(x => x.CustomerTenantId == CustomerTenant && x.ReportDBID == reportDBId).ToList();

				foreach (var item in data)
				{
					if (item.ThemeName.ToLower().Trim() != name.ToLower().Trim())
						item.IsDefaultTheme = false;
					else
						item.IsDefaultTheme = true;
					context.Entry(item).State = EntityState.Modified;
				}
				context.UpdateRange(data);
				await context.SaveChangesAsync();
			}

		}
	}
}
