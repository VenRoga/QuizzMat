using Microsoft.EntityFrameworkCore;
using QuizzMatApi.Data.BaseModels;
using QuizzMatApi.Data.Seed;

namespace QuizzMatApi.Data.BaseModelsContext
{
    public class BaseModelsContext : DbContext
    {
        public BaseModelsContext(DbContextOptions<BaseModelsContext> options) : base(options)
        {
        }

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quizz>Quizzes { get; set; }
        public DbSet<QuizzAttempt> QuizzAttempts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseModelsContext).Assembly);

            modelBuilder.Entity<Achievement>().HasData(AchievementSeed.GetData());
        }
    }
}
