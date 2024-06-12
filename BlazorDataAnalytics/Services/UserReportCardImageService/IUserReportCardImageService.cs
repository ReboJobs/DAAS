using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.UserReportCardImageService
{
    public interface IUserReportCardImageService
    {
        Task<UserReportCardImageModel> UpsertUserReportCardImagesAsync(UserReportCardImageModel model);

        Task<UserReportCardImageModel> GetUserReportCardImagesByReportDBIDAsync(int reporDBID);
        Task<string> GetUserReportCardImageBlobURLByReportTitle(string reporTitle);
    }

}