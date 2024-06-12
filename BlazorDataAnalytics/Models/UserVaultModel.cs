using BlazorDataAnalytics.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
	public class UserVaultModel
	{
		public int? Id { get; set; }
		public EnumSystem System { get; set; }
		public string SystemName
		{
			get
			{

				return ((Enum)Enum.Parse(typeof(EnumSystem), System.ToString())).GetDescription();
			}
		}
		[Required]
		public byte? SystemNameId { get; set; }

		[Required]
		public byte? ConnectorTypeId { get; set; }
		public string? ConnectionString { get; set; }
		public string? Description { get; set; }
		public string? ContentType { get; set; }
		public int? CustomerTenantID { get; set; }
		public UserVaultAppDetailModel UserVaultAppDetail { get; set; } = new UserVaultAppDetailModel();

	}
}