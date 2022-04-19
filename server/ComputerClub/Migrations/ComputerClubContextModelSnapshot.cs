﻿// <auto-generated />
using System;
using ComputerClub.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ComputerClub.Migrations
{
    [DbContext(typeof(ComputerClubContext))]
    partial class ComputerClubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ComputerClub.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CPU")
                        .HasColumnType("text");

                    b.Property<string>("Keyboard")
                        .HasColumnType("text");

                    b.Property<string>("Monitor")
                        .HasColumnType("text");

                    b.Property<string>("Mouse")
                        .HasColumnType("text");

                    b.Property<string>("RAM")
                        .HasColumnType("text");

                    b.Property<string>("ROM")
                        .HasColumnType("text");

                    b.Property<string>("VideoCard")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("ComputerClub.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("Minutes")
                        .HasColumnType("integer");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ComputerClub.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("numeric");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("ComputerClub.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ComputerClub.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ComputerClub.Models.Order", b =>
                {
                    b.HasOne("ComputerClub.Models.User", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("ComputerClub.Models.Place", "Place")
                        .WithMany("Orders")
                        .HasForeignKey("PlaceId");

                    b.Navigation("Customer");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("ComputerClub.Models.Place", b =>
                {
                    b.HasOne("ComputerClub.Models.Equipment", "Equipment")
                        .WithOne("Place")
                        .HasForeignKey("ComputerClub.Models.Place", "EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerClub.Models.Status", "Status")
                        .WithMany("Places")
                        .HasForeignKey("StatusId");

                    b.Navigation("Equipment");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ComputerClub.Models.Equipment", b =>
                {
                    b.Navigation("Place");
                });

            modelBuilder.Entity("ComputerClub.Models.Place", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ComputerClub.Models.Status", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("ComputerClub.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
