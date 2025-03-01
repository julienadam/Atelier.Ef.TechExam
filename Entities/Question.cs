namespace Atelier.Ef.TechExam.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public required string Contenu { get; set; }

        public Niveau Niveau { get; set; }

        public List<Sujet> Sujets { get; set; } = [];
    }

    public enum Niveau
    {
        Debutant,
        Intermediaire,
        Avance
    }
}
