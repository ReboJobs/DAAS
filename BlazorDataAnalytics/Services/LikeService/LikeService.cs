using System.Threading.Tasks;
using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.LikeService
{
    public class LikeService: ILikeService
    {
     //   private readonly DataAnalyticsDBContext _db;
        private readonly IConfiguration _config;

        public LikeService(
        DataAnalyticsDBContext db,
        IConfiguration config)
        {
       //     _db = db;
            _config = config;
        }

        public async Task<List<LikeModel>> GetLikesInDashboardByReportDbId(int reportDbId, int customerTenantID)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return context.Likes
                    .Where(x => (x.ReportDbid == reportDbId) && (x.CustomerTenantId == customerTenantID))
                    .Select(x => new LikeModel
                    {
                        Id = x.Id,
                        ReportDbid = x.ReportDbid,
                        Title = x.Title,
                        UserId = x.UserId,
                        IsLike = x.IsLike,
                        CustomerTenantID = x.CustomerTenantId,
                    })
                    .ToList();
            }
        }

        public async Task<LikeModel> UpsertLikeAsync(LikeModel model)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var reportInLikeDb = context.Likes.Where(x => x.Title == model.Title && x.UserId == model.UserId).FirstOrDefault();

                if (reportInLikeDb != null)
                {
                    if (model.IsLike == false)
                    {
                        reportInLikeDb.IsLike = model.IsLike;
                    }
                    else if (model.IsLike == true)
                    {
                        reportInLikeDb.IsLike = model.IsLike;
                    }
                }
                else
                {
                    reportInLikeDb = new Like
                    {
                        UserId = model.UserId,
                        ReportDbid = model.ReportDbid,
                        Title = model.Title,
                        IsLike = model.IsLike,
                        CustomerTenantId = model.CustomerTenantID,
                    };

                    context.Likes.Add(reportInLikeDb);
                }

                await context.SaveChangesAsync();
                model.Id = reportInLikeDb.Id;

                return model;
            }
        }
    }
}
