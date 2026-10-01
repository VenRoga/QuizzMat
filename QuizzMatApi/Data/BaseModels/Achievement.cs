using System.ComponentModel.DataAnnotations;

namespace QuizzMatApi.Data.BaseModels
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }
        public string? IconUrl { get; set; }

        public ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
