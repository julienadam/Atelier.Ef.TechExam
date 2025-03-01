namespace Atelier.Ef.TechExam.Entities
{
    public class QuestionChoixMultiple : Question
    {
        public List<Reponse> Reponses { get; set; } = [];
    }
}
