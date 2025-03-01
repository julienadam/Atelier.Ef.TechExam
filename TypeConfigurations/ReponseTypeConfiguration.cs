using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Ef.TechExam.TypeConfigurations
{
    class ReponseTypeConfiguration : IEntityTypeConfiguration<Reponse>
    {
        public void Configure(EntityTypeBuilder<Reponse> builder)
        {
            builder.Property(e => e.Contenu).HasMaxLength(1000);
            builder.HasOne(e => e.Question);
        }
    }
}
