using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Ef.TechExam.TypeConfigurations
{
    class QuestionChoixMultipleTypeConfiguration : IEntityTypeConfiguration<QuestionChoixMultiple>
    {
        public void Configure(EntityTypeBuilder<QuestionChoixMultiple> builder)
        {
            builder.HasMany(e => e.Reponses);
        }
    }

}
