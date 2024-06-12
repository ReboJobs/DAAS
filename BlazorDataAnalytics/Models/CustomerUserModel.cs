using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
    public class CustomerUserModel
    {
        public int Id { get; set; }
        [Required]
        public int? CustomerTenantId { get; set; }

        public string? CustomerTenantName { get; set; }
        [Required]
        public string? UserName { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }

        [Required]
        public int?[] SelectedCustomerUserGroupData { get; set; } = new int?[] { };
        public string? CustomerUserGroupName { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
