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

            builder.HasOne(e => e.Sujet);
        }
    }
}
