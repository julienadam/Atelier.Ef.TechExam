﻿using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Ef.TechExam.TypeConfigurations
{
    class SujetTypeConfiguration : IEntityTypeConfiguration<Sujet>
    {
        public void Configure(EntityTypeBuilder<Sujet> builder)
        {
            builder.Property(e => e.Titre).HasMaxLength(50);
        }
    }
}
