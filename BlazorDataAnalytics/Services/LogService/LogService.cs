
using System.Threading.Tasks;
using BlazorDataAnalytics.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.LogService
{

    public class LogService : ILogService
    {
        private readonly DataAnalyticsDBContext _db;

        public LogService(
                DataAnalyticsDBContext db)
        {
            _db = db;
        }

        public async Task  Log(LogModel logModel) 
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var log = new Logs { Message = logModel.Message, Module = logModel.Module, UserEmail = logModel.UserEmail, Date = logModel.Date, Comments = logModel.Comments };
                context.Add(log);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Logs>> GetLogs()
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return await context.Logs.ToListAsync();
            }
        }

        public async Task<Logs>  UpsertLog(LogModel log)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var logItem = context.Logs.Where(x => x.Id == log.Id || x.CorrelationId == log.CorrelationId).FirstOrDefault();
                if (logItem != null)
                {
                    logItem.Comments = string.IsNullOrEmpty(log.Comments) ? logItem.Comments : log.Comments;
                }
                else
                {
                    logItem = new Logs();
                    logItem.Message = log.Message;
                    logItem.Module = log.Module;
                    logItem.CorrelationId = log.CorrelationId;
                    logItem.UserEmail = log.UserEmail;
                    logItem.Date = log.Date;

                    context.Logs.Add(logItem);
                }
                await context.SaveChangesAsync();
                return logItem;
            }
        }
    }
}
