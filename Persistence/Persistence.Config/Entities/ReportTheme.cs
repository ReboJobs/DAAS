using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Config.Entities
{
	public partial class ReportThemes
	{
		public int ID { get; set; }
		public int? CustomerTenantId { get; set; }
		public string? Theme { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int? ReportDBID { get; set; }
		public bool? IsDefaultTheme { get; set; }
		public string? CreatorUserName { get; set; }
		public string? ThemeName { get; set; }

	}
}
