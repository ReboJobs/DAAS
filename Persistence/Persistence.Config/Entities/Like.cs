using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class Like
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ReportDbid { get; set; }
        public string? Title { get; set; }
        public bool? IsLike { get; set; }
        public int? CustomerTenantId { get; set; }

        public virtual ReportInDashboard? ReportDb { get; set; }
        public virtual User? User { get; set; }
    }
}
