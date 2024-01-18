namespace QuizLedi.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Score> Scores { get; set; }

    }
}
