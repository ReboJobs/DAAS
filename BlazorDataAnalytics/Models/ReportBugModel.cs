using BlazorDataAnalytics.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
	public class ReportBugModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter {0}.")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Please enter {0}.")]
		public string? Description { get; set; }
		public DateTime? DateReported { get; set; }
		public string ReportedBy { get; set; }
		public EnumReportBugStatus? ReportBugStatus { get; set; }
		public string? ImageBlobURL { get; set; }
		public string ReportBugStatusName
		{
			get
			{

				return ((Enum)Enum.Parse(typeof(EnumReportBugStatus), ReportBugStatus.ToString())).GetDescription();
			}
		}
		public bool? IsActive { get; set; }

	}
}