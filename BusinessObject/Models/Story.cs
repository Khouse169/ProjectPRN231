using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Story
    {
        public Story()
        {
            Chapters = new HashSet<Chapter>();
            Comments = new HashSet<Comment>();
            Libraries = new HashSet<Library>();
        }

        public int StoryId { get; set; }
        public string Title { get; set; } = null!;
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }
        public int? GenreId { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? PublishDate { get; set; }
        public byte? IsDelete { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
    }
}
