namespace BlazorDataAnalytics.Models
{
    public class LikeModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ReportDbid { get; set; }
        public string? Title { get; set; }
        public bool? IsLike { get; set; }

        public int? CustomerTenantID { get; set; }
    }
}
