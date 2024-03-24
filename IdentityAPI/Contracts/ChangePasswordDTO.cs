using System.ComponentModel.DataAnnotations;

namespace IdentityAPI.Contracts
{
    public class ChangePasswordDTO
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
