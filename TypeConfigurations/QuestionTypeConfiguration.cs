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
            builder.Property(e => e.EmailValidation)
                .HasComment("Si ce champ est non null, il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.")
                .HasMaxLength(256);
            builder.HasMany(e => e.Reponses);
            builder.Property(e => e.Niveau).HasMaxLength(30);
            builder.HasIndex(e => e.Niveau);
            builder.ToTable(t => t.HasCheckConstraint("CK_niveau_is_correct",
                "Niveau IN ('Debutant', 'Intermediaire', 'Avance')")
            );
        }
    }
}
