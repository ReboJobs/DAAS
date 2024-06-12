using BlazorDataAnalytics.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
	public class ReportBugSearchModel
	{
		public string Text { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public EnumReportBugStatus ReportBugStatus { get; set; }
		public string ReportedBy { get; set; }

	}
}