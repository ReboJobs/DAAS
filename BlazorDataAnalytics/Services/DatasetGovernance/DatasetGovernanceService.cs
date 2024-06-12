using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.DatasetGovernance
{
    public class DatasetGovernanceService : IDatasetGovernanceService
    {
        private readonly DataAnalyticsDBContext _db;
        private readonly IConfiguration _config;

        public DatasetGovernanceService(
        DataAnalyticsDBContext db,
        IConfiguration config)
        {
           _db = db;
            _config = config;
        }
      public async Task DeleteDatasetGovernance(int id)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var data = context.DatasetGovernance.Where(x => x.Id == id).FirstOrDefault();
                if (data != null)
                {
                    context.DatasetGovernance.Remove(data);

                }
                await context.SaveChangesAsync();
            }
        }

      public async Task<DatasetGovernanceModel> UpsertDatasetGovernance(DatasetGovernanceModel model)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var data = context.DatasetGovernance.Where(x => x.Id == model.Id).FirstOrDefault();
                if (data != null)
                {
                    data.Action = model.Action;
                    data.Criteria = model.Criteria;
                    data.Name = model.Name;
                    data.DatasetId = model.DatasetId;
                    data.Id = model.Id;
                }
                else
                {
                    data = new Persistence.Config.Entities.DatasetGovernance();
                    data.Criteria = model.Criteria;
                    data.Action = model.Action;
                    data.Name = model.Name;
                    data.DatasetId = model.DatasetId;
                    data.Id = model.Id;
                    context.DatasetGovernance.Add(data);
                }

                await context.SaveChangesAsync();
                model.Id = data.Id;

                return model;
            }

        }

      public List<Persistence.Config.Entities.DatasetGovernance> getDataGovernance(string datasetId)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return context.DatasetGovernance.Where(x => x.DatasetId == datasetId).ToList();
            }
        }
    }
}
