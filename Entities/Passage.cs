using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Ef.TechExam.Entities
{
    public enum StatutPassage
    {
        NonPlanifie,
        Planifie,
        EnCours,
        Termine,
        Annule
    }

    public class Passage
    {
        public int PassageId { get; set; }
        public Guid ParametrageExamenId { get; set; }
        public ParametrageExamen ParametrageExamen { get; set; } = null!;
        public Guid CandidatId { get; set; }
        public DateTime? RendezVous { get; set; }
        public StatutPassage Statut { get; set; } = StatutPassage.NonPlanifie;
        public string? RaisonAnnulation { get; set; }
    }
}
