using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.ReportBugService
{
	public interface IReportBugService
	{
		Task<ReportBugModel> UpsertReportBugAsync(ReportBugModel model);
		Task<List<ReportBugModel>> GestReportBugListAsync(ReportBugSearchModel model);
		Task DeleteReportBugAsync(int reportBugId);
		Task UpsertReportBugImageBlobUrlAsync(int ideaId, string imageUrl);
	}

}