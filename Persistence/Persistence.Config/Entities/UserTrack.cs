using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class UserTrack
    {
        public int TrackId { get; set; }
        public string? Ip { get; set; }
        public string? UserName { get; set; }
        public DateTime? DateTimeLog { get; set; }
        public string? Browser { get; set; }
        public string? Page { get; set; }
        public string? ReportName { get; set; }
        public string? UserEmail { get; set; }
    }
}
