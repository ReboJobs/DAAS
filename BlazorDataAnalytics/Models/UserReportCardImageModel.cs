

namespace BlazorDataAnalytics.Models
{
    public partial class UserReportCardImageModel
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public int? ReportDBID { get; set; }
        public string? ImageBlobURL { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
