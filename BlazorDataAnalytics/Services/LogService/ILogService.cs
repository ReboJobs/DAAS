using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.LogService
{
    public interface ILogService
    {
        Task Log(LogModel log);
        Task<Logs> UpsertLog(LogModel log);
        Task<List<Logs>> GetLogs();
    }
}
