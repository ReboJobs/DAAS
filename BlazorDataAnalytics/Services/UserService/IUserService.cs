

using System.Threading.Tasks;
using BlazorDataAnalytics.Models;
//using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel> GetUsers(string email);

        Task<UserModel> GetUsersName(string userName);

        Task<UserModel> UpsertUserAsync(UserModel model);
        Task<UserModel> GetUsersEmail(string userEmail);
        Task UpsertUserActiveAsync(UserModel model);
        Task<bool> IsAtLeastOneUserActive();
    }
}
