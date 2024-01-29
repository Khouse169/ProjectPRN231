using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Stories = new HashSet<Story>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Story> Stories { get; set; }
    }
}
