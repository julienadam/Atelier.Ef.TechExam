﻿// <auto-generated />
using System;
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
    [Migration("20250301102602_AddedQuestionSujetRelation")]
    partial class AddedQuestionSujetRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Atelier.Ef.TechExam.Entities.ParametrageExamen", b =>
                {
                    b.Property<Guid>("ParametrageExamenId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Contient l'identifiant de l'offre d'emploi en provenance du système RH amont. La valeur n'est pas générée par le système et doit être spécifiée côté client.");

                    b.Property<int>("DureeMinutes")
                        .HasColumnType("int");

                    b.Property<int>("PourcentageAvance")
                        .HasColumnType("int");

                    b.Property<int>("PourcentageDebutant")
                        .HasColumnType("int");

                    b.Property<int>("PourcentageIntermediaire")
                        .HasColumnType("int");

                    b.Property<int>("QuestionsLibres")
                        .HasColumnType("int");

                    b.HasKey("ParametrageExamenId");

                    b.ToTable("ParametragesExamen");
                });

            modelBuilder.Entity("Atelier.Ef.TechExam.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("EmailValidation")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasComment("Si ce champ est non null, il s'agit d'une question libre dont la validation doit être faite par la personne reçevant cet email.");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Atelier.Ef.TechExam.Entities.Reponse", b =>
                {
                    b.Property<int>("ReponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReponseId"));

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("Correcte")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("ReponseId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Reponses");
                });

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

            modelBuilder.Entity("QuestionSujet", b =>
                {
                    b.Property<int>("QuestionsQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("SujetsSujetId")
                        .HasColumnType("int");

                    b.HasKey("QuestionsQuestionId", "SujetsSujetId");

                    b.HasIndex("SujetsSujetId");

                    b.ToTable("QuestionSujet");
                });

            modelBuilder.Entity("Atelier.Ef.TechExam.Entities.Reponse", b =>
                {
                    b.HasOne("Atelier.Ef.TechExam.Entities.Question", "Question")
                        .WithMany("Reponses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuestionSujet", b =>
                {
                    b.HasOne("Atelier.Ef.TechExam.Entities.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atelier.Ef.TechExam.Entities.Sujet", null)
                        .WithMany()
                        .HasForeignKey("SujetsSujetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Atelier.Ef.TechExam.Entities.Question", b =>
                {
                    b.Navigation("Reponses");
                });
#pragma warning restore 612, 618
        }
    }
}
