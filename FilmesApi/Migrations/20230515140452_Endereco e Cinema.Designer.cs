﻿// <auto-generated />
using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmesApi.Migrations
{
    [DbContext(typeof(FilmesContext))]
    [Migration("20230515140452_Endereco e Cinema")]
    partial class EnderecoeCinema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
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

            modelBuilder.Entity("FilmesApi.models.Cinema", b =>
                {
                    b.HasOne("FilmesApi.models.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("FilmesApi.models.Cinema", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("FilmesApi.models.Endereco", b =>
                {
                    b.Navigation("Cinema");
                });
#pragma warning restore 612, 618
        }
    }
}