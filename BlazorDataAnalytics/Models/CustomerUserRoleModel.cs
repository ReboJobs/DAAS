namespace BlazorDataAnalytics.Models
{
    public class CustomerUserRoleModel
    {

        public int Id { get; set; }
        public string? UserRoleName { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public int? CustomerTernantId { get; set; }        

    }
}
