namespace Atelier.Ef.TechExam.Entities
{
    public class Sujet
    {
        public int SujetId { get; set; }
        public required string Titre { get; set; }

        public List<Question> Questions { get; set; } = [];
    }
}
