using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class CustomerUserAssignGroup
    {
        public int Id { get; set; }
        public int? CustomerUserId { get; set; }
        public int? CustomerUserGroupId { get; set; }

        public virtual CustomerUser? CustomerUser { get; set; }
        public virtual CustomerUserGroup? CustomerUserGroup { get; set; }
    }
}
