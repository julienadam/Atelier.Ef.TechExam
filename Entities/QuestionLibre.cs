namespace Atelier.Ef.TechExam.Entities
{
    public class QuestionLibre : Question
    {
        /// <summary>
        /// Il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.
        /// </summary>
        public required string EmailValidation { get; set; }
    }
}
