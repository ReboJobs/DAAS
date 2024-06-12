namespace BlazorDataAnalytics.Models
{
	public class ReportThemeModel
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
