using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Config.Entities
{
    [Table("CustomerTenant")]
    public partial class CustomerTenant
    {
        public CustomerTenant()
        {
            CustomerUserGroups = new HashSet<CustomerUserGroup>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public Guid? WorkspaceId { get; set; }
        public string? WorkspaceUrl { get; set; }
        public int? ProfileId { get; set; }

        [InverseProperty("CustomerTenant")]
        public virtual ICollection<CustomerUserGroup>? CustomerUserGroups { get; set; }
    }
}
