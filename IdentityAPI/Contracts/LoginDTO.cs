using System.ComponentModel.DataAnnotations;

namespace IdentityAPI.Contracts
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
