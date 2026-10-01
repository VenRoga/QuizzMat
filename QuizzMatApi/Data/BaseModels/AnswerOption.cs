using System.ComponentModel.DataAnnotations;

namespace QuizzMatApi.Data.BaseModels
{
    public class AnswerOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        public bool IsCorrect { get; set; }

        public int OrderIndex { get; set; }
    }
}
