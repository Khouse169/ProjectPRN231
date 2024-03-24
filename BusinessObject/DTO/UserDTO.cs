using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? Username { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public decimal? Balance { get; set; }
        public bool? IsActive { get; set; }
    }
}
