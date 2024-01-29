using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? UserId { get; set; }
        public int? StoryId { get; set; }
        public string? CommentText { get; set; }

        public virtual Story? Story { get; set; }
        public virtual User? User { get; set; }
    }
}
