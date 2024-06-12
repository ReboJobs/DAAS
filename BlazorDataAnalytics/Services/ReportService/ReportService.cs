using Persistence.Config.Entities;
using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Enums;


namespace BlazorDataAnalytics.Services.ReportService
{
    public class ReportService : IReportService
    {
       // private readonly DataAnalyticsDBContext _db;
        private readonly IConfiguration _config;


        public ReportService(
        DataAnalyticsDBContext db,
        IConfiguration config)
        {
       //     _db = db;
            _config = config;
        }

        public async Task DeleteReportAsync(Guid id)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var reportDashboardDB = context.ReportInDashboards.Where(x => x.ReportPowerBiId == id).FirstOrDefault();
                if (reportDashboardDB.UserRoleCode != null)
                {
                    var customerUserRole = context.CustomerUserRoles.Where(x => x.Code == reportDashboardDB.UserRoleCode).FirstOrDefault();
                    var customerUserGroupRole = context.CustomerUserGroupRoles.Where(x => x.CustomerUserRoleId == customerUserRole.Id).ToList();

                    if (customerUserGroupRole != null) { context.CustomerUserGroupRoles.RemoveRange(customerUserGroupRole); }
                    if (customerUserRole != null) context.CustomerUserRoles.Remove(customerUserRole);

                }

                if (reportDashboardDB != null)
                {
                    context.ReportInDashboards.Remove(reportDashboardDB);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<ReportDashboardModel>> GetReportListAsync(ReportDashboardModel model)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var reportModel = context.ReportInDashboards
            .Where(s => (s.IsActive == model.IsActive))
            .Select(x => new ReportDashboardModel
            {
                ReportDbid = x.ReportDbid,
                Title = x.Title,
                Tags = x.Tags,
                IsActive = x.IsActive
            }).ToList();

                return reportModel;
            }
        }

    }
}
