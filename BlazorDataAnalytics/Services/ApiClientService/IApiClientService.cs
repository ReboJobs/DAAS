
using System.Threading.Tasks;
//using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;


namespace BlazorDataAnalytics.Services.ApiClientService
{

    public interface IApiClientService
    { 
        Task<UserTrack> GetUserIPAsync();
    }
}
    