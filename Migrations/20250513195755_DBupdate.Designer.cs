﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ST10299399_PROG7311_GreenEnergy_POE.Models;

#nullable disable

namespace ST10299399_PROG7311_GreenEnergy_POE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250513195755_DBupdate")]
    partial class DBupdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("ST10299399_PROG7311_GreenEnergy_POE.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeePassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            EmployeeEmail = "admin@gmail.com",
                            EmployeeName = "Admin",
                            EmployeePassword = "admin123"
                        });
                });

            modelBuilder.Entity("ST10299399_PROG7311_GreenEnergy_POE.Models.Farmer", b =>
                {
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FarmerEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FarmerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FarmerPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FarmerPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FarmerSurname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FarmerId");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("ST10299399_PROG7311_GreenEnergy_POE.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FarmerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProductDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("REAL");

                    b.HasKey("ProductId");

                    b.HasIndex("FarmerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ST10299399_PROG7311_GreenEnergy_POE.Models.Product", b =>
                {
                    b.HasOne("ST10299399_PROG7311_GreenEnergy_POE.Models.Farmer", "Farmer")
                        .WithMany("Products")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("ST10299399_PROG7311_GreenEnergy_POE.Models.Farmer", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
