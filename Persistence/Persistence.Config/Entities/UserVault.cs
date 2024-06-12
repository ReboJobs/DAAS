using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class UserVault
    {
        public int Id { get; set; }
        public byte? SystemId { get; set; }
        public string? Description { get; set; }
        public string? ContentType { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsActive { get; set; }
        public int? CustomerTenantId { get; set; }
    }
}
