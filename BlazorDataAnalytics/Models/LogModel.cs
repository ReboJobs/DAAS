namespace BlazorDataAnalytics.Models
{
    public class LogModel
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }
        public string? Module { get; set; }
        public string? Message { get; set; }
        public string? Comments { get; set; }
        public string? CorrelationId { get; set; }
    }
}
