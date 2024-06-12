
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorDataAnalytics.Models;
//using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;


namespace BlazorDataAnalytics.Services.UserSecurityService
{
    public class UserSecurityService : IUserSecurityService
    {

	//	private readonly DataAnalyticsDBContext context;
		private readonly IConfiguration _config;

		public UserSecurityService(
		DataAnalyticsDBContext db,
		IConfiguration config)
		{
	//		context = db;
			_config = config;
		}

		public async Task<UserNameGroupRolesModel> GetUserNameGroupRoles(string userName)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				UserNameGroupRolesModel userNameGroupRole = new UserNameGroupRolesModel();

				var customerUsers = context.CustomerUsers.Where(x => x.UserName == userName).FirstOrDefault();

				if (customerUsers != null)
				{
					userNameGroupRole = new UserNameGroupRolesModel
					{
						IsAdmin = customerUsers.IsAdmin ?? false,
						UserName = userName
					};


					var customerUserGroup = context.CustomerUserGroups.Where(x => context.CustomerUserAssignGroups.Any(c => c.CustomerUserId == customerUsers.Id && c.CustomerUserGroupId == x.Id) && x.IsActive == true).FirstOrDefault();
					if (customerUserGroup != null)
					{
						userNameGroupRole.CustomerTenantId = customerUserGroup.CustomerTenantId ?? 0;
						userNameGroupRole.ViewAllReport = customerUserGroup.ViewAllReport ?? false;
						var customerTenant = context.CustomerTenants.FirstOrDefault(x => x.Id == customerUserGroup.CustomerTenantId && x.IsActive == true);
						if (customerTenant != null)
						{
							userNameGroupRole.WorkspaceId = customerTenant.WorkspaceId ?? Guid.Empty;
							userNameGroupRole.WorkspaceUrl = customerTenant.WorkspaceUrl;
							userNameGroupRole.CustomerName = customerTenant.Name;
						}

					}

					var userRoles = (from cu in context.CustomerUsers
									 join cag in context.CustomerUserAssignGroups on cu.Id equals cag.CustomerUserId
									 join cgr in context.CustomerUserGroupRoles on cag.CustomerUserGroupId equals cgr.CustomerUserGroupId
									 join cr in context.CustomerUserRoles on cgr.CustomerUserRoleId equals cr.Id
									 where cu.UserName.ToLower() == userName.ToLower() && cr.IsActive == true
									 select new CustomerUserRoleModel
									 {
										 Id = cr.Id,
										 CustomerTernantId = cr.CustomerTernantId,
										 Code = cr.Code,
										 Description = cr.Description,
										 UserRoleName = cr.UserRoleName,
										 IsActive = cr.IsActive,
									 }).OrderBy(x => x.UserRoleName).ToList();

					userNameGroupRole.CustomerUserRoles = userRoles;

					return userNameGroupRole ?? new UserNameGroupRolesModel();
				}

				return userNameGroupRole;
			}
		}

		public async Task<bool> CheckUserGroupRole(string userName, string roleCode)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var userNameGroupRoles = await GetUserNameGroupRoles(userName);
				if (userNameGroupRoles != null)
				{
					if (userNameGroupRoles.IsAdmin)
					{
						if (context.CustomerUserRoles.Any(x => x.Code == roleCode && x.CustomerTernantId == userNameGroupRoles.CustomerTenantId))
						{
							return true;
						}
					}
					else
					{
						if (userNameGroupRoles.CustomerUserRoles.Any(x => x.Code == roleCode))
						{
							return true;
						}
					}
				}

				return false;
			}
		}


		public async Task<bool> GetUserAccessAdminRole(string userName)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				return context.CustomerUsers.Any(x => x.IsAdmin == true && x.UserName.ToLower() == userName.ToLower() && x.IsActive == true);
			}
		}

		//public async Task<List<CustomerUserModel>> SearchCustomerUsers(string text, int customertenantId = 0)
		//{
		//	var customerUsers = (from cu in context.CustomerUsers
		//						join cag in context.CustomerUserAssignGroups on cu.Id equals cag.CustomerUserId
		//						join cg in context.CustomerUserGroups on cag.CustomerUserGroupId equals cg.Id
		//						join ct in context.CustomerTenants on cg.CustomerTenantId equals ct.Id
		//					 where (cu.UserName.Contains(text) || cg.GroupName.Contains(text)
		//							|| ct.Name.Contains(text) || string.IsNullOrEmpty(text))
		//							&& cu.IsActive == true
		//							&& ((ct.Id == customertenantId && cg.CustomerTenantId == customertenantId) || customertenantId == 0)
		//						 select new CustomerUserModel
		//						 {
		//							 Id = cu.Id,
		//							 CustomerTenantId = ct.Id,
		//							 CustomerTenantName = ct.Name,
		//							 UserName = cu.UserName,
		//							 CustomerUserGroupName = string.Join(", ", context.CustomerUserGroups.Where(f => f.Id == cag.CustomerUserGroupId)
		//															.Select(p => p.GroupName).ToArray()),
		//							 IsActive = cu.IsActive,
		//							 IsAdmin = cu.IsAdmin,
		//							 SelectedCustomerUserGroupData = context.CustomerUserAssignGroups.Where(f => f.CustomerUserId == cu.Id)
		//															.Select(p => p.CustomerUserGroupId).ToArray()
		//						 }).ToList();

		//	return customerUsers.Distinct().ToList();

		//}

		public async Task<List<CustomerUserModel>> SearchCustomerUsers(string text, int customertenantId = 0)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUsers = (from cu in context.CustomerUsers
									 where cu.IsActive == true
										&& (cu.UserName.Contains(text) || string.IsNullOrEmpty(text))
									 select new CustomerUserModel
									 {
										 Id = cu.Id,
										 CustomerTenantId = (from sc in context.CustomerUserGroups
															 join cas in context.CustomerUserAssignGroups on sc.Id equals cas.CustomerUserGroupId
															 where cas.CustomerUserId == cu.Id
															 select sc.CustomerTenantId).FirstOrDefault(),
										 CustomerTenantName = (from sc in context.CustomerUserGroups
															   join cas in context.CustomerUserAssignGroups on sc.Id equals cas.CustomerUserGroupId
															   join ten in context.CustomerTenants on sc.CustomerTenantId equals ten.Id
															   where cas.CustomerUserId == cu.Id
															   select ten.Name).FirstOrDefault(),
										 UserName = cu.UserName,
										 CustomerUserGroupName = string.Join(", ", (from sc in context.CustomerUserGroups
																					join cas in context.CustomerUserAssignGroups on sc.Id equals cas.CustomerUserGroupId
																					where cas.CustomerUserId == cu.Id
																					select sc.GroupName).ToArray()),
										 IsActive = cu.IsActive,
										 IsAdmin = cu.IsAdmin,
										 SelectedCustomerUserGroupData = context.CustomerUserAssignGroups.Where(f => f.CustomerUserId == cu.Id)
																		.Select(p => p.CustomerUserGroupId).ToArray(),
										 LastLogin = (from user in context.UserTracks where user.UserEmail == cu.UserName select user.DateTimeLog).OrderByDescending(od=>od.Value).FirstOrDefault()
									 }).ToList();


				return customerUsers;
			}
		}

		public async Task<List<CustomerUserGroupRoleModel>> GetUseRolesByCustomerTenantId(int customerTenantid, int customerGroupId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUserGroupRoles = (from cur in context.CustomerUserRoles
											  join ct in context.CustomerTenants on cur.CustomerTernantId equals ct.Id
											  where cur.IsActive == true && ct.IsActive == true
													 && (ct.Id == customerTenantid || customerTenantid == 0)
											  select new CustomerUserGroupRoleModel
											  {
												  Id = 0,
												  CustomerUserGroupId = 0,
												  GroupName = String.Empty,
												  CustomerTenantId = ct.Id,
												  CustomerTenantName = ct.Name,
												  RoleCode = cur.Code,
												  CustomerUserRoleId = cur.Id,
												  UserRoleName = cur.UserRoleName,
												  Description = cur.Description,
											  }).OrderBy(x => x.RoleCode).ToList();

				if (customerGroupId > 0)
				{
					var customerUserRoleGroup = context.CustomerUserGroupRoles.Where(x => x.CustomerUserGroupId == customerGroupId).ToList();
					customerUserGroupRoles = customerUserGroupRoles.Where(x => !customerUserRoleGroup.Any(c => c.CustomerUserRoleId == x.CustomerUserRoleId)).ToList();
					return customerUserGroupRoles;
				}

				return customerUserGroupRoles;
			}
		}

		public async Task<List<CustomerUserGroupRoleModel>> GetAppliedUserRolesByCustomerCustomerGroupId(int customerGroupId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUserGroupRoles = (from cur in context.CustomerUserRoles
											  join ct in context.CustomerTenants on cur.CustomerTernantId equals ct.Id
											  join cg in context.CustomerUserGroupRoles on cur.Id equals cg.CustomerUserRoleId
											  join cgs in context.CustomerUserGroups on cg.CustomerUserGroupId equals cgs.Id
											  where cur.IsActive == true && ct.IsActive == true && cgs.IsActive == true
													 && (cgs.Id == customerGroupId)
											  select new CustomerUserGroupRoleModel
											  {
												  Id = cg.Id,
												  CustomerUserGroupId = cg.CustomerUserGroupId,
												  GroupName = cgs.GroupName,
												  CustomerTenantId = ct.Id,
												  CustomerTenantName = ct.Name,
												  RoleCode = cur.Code,
												  CustomerUserRoleId = cur.Id,
												  UserRoleName = cur.UserRoleName,
												  Description = cur.Description,
												  WorkspaceUrl = ct.WorkspaceUrl,
												  ProfileId = ct.ProfileId,
												  ViewViewAllReport = cgs.ViewAllReport
											  }).OrderBy(x => x.RoleCode).ToList();

				return customerUserGroupRoles;
			}
		}



		public async Task<List<CustomerTenantModel>> GetAllCustomerTenants()
		{
			using (var context = new DataAnalyticsDBContext())
			{
				return context.CustomerTenants
			.Where(x => x.IsActive == true)
			.Select(x => new CustomerTenantModel
			{
				Id = x.Id,
				Name = x.Name,
				IsActive = x.IsActive,
				WorkspaceId = x.WorkspaceId,
				WorkspaceUrl = x.WorkspaceUrl,
				ProfileId = x.ProfileId,
			}).ToList();
			}

		}

		public async Task<List<CustomerTenantModel>> GetAllCustomerTenantsByUserName(string userName)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				if (!userName.ToLower().Contains("qualiticks"))
				{
					return (from cu in context.CustomerUsers
							join cag in context.CustomerUserAssignGroups on cu.Id equals cag.CustomerUserId
							join cg in context.CustomerUserGroups on cag.CustomerUserGroupId equals cg.Id
							join ct in context.CustomerTenants on cg.CustomerTenantId equals ct.Id
							where cu.UserName == userName
							&& cu.IsActive == true
							&& cg.IsActive == true
							&& ct.IsActive == true
							select new CustomerTenantModel
							{
								Id = ct.Id,
								Name = ct.Name,
								WorkspaceId = ct.WorkspaceId,
								WorkspaceUrl = ct.WorkspaceUrl,
								ProfileId = ct.ProfileId,
								IsActive = ct.IsActive,
							}).Distinct().ToList();
				}
				else
				{
					return await GetAllCustomerTenants();

				}
			}

		}

		public async Task<List<CustomerUserGroupModel>> GetCustomerGroupTenants(int customerTenantId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				return context.CustomerUserGroups
			.Where(x => x.IsActive == true && (x.CustomerTenantId == customerTenantId || customerTenantId == 0))
			.Select(x => new CustomerUserGroupModel
			{
				Id = x.Id,
				GroupName = x.GroupName,
				IsActive = x.IsActive,
				CustomerTenantId = x.CustomerTenantId,
				ViewAllReport = x.ViewAllReport,
				CustomerTenantSID = x.CustomerTenantSID
			}).ToList();
			}

		}

		public async Task<CustomerTenantModel> GetCustomerTenants(int? customerTenantId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				return context.CustomerTenants
			.Where(x => x.IsActive == true && (x.Id == customerTenantId || customerTenantId == 0))
			.Select(x => new CustomerTenantModel
			{
				Id = x.Id,
				Name = x.Name,
				IsActive = x.IsActive,
				WorkspaceId = x.WorkspaceId,
				WorkspaceUrl = x.WorkspaceUrl,
				ProfileId = x.ProfileId
			}).FirstOrDefault();
			}

		}
		public async Task<CustomerUserModel> UpsertCustomerUsers(CustomerUserModel model)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUserDB = context.CustomerUsers.Where(x => x.Id == model.Id).FirstOrDefault();

				if (customerUserDB != null)
				{
					customerUserDB.UserName = model.UserName;
					customerUserDB.IsAdmin = model.IsAdmin;
				}
				else
				{
					customerUserDB = new CustomerUser
					{
						UserName = model.UserName,
						DateCreated = DateTime.Now,
						IsAdmin = model.IsAdmin,
						IsActive = true
					};

					context.CustomerUsers.Add(customerUserDB);
				}

				await context.SaveChangesAsync();
				model.Id = customerUserDB.Id;

				return model;
			}
		}

		public async Task UpsertCustomerAssignGroup(int customerUserId, List<int?> customerUserGroupIds)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				if (customerUserGroupIds != null || customerUserGroupIds.Count > 0)
				{
					var customerUserAssignGroupsDb = context.CustomerUserAssignGroups.Where(x => x.CustomerUserId == customerUserId && !customerUserGroupIds.Any(c => c == x.CustomerUserGroupId)).ToList();
					if (customerUserAssignGroupsDb.Any())
					{
						context.CustomerUserAssignGroups.RemoveRange(customerUserAssignGroupsDb);
					}

					foreach (var id in customerUserGroupIds)
					{
						var customerUserAssignGroupDb = context.CustomerUserAssignGroups.FirstOrDefault(x => x.CustomerUserId == customerUserId && x.CustomerUserGroupId == id);
						if (customerUserAssignGroupDb == null)
						{
							context.CustomerUserAssignGroups.Add(new CustomerUserAssignGroup { CustomerUserId = customerUserId, CustomerUserGroupId = id });
						}
					}
					await context.SaveChangesAsync();
				}
			}
		}

		public async Task DeleteCustomerUser(int customerUserId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUserDB = context.CustomerUsers.Where(x => x.Id == customerUserId).FirstOrDefault();

				if (customerUserDB != null)
				{
					customerUserDB.IsActive = false;
					await context.SaveChangesAsync();
				}
			}
		}

		public async Task AppliedRoleInCustomerUserGroup(int? customerUserGroupId, int? customerUserRoleId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUserGroupRoles = context.CustomerUserGroupRoles.Where(x => x.CustomerUserGroupId == customerUserGroupId && x.CustomerUserRoleId == customerUserRoleId).FirstOrDefault();

				if (customerUserGroupRoles == null)
				{
					var newCustomerUserGroupRoles = new CustomerUserGroupRole
					{
						CustomerUserGroupId = customerUserGroupId,
						CustomerUserRoleId = customerUserRoleId
					};
					context.CustomerUserGroupRoles.Add(newCustomerUserGroupRoles);
					await context.SaveChangesAsync();
				}
			}
		}

		public async Task DeleteRoleInCustomerUserGroup(int? customerUserGroupRolesId)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUserGroupRoles = context.CustomerUserGroupRoles.Where(x => x.Id == customerUserGroupRolesId).FirstOrDefault();

				if (customerUserGroupRoles != null)
				{
					context.CustomerUserGroupRoles.Remove(customerUserGroupRoles);
					await context.SaveChangesAsync();
				}
			}
		}

		public async Task<CustomerTenantModel> UpsertCustomerTenant(CustomerTenantModel customerTenantModel)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerTenantDB = context.CustomerTenants.Where(x => x.Id == customerTenantModel.Id).FirstOrDefault();

				if (customerTenantDB == null)
				{
					customerTenantDB = new CustomerTenant
					{
						IsActive = customerTenantModel.IsActive,
						Name = customerTenantModel.Name,
						WorkspaceId = customerTenantModel.WorkspaceId,
						WorkspaceUrl = customerTenantModel.WorkspaceUrl,
						ProfileId = customerTenantModel.ProfileId,
					};

					context.CustomerTenants.Add(customerTenantDB);
				}
				else
				{
					customerTenantDB.IsActive = customerTenantModel.IsActive;
					customerTenantDB.Name = customerTenantModel.Name;
					customerTenantDB.WorkspaceId = customerTenantModel.WorkspaceId;
				}

				await context.SaveChangesAsync();
				customerTenantModel.Id = customerTenantDB.Id;

				return customerTenantModel;
			}
		}


		public async Task<CustomerUserGroupModel> UpsertCustomerUserGroup(CustomerUserGroupModel customerUserGroupModel)
		{
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUserGroupDB = context.CustomerUserGroups.Where(x => x.Id == customerUserGroupModel.Id).FirstOrDefault();

				if (customerUserGroupDB == null)
				{
					customerUserGroupDB = new CustomerUserGroup
					{
						IsActive = customerUserGroupModel.IsActive,
						GroupName = customerUserGroupModel.GroupName,
						CustomerTenantId = customerUserGroupModel.CustomerTenantId,
						ViewAllReport = customerUserGroupModel.ViewAllReport,
						CustomerTenantSID = customerUserGroupModel.CustomerTenantSID
					};

					context.CustomerUserGroups.Add(customerUserGroupDB);
				}
				else
				{
					customerUserGroupDB.IsActive = customerUserGroupModel.IsActive;
					customerUserGroupDB.GroupName = customerUserGroupModel.GroupName;
					customerUserGroupDB.CustomerTenantId = customerUserGroupModel.CustomerTenantId;
					customerUserGroupDB.ViewAllReport = customerUserGroupModel.ViewAllReport;
					customerUserGroupDB.CustomerTenantSID = customerUserGroupModel.CustomerTenantSID;
				}
				try
				{
					customerUserGroupModel.Id = customerUserGroupDB.Id;
					await context.SaveChangesAsync();
				}
				catch (Exception ex) { }

				return customerUserGroupModel;
			}
		}

		public async Task<string> InsertCustomerUserRoleByName(CustomerUserRole customerUserRole)
        {
			using (var context = new DataAnalyticsDBContext())
			{
				var customerUserRoleDB = context.CustomerUserRoles.Where(x => x.UserRoleName == customerUserRole.UserRoleName
									&& x.CustomerTernantId == customerUserRole.CustomerTernantId).FirstOrDefault();

				if (customerUserRoleDB == null)
				{
					int lstId = context.CustomerUserRoles.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
					customerUserRoleDB = new CustomerUserRole
					{
						IsActive = true,
						Description = customerUserRole.Description,
						CustomerTernantId = customerUserRole.CustomerTernantId,
						UserRoleName = customerUserRole.UserRoleName,
						Code = $"RP{lstId.ToString()}"
					};

					var record = context.CustomerUserRoles.Add(customerUserRoleDB);
					await context.SaveChangesAsync();

					customerUserRoleDB.Code = $"RP{customerUserRoleDB.Id.ToString()}";
					await context.SaveChangesAsync();

				}

				return customerUserRoleDB.Code ?? String.Empty;
			}
		}

	}
}
