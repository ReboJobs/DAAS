using Microsoft.PowerBI.Api.Models;

namespace BlazorDataAnalytics.Data
{
	public class PowerBIEmbedConfig
	{
		public string Id { get; set; }
		public EmbedToken EmbedToken { get; set; }
		public string EmbedUrl { get; set; }
	}
}
