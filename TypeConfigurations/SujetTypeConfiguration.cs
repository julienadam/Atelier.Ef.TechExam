using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Ef.TechExam.TypeConfigurations
{
    class SujetTypeConfiguration : IEntityTypeConfiguration<Sujet>
    {
        public void Configure(EntityTypeBuilder<Sujet> builder)
        {
            builder.Property(e => e.Titre).HasMaxLength(50);
            builder.HasMany(e => e.Questions);
            builder
                .HasMany<ParametrageExamen>()
                .WithOne(e => e.Sujet)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasIndex(e => e.Titre).IsUnique();
        }
    }
}
