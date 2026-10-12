using System.ComponentModel.DataAnnotations;

namespace QuizzMatLib.Dtos
{
    public class ChangeEmailDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required, EmailAddress]
        public string NewEmail { get; set; }

        [Required, EmailAddress]
        [Compare(nameof(NewEmail), ErrorMessage = "Emails do not match")]
        public string ConfirmNewEmail { get; set; }
    }
}
