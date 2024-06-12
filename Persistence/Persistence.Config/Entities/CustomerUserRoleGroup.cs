using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Config.Entities
{
    public partial class CustomerUserRoleGroup
    {
        public int? Id { get; set; }
        public int? UserRoleName { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int? CustomerTernantId { get; set; }
        public bool? IsActive { get; set; }

    }
}
