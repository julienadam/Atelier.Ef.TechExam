using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Ef.TechExam.TypeConfigurations
{
    class PassageTypeConfiguration : IEntityTypeConfiguration<Passage>
    {
        public void Configure(EntityTypeBuilder<Passage> builder)
        {
            builder.Property(e => e.Statut)
                .HasConversion<string>()
                .HasMaxLength(30);

            builder
                .HasOne(e => e.ParametrageExamen)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
