using Persistence.Config.Entities;
using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Enums;

namespace BlazorDataAnalytics.Services.ReportBugService
{
	public class ReportBugService: IReportBugService
	{
		private readonly DataAnalyticsDBContext _db;
		private readonly IConfiguration _config;

		public ReportBugService(
		DataAnalyticsDBContext db,
		IConfiguration config)
		{
			_db = db;
			_config = config;
		}

		public async Task<ReportBugModel> UpsertReportBugAsync(ReportBugModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var reportBugDb = context.ReportBugs.Where(x => x.Id == model.Id).FirstOrDefault();

				if (reportBugDb != null)
				{
					reportBugDb.Title = model.Title;
					reportBugDb.Description = model.Description;
					reportBugDb.Status = (byte)model.ReportBugStatus;
					reportBugDb.ImageBlobURL = model.ImageBlobURL;
				}
				else
				{
					reportBugDb = new ReportBug
					{
						Title = model.Title,
						Description = model.Description,
						DateReported = DateTime.Now,
						ReportedBy = model.ReportedBy,
						Status = (byte)model.ReportBugStatus,
						IsActive = true,
						ImageBlobURL = model.ImageBlobURL
					};

					context.ReportBugs.Add(reportBugDb);
				}

				await context.SaveChangesAsync();
				model.Id = reportBugDb.Id;

				return model;
			}
		}


		public async Task<List<ReportBugModel>> GestReportBugListAsync(ReportBugSearchModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var reportBugModel = context.ReportBugs
			.Where(s => (s.DateReported >= model.DateFrom && s.DateReported <= model.DateTo)
					 && s.IsActive == true
					 && (s.Title.Contains(model.Text) || s.Description.Contains(model.Text) || string.IsNullOrEmpty(model.Text))
					 && (s.Status == (byte)model.ReportBugStatus || (byte)model.ReportBugStatus == 0)
					 && s.ReportedBy == model.ReportedBy || string.IsNullOrEmpty(model.ReportedBy))
			.Select(x => new ReportBugModel
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				DateReported = x.DateReported,
				ReportedBy = x.ReportedBy,
				ReportBugStatus = (EnumReportBugStatus)x.Status,
				IsActive = x.IsActive,
				ImageBlobURL = x.ImageBlobURL ?? String.Empty
			}).OrderByDescending(x => x.DateReported).ToList();

				return reportBugModel;
			}
		}

		public async Task DeleteReportBugAsync(int reportBugId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var reportBugDb = context.ReportBugs.Where(x => x.Id == reportBugId).FirstOrDefault();

				if (reportBugDb != null)
				{
					reportBugDb.IsActive = false;
					await context.SaveChangesAsync();
				}
			}
		}
		public async Task UpsertReportBugImageBlobUrlAsync(int ideaId, string imageUrl)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var reportBugDb = context.ReportBugs.Where(x => x.Id == ideaId).FirstOrDefault();

				if (reportBugDb != null)
				{
					reportBugDb.ImageBlobURL = imageUrl;
				}

				await context.SaveChangesAsync();
			}
		}

	}
}