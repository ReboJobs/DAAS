using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Config.Entities
{
    [Table("Bookmark")]
    public partial class Bookmark
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("userID")]
        public int? UserId { get; set; }
        [Column("reportDBID")]
        public int? ReportDbid { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
        public string? state { get; set; }
        public string? DisplayName { get; set; }
        public string? ReportId { get; set; }

        [ForeignKey("ReportDbid")]
        [InverseProperty("Bookmarks")]
        public virtual ReportInDashboard? ReportDb { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Bookmarks")]
        public virtual User? User { get; set; }
    }
}
