﻿// <auto-generated />
using System;
using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmesApi.Migrations
{
    [DbContext(typeof(FilmesContext))]
    [Migration("20230517000602_Cinema e Sessao")]
    partial class CinemaeSessao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FilmesApi.models.Cinema", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("FilmesApi.models.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("FilmesApi.models.Filme", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("duracao")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("FilmesApi.models.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("FilmesApi.models.Cinema", b =>
                {
                    b.HasOne("FilmesApi.models.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("FilmesApi.models.Cinema", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("FilmesApi.models.Sessao", b =>
                {
                    b.HasOne("FilmesApi.models.Cinema", "Cinema")
                        .WithMany("Sessoes")
                        .HasForeignKey("CinemaId");

                    b.HasOne("FilmesApi.models.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("FilmesApi.models.Cinema", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("FilmesApi.models.Endereco", b =>
                {
                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("FilmesApi.models.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });
#pragma warning restore 612, 618
        }
    }
}