namespace BlazorDataAnalytics.Models
{
    public class DatasetGovernanceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Criteria { get; set; }
        public string? Action { get; set; }
        public string? DatasetId { get; set; }

    }
}
