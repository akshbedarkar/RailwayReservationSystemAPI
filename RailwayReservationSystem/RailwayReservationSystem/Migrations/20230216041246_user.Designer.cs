﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayReservationSystem.Data;

#nullable disable

namespace RailwayReservationSystem.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230216041246_user")]
    partial class user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RailwayReservationSystem.Models.Domain.Quota", b =>
                {
                    b.Property<Guid>("QuotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Fare")
                        .HasColumnType("int");

                    b.Property<string>("QuotaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuotaId");

                    b.ToTable("Quotas");
                });

            modelBuilder.Entity("RailwayReservationSystem.Models.Domain.Reservation", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuotaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReservationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReservationGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReservationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReservationId");

                    b.HasIndex("QuotaId");

                    b.HasIndex("TrainId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RailwayReservationSystem.Models.Domain.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PnrNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TicketId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("RailwayReservationSystem.Models.Domain.TrainDetails", b =>
                {
                    b.Property<Guid>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DestinationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinationStation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SourceDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SourceStation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainId");

                    b.ToTable("TrainInformation");
                });

            modelBuilder.Entity("RailwayReservationSystem.Models.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RailwayReservationSystem.Models.Domain.Reservation", b =>
                {
                    b.HasOne("RailwayReservationSystem.Models.Domain.Quota", "quota")
                        .WithMany()
                        .HasForeignKey("QuotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayReservationSystem.Models.Domain.TrainDetails", "TrainDetails")
                        .WithMany()
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayReservationSystem.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainDetails");

                    b.Navigation("User");

                    b.Navigation("quota");
                });

            modelBuilder.Entity("RailwayReservationSystem.Models.Domain.Ticket", b =>
                {
                    b.HasOne("RailwayReservationSystem.Models.Domain.Reservation", "reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
