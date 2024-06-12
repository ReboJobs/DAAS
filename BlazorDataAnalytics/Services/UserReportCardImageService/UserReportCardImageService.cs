using Azure.Security.KeyVault.Secrets;
using BlazorDataAnalytics.Enums;
using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Services.UserReportCardImageService;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.UserVaultService
{
    public class UserReportCardImageService : IUserReportCardImageService
	{
      //  private readonly DataAnalyticsDBContext _db;

        public UserReportCardImageService(DataAnalyticsDBContext db)
        {
      //      _db = db;
        }

		public async Task<UserReportCardImageModel> UpsertUserReportCardImagesAsync(UserReportCardImageModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var userReportCardImagesDb = context.UserReportCardImages.Where(x => x.ReportDbid == model.ReportDBID).FirstOrDefault();

				if (userReportCardImagesDb != null)
				{
					userReportCardImagesDb.DateUpdated = DateTime.Now;
					userReportCardImagesDb.UserName = model.UserName;
					userReportCardImagesDb.ImageBlobUrl = model.ImageBlobURL;
					userReportCardImagesDb.UserName = model.UserName;
				}
				else
				{
					userReportCardImagesDb = new UserReportCardImage
					{
						ReportDbid = model.ReportDBID,
						UserName = model.UserName,
						ImageBlobUrl = model.ImageBlobURL,
						DateCreated = DateTime.Now,
						DateUpdated = DateTime.Now,
						IsActive = true
					};

					context.UserReportCardImages.Add(userReportCardImagesDb);
				}

				await context.SaveChangesAsync();
				model.Id = userReportCardImagesDb.Id;

				return model;
			}
		}

		public async Task<UserReportCardImageModel> GetUserReportCardImagesByReportDBIDAsync(int reporDBID)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var newModel = context.UserReportCardImages
										.Select(x => new UserReportCardImageModel
										{
											ReportDBID = x.ReportDbid,
											ImageBlobURL = x.ImageBlobUrl,
											UserName = x.UserName,
											DateCreated = x.DateCreated,
											DateUpdated = x.DateUpdated,
											Id = x.Id,
										})
										.Where(x => x.ReportDBID == reporDBID).FirstOrDefault();
				return newModel;
			}
		}

		public async Task<string> GetUserReportCardImageBlobURLByReportTitle (string reporTitle)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var reportInDashboard = context.ReportInDashboards.Where(x => x.Title == reporTitle).FirstOrDefault();

				if (reportInDashboard != null)
				{
					var UserReportCardImage = context.UserReportCardImages.FirstOrDefault(x => x.ReportDbid == reportInDashboard.ReportDbid);
					return UserReportCardImage?.ImageBlobUrl ?? string.Empty;
				}

				return string.Empty;
			}
		}
	}
}