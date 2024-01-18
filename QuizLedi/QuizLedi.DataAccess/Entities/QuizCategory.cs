namespace QuizLedi.DataAccess.Entities
{
    public class QuizCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quiz> Quizzes { get; set; }
    }
}
