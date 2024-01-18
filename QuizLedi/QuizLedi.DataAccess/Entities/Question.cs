namespace QuizLedi.DataAccess.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public double Point { get; set; }
        public List<Assertion> Assertions { get; set; }
    }
}
