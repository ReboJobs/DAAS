

using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.BookMarkService
{
    public interface IBookmarkService
    {
        Task<List<BookmarkModel>> GetBookmarks(BookmarkModel model);

        Task<BookmarkModel> UpsertBookmark(BookmarkModel model);

        Task<BookmarkModel> GetBookmarkInDashboardByReportDbIdAndUserId(int reportDbId, int userid);

        Task<List<BookmarkModel>> GetBookmarksByUserAndIsActive(BookmarkModel model);
        Task<List<BookmarkModel>> GetBookmarkInReportByReportId(string reportId, int userid);

    }
}

