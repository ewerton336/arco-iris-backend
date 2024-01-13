﻿// <auto-generated />
using System;
using Database.Context.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArcoIris.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240113175737_entidadeProva")]
    partial class entidadeProva
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("ArcoIris.Context.AppContext.Database.Context.Prova", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantidadeAcertos")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Provas");
                });

            modelBuilder.Entity("Database.Context.Alternativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Correta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestoId");

                    b.ToTable("Alternativas");
                });

            modelBuilder.Entity("Database.Context.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Matricula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Database.Context.Questao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Enunciado")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProvaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProvaId");

                    b.ToTable("Questoes");
                });

            modelBuilder.Entity("ArcoIris.Context.AppContext.Database.Context.Prova", b =>
                {
                    b.HasOne("Database.Context.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Database.Context.Alternativa", b =>
                {
                    b.HasOne("Database.Context.Questao", "Questao")
                        .WithMany("Alternativas")
                        .HasForeignKey("QuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("Database.Context.Questao", b =>
                {
                    b.HasOne("ArcoIris.Context.AppContext.Database.Context.Prova", null)
                        .WithMany("Questoes")
                        .HasForeignKey("ProvaId");
                });

            modelBuilder.Entity("ArcoIris.Context.AppContext.Database.Context.Prova", b =>
                {
                    b.Navigation("Questoes");
                });

            modelBuilder.Entity("Database.Context.Questao", b =>
                {
                    b.Navigation("Alternativas");
                });
#pragma warning restore 612, 618
        }
    }
}
