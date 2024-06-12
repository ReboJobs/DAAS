
using Persistence.Config.Entities;
using System.Collections.Concurrent;

namespace BlazorDataAnalytics.Services.LoggingService
{
    public class LoggingServiceLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, LoggingService> _loggers = new ConcurrentDictionary<string, LoggingService>();
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;
        private readonly DataAnalyticsDBContext _db;
        public LoggingServiceLoggerProvider( Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, DataAnalyticsDBContext db)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        public ILogger CreateLogger(string categoryName)
        {
            var x = _httpContextAccessor;
            return _loggers.GetOrAdd(categoryName, name => new LoggingService(name,
                _httpContextAccessor,_db));
        }

        public void Dispose()
        {
        }
    }
}
