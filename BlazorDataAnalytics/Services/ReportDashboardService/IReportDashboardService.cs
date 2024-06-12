using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.ReportDashboardService
{
    public interface IReportDashboardService
    {
        Task<List<ReportInDashboardModel>> GetReportsInDashboardByTenantId(int customerTenantId, string customerTenantSid);
        Task<List<BookmarkModel>> GetBookmarksInDashboardByTenantId(int customerTenantId, string userEmail);
        Task<string> UpsertReportInDashboard(string title, Guid reportPowerBiId, string userRoleCode);
        Task<ReportInDashboardModel> GetReportsInDashboardByPowerBiId(Guid reportPowerBiId, int customerTenantId);
        Task<ReportInDashboardModel> GetReportsInDashboardByTitle(string Title);

    }

}