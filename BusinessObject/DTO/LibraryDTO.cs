using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class LibraryDTO
    {
        public int LibraryId { get; set; }
        public int? UserId { get; set; }
        public int? StoryId { get; set; }

    }
}
