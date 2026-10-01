using System.ComponentModel.DataAnnotations;

namespace QuizzMatApi.Data.BaseModels
{
    public class Quizz
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Reward { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<QuizzAttempt> Attempts { get; set; }
    }

}

