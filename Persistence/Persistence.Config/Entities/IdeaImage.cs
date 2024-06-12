using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class IdeaImage
    {
        public int Id { get; set; }
        public int? IdeaId { get; set; }
        public string? FileName { get; set; }
        public string? ImageBlobUrl { get; set; }
        public string? UserName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
