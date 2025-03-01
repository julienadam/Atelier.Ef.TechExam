using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Ef.TechExam.TypeConfigurations
{
    class ParametrageExamenTypeConfiguration : IEntityTypeConfiguration<ParametrageExamen>
    {
        public void Configure(EntityTypeBuilder<ParametrageExamen> builder)
        {
            builder.HasKey(e => e.ParametrageExamenId);

            builder
                .Property(e => e.ParametrageExamenId)
                .HasComment("Contient l'identifiant de l'offre d'emploi en provenance du système RH amont. La valeur n'est pas générée par le système et doit être spécifiée côté client.")
                .ValueGeneratedNever();

            builder
                .OwnsOne(e => e.VentilationParNiveaux, b =>
                {
                    b.Property(t => t.PourcentageDebutant).HasColumnName(nameof(VentilationParNiveaux.PourcentageDebutant));
                    b.Property(t => t.PourcentageIntermediaire).HasColumnName(nameof(VentilationParNiveaux.PourcentageIntermediaire));
                    b.Property(t => t.PourcentageAvance).HasColumnName(nameof(VentilationParNiveaux.PourcentageAvance));
                }
                );

            builder.HasOne(e => e.Sujet);
            builder.ToTable(
                t => t.HasCheckConstraint("CK_percentages_are_correct",
                "PourcentageDebutant >= 0 AND PourcentageIntermediaire >= 0 AND PourcentageAvance >= 0 AND PourcentageDebutant + PourcentageIntermediaire + PourcentageAvance = 100")
            );
        }
    }
}
