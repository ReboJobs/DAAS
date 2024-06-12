using BlazorDataAnalytics.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
	public class CommonEnumModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public byte? ConnectorTypeId { get; set; }

		public string Checked { get; set; }
	}
}