using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class IdeaVoteDetail
    {
        public int Id { get; set; }
        public int? IdeaId { get; set; }
        public string? VotedBy { get; set; }
        public DateTime? DateVoted { get; set; }
        public bool? IsActive { get; set; }

        public virtual Idea? Idea { get; set; }
    }
}
