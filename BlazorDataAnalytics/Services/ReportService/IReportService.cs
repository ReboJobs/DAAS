using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;


namespace BlazorDataAnalytics.Services.ReportService
{
    public interface IReportService
    {
        Task DeleteReportAsync(Guid id);

        Task<List<ReportDashboardModel>> GetReportListAsync(ReportDashboardModel model);
    }
}
