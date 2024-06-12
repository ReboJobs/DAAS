using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class CustomerUserGroup
    {
        public CustomerUserGroup()
        {
            CustomerUserAssignGroups = new HashSet<CustomerUserAssignGroup>();
            CustomerUserGroupRoles = new HashSet<CustomerUserGroupRole>();
        }

        public int Id { get; set; }
        public int? CustomerTenantId { get; set; }
        public string? GroupName { get; set; }
        public bool? IsActive { get; set; }
        public bool? ViewAllReport { get; set; }
        public string? CustomerTenantSID { get; set; }

        public virtual CustomerTenant? CustomerTenant { get; set; }
        public virtual ICollection<CustomerUserAssignGroup>? CustomerUserAssignGroups { get; set; }
        public virtual ICollection<CustomerUserGroupRole>? CustomerUserGroupRoles { get; set; }
    }
}
