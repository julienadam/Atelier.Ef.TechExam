using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Ef.TechExam.TypeConfigurations
{
    class QuestionTypeConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(e => e.Contenu).HasMaxLength(4000);
            builder.Property(e => e.Niveau)
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.HasIndex(e => e.Niveau);
            builder.ToTable(t => t.HasCheckConstraint("CK_niveau_is_correct",
                "Niveau IN ('Debutant', 'Intermediaire', 'Avance')")
            );
        }
    }
}
