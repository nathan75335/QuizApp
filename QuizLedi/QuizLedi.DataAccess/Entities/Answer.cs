namespace QuizLedi.DataAccess.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Assertion Assertion { get; set; }
        public int AssertionId { get; set; }
    }
}
