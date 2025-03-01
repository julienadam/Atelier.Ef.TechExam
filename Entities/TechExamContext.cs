﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Atelier.Ef.TechExam.Entities;

public partial class TechExamContext : DbContext
{
    public DbSet<Sujet> Sujets { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<ParametrageExamen> ParametragesExamen { get; set; }

    public TechExamContext()
    {
    }

    public TechExamContext(DbContextOptions<TechExamContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TechExam;Integrated Security=True;Application Name=EntityFramework; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
