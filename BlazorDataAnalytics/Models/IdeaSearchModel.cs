using BlazorDataAnalytics.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
	public class IdeaSearchModel
	{
		public string Text { get; set; }
		public string UserName { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }

	}
}