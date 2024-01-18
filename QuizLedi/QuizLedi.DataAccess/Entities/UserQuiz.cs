namespace QuizLedi.DataAccess.Entities
{
    public class UserQuiz
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
    }
}
