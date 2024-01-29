using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Chapter
    {
        public int ChapterId { get; set; }
        public int? StoryId { get; set; }
        public int? ChapterNumber { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public virtual Story? Story { get; set; }
    }
}
