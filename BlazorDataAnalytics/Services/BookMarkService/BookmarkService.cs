
using Persistence.Config.Entities;
using BlazorDataAnalytics.Models;

namespace BlazorDataAnalytics.Services.BookMarkService
{
    public class BookmarkService: IBookmarkService
    {
		private readonly DataAnalyticsDBContext _db;
		private readonly IConfiguration _config;

		public BookmarkService(
		DataAnalyticsDBContext db,
		IConfiguration config)
		{
			_db = db;
			_config = config;
		}

        public async Task<List<BookmarkModel>> GetBookmarks(BookmarkModel model)
        {
            using (var context = new DataAnalyticsDBContext()) { 
                return (from b in context.Bookmarks
                        where (b.Title == model.Title) && (b.UserId == model.UserId)
                        select new BookmarkModel
                        {
                            ReportDbid = b.ReportDbid,
                            Title = b.Title,
                            UserId = b.UserId,
                            state = b.state,
                            DisplayName = b.DisplayName,
                            ReportId = b.ReportId,
                        }).ToList();
            }
        }

        public async Task<List<BookmarkModel>> GetBookmarksByUserAndIsActive(BookmarkModel model)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return context.Bookmarks.Where(c => c.UserId == model.UserId && c.IsActive == true)
                    .Select(x => new BookmarkModel
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        IsActive = x.IsActive ?? false,
                        ReportDbid = x.ReportDbid,
                        Title = x.Title,
                        state = x.state,
                        DisplayName = x.DisplayName,
                        ReportId = x.ReportId
                    })
                    .ToList();
            }
        }

    public async Task<BookmarkModel> UpsertBookmark(BookmarkModel model)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var bookmarkDB = context.Bookmarks.Where(x => x.Title == model.Title && x.UserId == model.UserId).FirstOrDefault();

                if (bookmarkDB != null && model.IsActive == false)
                {
                    bookmarkDB.IsActive = true;
                    await context.SaveChangesAsync();
                }
                if (bookmarkDB != null && model.IsActive == true)
                {
                    bookmarkDB.IsActive = false;
                    await context.SaveChangesAsync();
                }
                else if (bookmarkDB == null)
                {
                    bookmarkDB = new Bookmark
                    {
                        UserId = model.UserId,
                        ReportDbid = model.ReportDbid,
                        Title = model.Title,
                        IsActive = true,
                        state = model.state,
                        DisplayName = model.DisplayName,
                        ReportId = model.ReportId
                    };

                    context.Bookmarks.Add(bookmarkDB);
                    await context.SaveChangesAsync();
                }

                return model;
            }
        }

        public async Task<BookmarkModel> GetBookmarkInDashboardByReportDbIdAndUserId(int reportDbId, int userid)
        {
            using (var context = new DataAnalyticsDBContext())
            {

                return (from b in context.Bookmarks
                        join u in context.Users on b.UserId equals u.UserId
                        where (b.ReportDbid == reportDbId) && (b.UserId == userid)
                        select new BookmarkModel
                        {
                            Id = b.Id,
                            ReportDbid = b.ReportDbid,
                            Title = b.Title,
                            UserId = b.UserId,
                            IsActive = b.IsActive ?? false,
                            state = b.state,
                            DisplayName = b.DisplayName,
                            ReportId = b.ReportId
                        }).FirstOrDefault() ?? null;
            }
        }
        public async Task<List<BookmarkModel>> GetBookmarkInReportByReportId(string reportId, int userid)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return (from b in context.Bookmarks
                        join u in context.Users on b.UserId equals u.UserId
                        where (b.ReportId == reportId) && (b.UserId == userid)
                        select new BookmarkModel
                        {
                            Id = b.Id,
                            ReportDbid = b.ReportDbid,
                            Title = b.Title,
                            UserId = b.UserId,
                            IsActive = b.IsActive ?? false,
                            state = b.state,
                            DisplayName = b.DisplayName,
                            ReportId = b.ReportId
                        }).ToList() ?? null;
            }
        }
    }
}
