
using System.Text.Json.Serialization;

namespace BlazorDataAnalytics.Models
{
    public class UserTracks
    {
        [JsonPropertyName("ip")]
        public string IP { get; set; }
        public string UserName { get; set; }

        public string userEmail { get; set; }

        public string Browser { get; set; }

        public DateTime DateTimeLog { get; set; }

        public string Page { get; set; }

    }
}
