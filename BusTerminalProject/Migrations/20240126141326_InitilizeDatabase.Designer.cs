﻿// <auto-generated />
using System;
using BusTerminalProject.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusTerminalProject.Migrations
{
    [DbContext(typeof(BusTerminalDbContext))]
    [Migration("20240126141326_InitilizeDatabase")]
    partial class InitilizeDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusTerminalProject.Entities.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BusTerminalProject.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("BusTerminalProject.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PassangerFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PassengerLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatStatus")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("BusTerminalProject.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<int>("PrchaseCancelation")
                        .HasColumnType("int");

                    b.Property<int>("ReserveCancelation")
                        .HasColumnType("int");

                    b.Property<decimal>("SeatPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OriginId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("BusTerminalProject.Entities.Ticket", b =>
                {
                    b.HasOne("BusTerminalProject.Entities.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("BusTerminalProject.Entities.Trip", b =>
                {
                    b.HasOne("BusTerminalProject.Entities.Bus", "Bus")
                        .WithMany("Trips")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BusTerminalProject.Entities.Location", "Destination")
                        .WithMany("TripsAsDestination")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BusTerminalProject.Entities.Location", "Origin")
                        .WithMany("TripsAsOrigin")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Destination");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("BusTerminalProject.Entities.Bus", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("BusTerminalProject.Entities.Location", b =>
                {
                    b.Navigation("TripsAsDestination");

                    b.Navigation("TripsAsOrigin");
                });

            modelBuilder.Entity("BusTerminalProject.Entities.Trip", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
