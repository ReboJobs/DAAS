using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class User
    {
        public User()
        {
            Bookmarks = new HashSet<Bookmark>();
            Likes = new HashSet<Like>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateTimeLogin { get; set; }
    }
}
