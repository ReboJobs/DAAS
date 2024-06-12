namespace BlazorDataAnalytics.Models
{
    public class BookmarkModel
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? ReportDbid { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; } = false;
        public string? state { get; set; }
        public string? DisplayName { get; set; }
        public string? ReportId { get; set; }

    }
}
