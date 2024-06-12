
using System.Threading.Tasks;
using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Services.UserService
{
    public class UserService:IUserService
    {
       // private readonly DataAnalyticsDBContext context;
        private readonly IConfiguration _config;

        public UserService(
        DataAnalyticsDBContext db,
        IConfiguration config)
        {
        //    context = db;
            _config = config;
        }

        public async Task<UserModel> GetUsers(string email)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return (from u in context.Users
                        where u.Email == email
                        select new UserModel
                        {
                            userID = u.UserId,
                            userName = u.UserName,
                            Email = u.Email
                        }).FirstOrDefault() ?? null;
            }
        }

        public async Task<UserModel> GetUsersName(string userName)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return (from u in context.Users
                        where u.UserName == userName
                        select new UserModel
                        {
                            userID = u.UserId,
                            userName = u.UserName,
                            Email = u.Email,
                            Active = u.Active
                        }).FirstOrDefault() ?? null;
            }
        }

        public async Task<UserModel> GetUsersEmail(string userEmail)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                return (from u in context.Users
                        where u.Email == userEmail
                        select new UserModel
                        {
                            userID = u.UserId,
                            userName = u.UserName,
                            Email = u.Email,
                            Active = u.Active
                        }).FirstOrDefault() ?? null;
            }
        }


        public async Task<UserModel> UpsertUserAsync(UserModel model)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var userDb = context.Users.Where(x => x.Email == model.Email).FirstOrDefault();

                if (userDb != null)
                {
                    userDb.UserName = model.userName;
                }
                else
                {
                    userDb = new User
                    {
                        UserName = model.userName,
                        Email = model.Email
                    };

                    context.Users.Add(userDb);
                }

                await context.SaveChangesAsync();
                model.userID = userDb.UserId;

                return model;
            }
        }

        public async Task UpsertUserActiveAsync(UserModel model)
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var userDb = context.Users.Where(x => x.Email == model.Email).FirstOrDefault();

                if (userDb != null)
                {
                    userDb.DateTimeLogin = DateTime.Now;
                    userDb.Active = model.Active;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> IsAtLeastOneUserActive()
        {
            using (var context = new DataAnalyticsDBContext())
            {
                var userDb = context.Users.Where(x => x.Active == true).Count();

                if (userDb > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
