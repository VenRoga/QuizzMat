using System.ComponentModel.DataAnnotations;
using QuizzMatLib.BaseModelsEnums;

namespace QuizzMatApi.Data.BaseModels
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public int QuizzId { get; set; }

        public Quizz Quizz { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(2000)]
        public string Text { get; set; }

        public QuestionType Type { get; set; } = QuestionType.SingleChoice;

        public int Points { get; set; }

        public int OrderIndex {  get; set; }

        public ICollection<AnswerOption> Options { get; set; }
    }
}

