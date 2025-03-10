﻿// <auto-generated />
using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Atelier.Ef.TechExam.Migrations
{
    [DbContext(typeof(TechExamContext))]
    [Migration("20250301095012_MaxLength50OnSujetTitre")]
    partial class MaxLength50OnSujetTitre
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Atelier.Ef.TechExam.Entities.Sujet", b =>
                {
                    b.Property<int>("SujetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SujetId"));

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SujetId");

                    b.ToTable("Sujets");
                });
#pragma warning restore 612, 618
        }
    }
}
