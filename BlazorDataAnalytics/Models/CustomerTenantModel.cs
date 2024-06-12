using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
    public class CustomerTenantModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        [Required]
        public Guid? WorkspaceId { get; set; }
        public string? WorkspaceUrl { get; set; }
        public int? ProfileId { get; set; }


    }
}
