namespace Atelier.Ef.TechExam.Entities
{
    public class ParametrageExamen
    {
        /// <summary>
        /// Contient l'identifiant de l'offre d'emploi en provenance du système RH amont. La valeur n'est 
        /// pas générée par le système et doit être spécifiée côté client.
        /// </summary>
        public required Guid ParametrageExamenId { get; set; }
        public int PourcentageDebutant { get; set; }
        public int PourcentageIntermediaire { get; set; }
        public int PourcentageAvance { get; set; }
        public int DureeMinutes { get; set; }
        public int QuestionsLibres { get; set; }

        public int SujetId { get; set; }
        public Sujet Sujet { get; set; }
    }
}
