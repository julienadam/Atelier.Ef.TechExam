namespace Atelier.Ef.TechExam.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public required string Contenu { get; set; }
        /// <summary>
        /// Si ce champ est non null, il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.
        /// </summary>
        public string? EmailValidation { get; set; }

        public List<Reponse> Reponses { get; set; } = [];

        public List<Sujet> Sujets { get; set; } = [];
    }
}
