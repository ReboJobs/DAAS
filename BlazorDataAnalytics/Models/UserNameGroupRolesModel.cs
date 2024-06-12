namespace BlazorDataAnalytics.Models
{
    public class UserNameGroupRolesModel
    {
        public string UserName { get; set; }   
        public int CustomerTenantId { get; set; }

        public Guid WorkspaceId { get; set; }
        public bool IsAdmin { get; set; }
        public bool ViewAllReport { get; set; }
        public List<CustomerUserRoleModel> CustomerUserRoles { get; set; }
        public string? CustomerName { get; set; }
        public string? WorkspaceUrl { get; set; }

        public UserNameGroupRolesModel()
        {
            this.CustomerUserRoles = new List<CustomerUserRoleModel>();
        }

    }

  

}
