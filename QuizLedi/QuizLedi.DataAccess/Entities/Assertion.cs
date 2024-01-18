namespace QuizLedi.DataAccess.Entities
{
    public class Assertion
    {
        public int Id { get; set; }
        public string AssertionText { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
