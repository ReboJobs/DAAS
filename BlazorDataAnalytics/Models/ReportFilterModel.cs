namespace BlazorDataAnalytics.Models
{
    public class ReportFilterModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DatasetId { get; set; }
        public string AppId { get; set; }
        public string Description { get; set; }
        public string ReportType { get; set; }
        public string WebUrl { get; set; }
        public string EmbedUrl { get; set; }

        public string TagDashBoard { get; set; }

        public string Tag { get; set; }
    }
}
