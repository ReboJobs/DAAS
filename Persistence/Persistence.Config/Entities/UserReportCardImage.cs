using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class UserReportCardImage
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? ReportDbid { get; set; }
        public string? ImageBlobUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
