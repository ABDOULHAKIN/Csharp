﻿// <auto-generated />
using System;
using Festival.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Festival.Web.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240110141835_version_initiale")]
    partial class version_initiale
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Festival.BO.Artiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GroupeId")
                        .HasColumnType("int");

                    b.Property<string>("Instrument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupeId");

                    b.ToTable("Artiste");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupeId = 1,
                            Instrument = "Piano",
                            Nom = "Mercury",
                            Prenom = "Freddy"
                        },
                        new
                        {
                            Id = 2,
                            Instrument = "Code",
                            Nom = "Quentin",
                            Prenom = "Martinez"
                        });
                });

            modelBuilder.Entity("Festival.BO.Groupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groupe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreation = new DateTime(1997, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Queen 2024"
                        });
                });

            modelBuilder.Entity("Festival.BO.Artiste", b =>
                {
                    b.HasOne("Festival.BO.Groupe", "Groupe")
                        .WithMany()
                        .HasForeignKey("GroupeId");

                    b.Navigation("Groupe");
                });
#pragma warning restore 612, 618
        }
    }
}