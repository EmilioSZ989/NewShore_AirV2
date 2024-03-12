﻿// <auto-generated />
using System;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backEnd.Migrations
{
    [DbContext(typeof(MySQLiteContext))]
    [Migration("20240312183659_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("BackEnd.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("JourneyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("TransportFlightNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JourneyId");

                    b.HasIndex("TransportFlightNumber");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("BackEnd.Models.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("BackEnd.Models.Transport", b =>
                {
                    b.Property<string>("FlightNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlightCarrier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FlightNumber");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("BackEnd.Models.Flight", b =>
                {
                    b.HasOne("BackEnd.Models.Journey", null)
                        .WithMany("Flights")
                        .HasForeignKey("JourneyId");

                    b.HasOne("BackEnd.Models.Transport", "Transport")
                        .WithMany()
                        .HasForeignKey("TransportFlightNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("BackEnd.Models.Journey", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
