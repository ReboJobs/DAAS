namespace BlazorDataAnalytics.Models
{
    public class ReportInDashboardModel
    {
        public int ReportDbId { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string UserRoleCode { get; set; }
        public Guid ReportPowerBiId { get; set; }
    }
}
