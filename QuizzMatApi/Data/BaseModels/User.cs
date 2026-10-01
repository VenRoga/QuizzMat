using System.ComponentModel.DataAnnotations;
using QuizzMatLib.BaseModelsEnums;

namespace QuizzMatApi.Data.BaseModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string UserName { get; set; }

        [Required, MaxLength(20)]
        public string DisplayName { get; set; }

        [Required, MaxLength(150)]    
        public string Email { get; set; }

        [MaxLength(20)]
        public string? Mobile { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string? ProfileUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public UserRole Role { get; set; }

        public ICollection<QuizzAttempt> Attempts { get; set; }
        public ICollection<UserAchievement> Achievements { get; set; }
    }

}

