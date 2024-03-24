using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Libraries = new HashSet<Library>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public decimal? Balance { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
    }
}
