using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using QuizzMatLib.BaseModelsEnums;

namespace QuizzMatApi.Data.BaseModels
{
    public class QuizzAttempt
    {
        [Key]
        public int Id { get; set; }
        public int QuizzId { get; set;  }
        public Quizz Quizz { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int? Score { get; set; }
        
        public int? MaxScore { get; set; }

        public AttemptStatus Status { get; set; } = AttemptStatus.InProgress;


        public ICollection<UserAnswer> Answers { get; set; }



    }
}
