﻿// <auto-generated />
using System;
using FilmsAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmsAPI.Migrations
{
    [DbContext(typeof(FilmContext))]
    [Migration("20240214170655_MovieTheater and Section")]
    partial class MovieTheaterandSection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FilmsAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PublicPlace")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("FilmsAPI.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("FilmsAPI.Models.MovieTheater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("MovieTheaters");
                });

            modelBuilder.Entity("FilmsAPI.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieTheaterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("MovieTheaterId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("FilmsAPI.Models.MovieTheater", b =>
                {
                    b.HasOne("FilmsAPI.Models.Address", "Address")
                        .WithOne("MovieTheater")
                        .HasForeignKey("FilmsAPI.Models.MovieTheater", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("FilmsAPI.Models.Section", b =>
                {
                    b.HasOne("FilmsAPI.Models.Film", "Film")
                        .WithMany("Sections")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmsAPI.Models.MovieTheater", "MovieTheater")
                        .WithMany("Sections")
                        .HasForeignKey("MovieTheaterId");

                    b.Navigation("Film");

                    b.Navigation("MovieTheater");
                });

            modelBuilder.Entity("FilmsAPI.Models.Address", b =>
                {
                    b.Navigation("MovieTheater")
                        .IsRequired();
                });

            modelBuilder.Entity("FilmsAPI.Models.Film", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("FilmsAPI.Models.MovieTheater", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
