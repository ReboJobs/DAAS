using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.SalesForceService
{
    public interface ISalesForceService
    {
        Task<List<SalesForceTable>> getTablesAndColumns();
        Task AddTableAndColumns(List<UserVaultSalesForceTable> listSalesForce);
        Task<List<UserVaultSalesForceTable>> getUserVaultAppDetailTablesAndColumns(int id);
        Task RemoveAllTableAndColumns(int UserVaultAppDetailsId);
    }
}
