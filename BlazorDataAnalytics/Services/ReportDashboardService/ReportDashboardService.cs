using Azure.Security.KeyVault.Secrets;
using BlazorDataAnalytics.Enums;
using BlazorDataAnalytics.Models;
using BlazorDataAnalytics.Services.KeyVaultManager;
using BlazorDataAnalytics.Services.UserVaultService;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.ReportDashboardService
{
    public class ReportDashboardService : IReportDashboardService
    {
        private readonly DataAnalyticsDBContext _db;
        private readonly IKeyVaultManager keyVaultManager;

        public ReportDashboardService(IKeyVaultManager _keyVaultManager, DataAnalyticsDBContext db)
        {
            _keyVaultManager = keyVaultManager;
            _db = db;
        }

        public async Task<List<ReportInDashboardModel>> GetReportsInDashboardByTenantId(int customerTenantId, string customerTenantSid)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var userGroupRole = (from cugr in context.CustomerUserGroupRoles
                                     join cug in context.CustomerUserGroups on cugr.CustomerUserGroupId equals cug.Id
                                     where cug.CustomerTenantId == customerTenantId
                                     select cugr.CustomerUserRoleId).ToList();

                return (from rd in context.ReportInDashboards
                        join cr in context.CustomerUserRoles on rd.UserRoleCode equals cr.Code
                        where (cr.CustomerTernantId == customerTenantId || customerTenantId == 0) && (rd.IsActive == true) && userGroupRole.Contains(cr.Id)
                        select new ReportInDashboardModel
                        {
                            ReportDbId = rd.ReportDbid,
                            Tags = rd.Tags,
                            Title = rd.Title,
                            UserRoleCode = rd.UserRoleCode,
                            ReportPowerBiId = rd.ReportPowerBiId ?? Guid.Empty
                        }).OrderBy(x => x.Title).ToList();
            }
        }

        public async Task<ReportInDashboardModel> GetReportsInDashboardByPowerBiId(Guid reportPowerBiId, int customerTenantId)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return (from rd in context.ReportInDashboards
                        join cr in context.CustomerUserRoles on rd.UserRoleCode equals cr.Code
                        where (cr.CustomerTernantId == customerTenantId || customerTenantId == 0)
                                && rd.IsActive == true
                                && rd.ReportPowerBiId == reportPowerBiId
                        select new ReportInDashboardModel
                        {
                            ReportDbId = rd.ReportDbid,
                            Tags = rd.Tags,
                            Title = rd.Title,
                            UserRoleCode = rd.UserRoleCode,
                            ReportPowerBiId = rd.ReportPowerBiId ?? Guid.Empty
                        }).FirstOrDefault();
            }
        }

        public async Task<ReportInDashboardModel> GetReportsInDashboardByTitle(string Title)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return (from dboard in context.ReportInDashboards
                        where dboard.Title == Title
                        select new ReportInDashboardModel
                        {
                            ReportDbId = dboard.ReportDbid,
                            Tags = dboard.Tags ?? String.Empty,
                            Title = dboard.Title ?? String.Empty,
                            UserRoleCode = dboard.UserRoleCode ?? String.Empty,
                            ReportPowerBiId = dboard.ReportPowerBiId ?? Guid.Empty
                        }).FirstOrDefault() ?? new ReportInDashboardModel();
            }
        }

        public async Task<List<BookmarkModel>> GetBookmarksInDashboardByTenantId(int customerTenantId, string userEmail)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                int userId = context.Users.Where(x => x.Email == userEmail).FirstOrDefault()?.UserId ?? 0;

                return (from b in context.Bookmarks
                        join rd in context.ReportInDashboards on b.ReportDbid equals rd.ReportDbid
                        join cr in context.CustomerUserRoles on rd.UserRoleCode equals cr.Code
                        where (cr.CustomerTernantId == customerTenantId || customerTenantId == 0)
                            && (b.UserId == userId || userId == 0) && (b.IsActive == true)
                        select new BookmarkModel
                        {
                            Id = b.Id,
                            ReportDbid = b.ReportDbid,
                            Title = b.Title,
                            IsActive = b.IsActive ?? false,
                            UserId = b.UserId,
                        }).OrderBy(x => x.Title).ToList();
            }
        }

        public async Task<string> UpsertReportInDashboard(string title, Guid reportPowerBiId, string userRoleCode)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var reportInDashboardDb = context.ReportInDashboards.Where(x => x.ReportPowerBiId == reportPowerBiId).FirstOrDefault();

                if (reportInDashboardDb != null)
                {
                    bool haveChanges = false;

                    if (reportInDashboardDb.Title != title)
                    {
                        reportInDashboardDb.Title = title;
                        haveChanges = true;
                    }

                    if (reportInDashboardDb.ReportPowerBiId != reportPowerBiId)
                    {
                        reportInDashboardDb.ReportPowerBiId = reportPowerBiId;
                        haveChanges = true;
                    }

                    if (reportInDashboardDb.UserRoleCode != userRoleCode)
                    {
                        reportInDashboardDb.UserRoleCode = userRoleCode;
                        haveChanges = true;
                    }

                    if (haveChanges)
                    {
                        await context.SaveChangesAsync();
                    }

                }
                else
                {
                    reportInDashboardDb = new ReportInDashboard
                    {
                        Title = title,
                        Tags = String.Empty,
                        ReportPowerBiId = reportPowerBiId,
                        UserRoleCode = userRoleCode,
                        IsActive = true,
                    };

                    context.ReportInDashboards.Add(reportInDashboardDb);

                    await context.SaveChangesAsync();
                }

                return title;
            }
        }

    }
}