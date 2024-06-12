using BlazorDataAnalytics.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorDataAnalytics.Models
{
	public class IdeaVoteModel
    {
        public int Id { get; set; }
        public int? IdeadId { get; set; }
        public string? VotedBy { get; set; }
        public DateTime? DateVoted { get; set; }
        public bool? IsActive { get; set; }


    }
}