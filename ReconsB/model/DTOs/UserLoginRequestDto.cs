using System.ComponentModel.DataAnnotations;

namespace ReconsB.model.DTOs
{
    public class UserLoginRequestDto
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
