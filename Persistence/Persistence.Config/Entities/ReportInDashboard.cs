using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Config.Entities
{
    [Table("ReportInDashboard")]
    public partial class ReportInDashboard
    {
        public ReportInDashboard()
        {
            Likes = new HashSet<Like>();
        }

        [Key]
        [Column("reportDBID")]
        public int ReportDbid { get; set; }

        [StringLength(255)]
        [Unicode(false)]
        public string? Title { get; set; }

        [StringLength(255)]
        [Unicode(false)]
        public string? Tags { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? UserRoleCode { get; set; }

        public Guid? ReportPowerBiId { get; set; }
        [Required]
        public bool? IsActive
        {
            get; set;
        }

        [InverseProperty("ReportDb")]
        public virtual ICollection<Like> Likes { get; set; }

        [InverseProperty("ReportDb")]
        public virtual ICollection<Bookmark>? Bookmarks { get; set; }
    }
}
