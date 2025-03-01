using Atelier.Ef.TechExam.Domain;

namespace Atelier.Ef.TechExam.Entities
{
    public class VentilationParNiveaux
    {
        public required StrictIntPercent PourcentageDebutant { get; set; }
        public required StrictIntPercent PourcentageIntermediaire { get; set; }
        public required StrictIntPercent PourcentageAvance { get; set; }
    }
}
