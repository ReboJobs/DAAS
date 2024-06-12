using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
    public class CustomerUserGroupModel
    {
        public int Id { get; set; }

        [Required]
        public int? CustomerTenantId { get; set; }

        [Required]
        public string? GroupName { get; set; }
        public bool? IsActive { get; set; }
        public bool? ViewAllReport { get; set; }
        public string? CustomerTenantSID { get; set; }
        
    }
}
