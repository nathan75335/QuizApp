using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLedi.DataAccess.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public TimeSpan TimeLimit { get; set; }
        public QuizCategory QuizCategory { get; set; }
        public int QuizCategoryId { get; set; }
        public double MaxScore { get; set; }
        public List<Question> Questions { get; set; }
        //public UserQuiz UserQuiz { get; set; }
        //public int UserQuizId { get; set; }

    }
}
