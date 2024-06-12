
using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.LikeService
{
    public interface ILikeService
    {
        Task<LikeModel> UpsertLikeAsync(LikeModel model);
        Task<List<LikeModel>> GetLikesInDashboardByReportDbId(int reportDbId, int customerTenantID);
    }
}

