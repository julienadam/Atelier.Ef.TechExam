namespace Atelier.Ef.TechExam.Entities
{
    public class Reponse
    {
        public int ReponseId { get; set; }
        public required string Contenu { get; set; }
        public bool Correcte { get; set; }

        public int QuestionId { get; set; }
        public required QuestionChoixMultiple Question { get; set; }
    }
}
