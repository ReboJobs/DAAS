using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Config.Entities
{
    [Table("CustomerUserGroupRole")]
    public partial class CustomerUserGroupRole
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerUserGroupId { get; set; }
        public int? CustomerUserRoleId { get; set; }

        [ForeignKey("CustomerUserGroupId")]
        [InverseProperty("CustomerUserGroupRoles")]
        public virtual CustomerUserGroup? CustomerUserGroup { get; set; }
        [ForeignKey("CustomerUserRoleId")]
        [InverseProperty("CustomerUserGroupRoles")]
        public virtual CustomerUserRole? CustomerUserRole { get; set; }
    }
}
