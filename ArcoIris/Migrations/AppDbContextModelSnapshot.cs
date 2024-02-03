﻿// <auto-generated />
using System;
using Database.Context.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArcoIris.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Database.Context.Alternativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Correta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestaoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestaoId");

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

            modelBuilder.Entity("Database.Context.Prova", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Nota")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantidadeAcertos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantidadeErros")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Provas");
                });

            modelBuilder.Entity("Database.Context.Questao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Enunciado")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Questoes");
                });

            modelBuilder.Entity("Database.Context.QuestaoResposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AlternativaEscolhidaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Correta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProvaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestaoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlternativaEscolhidaId");

                    b.HasIndex("ProvaId");

                    b.HasIndex("QuestaoId");

                    b.ToTable("QuestaoResposta");
                });

            modelBuilder.Entity("Database.Context.Alternativa", b =>
                {
                    b.HasOne("Database.Context.Questao", "Questao")
                        .WithMany("Alternativas")
                        .HasForeignKey("QuestaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("Database.Context.Prova", b =>
                {
                    b.HasOne("Database.Context.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Database.Context.QuestaoResposta", b =>
                {
                    b.HasOne("Database.Context.Alternativa", "AlternativaEscolhida")
                        .WithMany()
                        .HasForeignKey("AlternativaEscolhidaId");

                    b.HasOne("Database.Context.Prova", "Prova")
                        .WithMany("QuestoesRespostas")
                        .HasForeignKey("ProvaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Context.Questao", "Questao")
                        .WithMany()
                        .HasForeignKey("QuestaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlternativaEscolhida");

                    b.Navigation("Prova");

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("Database.Context.Prova", b =>
                {
                    b.Navigation("QuestoesRespostas");
                });

            modelBuilder.Entity("Database.Context.Questao", b =>
                {
                    b.Navigation("Alternativas");
                });
#pragma warning restore 612, 618
        }
    }
}
