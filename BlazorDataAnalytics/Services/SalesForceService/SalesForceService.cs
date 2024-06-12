using Microsoft.EntityFrameworkCore;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.SalesForceService
{
    public class SalesForceService : ISalesForceService
    {
        private readonly DataAnalyticsDBContext _db;

        public SalesForceService(DataAnalyticsDBContext db)
        {
            _db = db;
        }

        public async Task<List<SalesForceTable>> getTablesAndColumns() 
        {
            return  await _db.SalesForceTable.ToListAsync();
        }

        public async Task<List<UserVaultSalesForceTable>> getUserVaultAppDetailTablesAndColumns(int id)
        {
            return await _db.UserVaultSalesForceTable.Where(x=>x.UserVaultAppDetailsId == id).ToListAsync();
        }

        public async Task AddTableAndColumns(List<UserVaultSalesForceTable> listSalesForce )
        {
            var toBeRemove = await _db.UserVaultSalesForceTable.Where(x => x.UserVaultAppDetailsId == listSalesForce.FirstOrDefault().UserVaultAppDetailsId).ToListAsync();
             _db.RemoveRange(toBeRemove);
            await _db.SaveChangesAsync();
            await _db.UserVaultSalesForceTable.AddRangeAsync(listSalesForce);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAllTableAndColumns(int UserVaultAppDetailsId)
        {
            var toBeRemove = await _db.UserVaultSalesForceTable.Where(x => x.UserVaultAppDetailsId == UserVaultAppDetailsId).ToListAsync();
            _db.RemoveRange(toBeRemove);
            await _db.SaveChangesAsync();
        }
    }
}
