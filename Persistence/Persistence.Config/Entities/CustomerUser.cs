using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class CustomerUser
    {
        public CustomerUser()
        {
            CustomerUserAssignGroups = new HashSet<CustomerUserAssignGroup>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<CustomerUserAssignGroup>? CustomerUserAssignGroups { get; set; }
    }
}
