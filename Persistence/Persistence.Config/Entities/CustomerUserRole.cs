using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class CustomerUserRole
    {
        public CustomerUserRole()
        {
            CustomerUserGroupRoles = new HashSet<CustomerUserGroupRole>();
        }

        public int Id { get; set; }
        public string? UserRoleName { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public int? CustomerTernantId { get; set; }

        public virtual ICollection<CustomerUserGroupRole>? CustomerUserGroupRoles { get; set; }
    }
}
