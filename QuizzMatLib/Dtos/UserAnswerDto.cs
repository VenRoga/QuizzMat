using QuizzMatLib.BaseModelsEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace QuizzMatLib.Dtos
{
    public class UserAnswerDto
    {
         
    }

    public class QuizzShowDto
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Reward { get; set; }
        public int QuestionsCount { get; set; }
    } 

    public class QuizzAttemptDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Reward { get; set; }
        public List<QuizzAttemptDto> Questions { get; set; } = new();
    }

    public class QuestionShowDto
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(2000)]
        public string Text { get; set; }

        public QuestionType Type { get; set; } = QuestionType.SingleChoice;

        public int Points { get; set; }

        public int OrderIndex { get; set; }

        public ICollection<AnswerOptionDto> Options { get; set; }
    }

    public class AnswerOptionDto
    {

    }
}
