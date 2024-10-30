﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ParkingContext))]
    [Migration("20241030193235_fouth-migration")]
    partial class fouthmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Data.Entities.Fee", b =>
                {
                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Type");

                    b.ToTable("Fees");

                    b.HasData(
                        new
                        {
                            Type = 0,
                            Value = 1000
                        },
                        new
                        {
                            Type = 1,
                            Value = 1500
                        },
                        new
                        {
                            Type = 2,
                            Value = 30000
                        });
                });

            modelBuilder.Entity("Data.Entities.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExitTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Fee")
                        .HasColumnType("TEXT");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SlotId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("Data.Entities.Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrador",
                            Password = "admin",
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
