using Persistence.Config.Entities;
using BlazorDataAnalytics.Models;
namespace BlazorDataAnalytics.Services.DatasetGovernance
{
    public interface IDatasetGovernanceService
    {
        Task<DatasetGovernanceModel> UpsertDatasetGovernance(DatasetGovernanceModel model);
        Task DeleteDatasetGovernance(int ideaId);
        List<Persistence.Config.Entities.DatasetGovernance> getDataGovernance(string datasetId);
    }
}
