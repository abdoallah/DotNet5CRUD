﻿// <auto-generated />
using System;
using DotNetCrud.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetCrud.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220327221836_AddMoviesGenresTables")]
    partial class AddMoviesGenresTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCrud.core.Models.Genre", b =>
                {
                    b.Property<byte>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("DotNetCrud.core.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("GenreId")
                        .HasColumnType("tinyint");

                    b.Property<byte[]>("Poster")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("StoryLine")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("DotNetCrud.core.Models.Movie", b =>
                {
                    b.HasOne("DotNetCrud.core.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}