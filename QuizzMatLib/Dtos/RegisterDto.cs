using System.ComponentModel.DataAnnotations;

namespace QuizzMatLib.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
