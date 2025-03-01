namespace Atelier.Ef.TechExam.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public required string Contenu { get; set; }
       

        public required string Niveau { get; set; }

        public List<Sujet> Sujets { get; set; } = [];
    }
}
