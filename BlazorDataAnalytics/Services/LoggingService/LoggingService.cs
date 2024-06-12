using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.LoggingService
{
    public class LoggingServiceConfig
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public int EventId { get; set; } = 0;
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
    }

    public class LoggingService : ILogger
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;
        private readonly LoggingServiceConfig _config;
        private readonly DataAnalyticsDBContext _db;

        public LoggingService(string categoryName,
            Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, DataAnalyticsDBContext db)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true; //currently log everything regardless of logLevel
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            try
            {
                if (exception != null)
                {
                    string userName = "";
                    if(_httpContextAccessor!=null)
                        userName = _httpContextAccessor.HttpContext.User.Identity.Name;

                    var bug = new ReportBug { Title = "System Error", Description = exception.Message, DateReported = DateTime.Now, ReportedBy = userName, Status = 1, IsActive = true };
                    _db.ReportBugs.Add(bug);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            
            }

        }
    }
}
