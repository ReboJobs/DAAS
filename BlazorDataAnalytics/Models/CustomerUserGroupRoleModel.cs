namespace BlazorDataAnalytics.Models
{
    public class CustomerUserGroupRoleModel
    {
        public int Id { get; set; }
        public int? CustomerTenantId { get; set; }
        public string? CustomerTenantName { get; set; }
        public int? CustomerUserGroupId { get; set; }
        public string? GroupName { get; set; }
        public int? CustomerUserRoleId { get; set; }
        public string? RoleCode { get; set; }
        public string? UserRoleName { get; set; }
        public string? Description { get; set; }
        public string WorkspaceUrl { get; set; }
        public int? ProfileId { get; set; }
        public bool? ViewViewAllReport { get; set; }


    }
}
