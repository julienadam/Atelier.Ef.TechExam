using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Ef.TechExam.TypeConfigurations
{
    class QuestionLibreTypeConfiguration : IEntityTypeConfiguration<QuestionLibre>
    {
        public void Configure(EntityTypeBuilder<QuestionLibre> builder)
        {
            builder.Property(e => e.EmailValidation)
               .HasComment("Il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.")
               .HasMaxLength(256);
        }
    }

}
