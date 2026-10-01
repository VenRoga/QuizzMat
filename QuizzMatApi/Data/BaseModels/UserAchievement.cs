using Microsoft.EntityFrameworkCore;

namespace QuizzMatApi.Data.BaseModels
{
    [PrimaryKey(nameof(UserId), nameof(AchievementId))]
    public class UserAchievement
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int AchievementId { get; set; }

        public Achievement Achievement { get; set; } = null!;
    }
}
