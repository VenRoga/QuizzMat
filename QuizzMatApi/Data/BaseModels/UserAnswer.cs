using QuizzMatApi.Data.BaseModels;
using System.ComponentModel.DataAnnotations;
public class UserAnswer
{
    [Key]
    public int Id { get; set; }

    public int AttemptId { get; set; }
    public QuizzAttempt Attempt { get; set; } = null!;

    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    public ICollection<AnswerOption> SelectedOptions { get; set; }
    public bool IsCorrect { get; set; }        
    public int PointsAwarded { get; set; }   
}