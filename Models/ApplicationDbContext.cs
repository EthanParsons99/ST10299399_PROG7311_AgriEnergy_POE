/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using ST10299399_PROG7311_GreenEnergy_POE.Models;

namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    // DB Context class for the application
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public string DbPath { get; private set; }

        //A constructor that takes a DbContextOptions object and passes it to the base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         //-----------------------------------------=========------------------------------------//
         //A method that is called when the model is being created
         //It is used to configure the model and seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Farmer>()
                .HasMany(f => f.Products)
                .WithOne(p => p.Farmer)
                .HasForeignKey(p => p.FarmerId);

            //Seeding Employee data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeName = "Admin1",
                    EmployeePassword = "admin1",
                    EmployeeEmail = "admin1@gmail.com"
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeName = "Admin2",
                    EmployeePassword = "admin2",
                    EmployeeEmail = "admin2@gmail.com"
                },
                new Employee
                {
                    EmployeeId = 3,
                    EmployeeName = "Admin3",
                    EmployeePassword = "admin3",
                    EmployeeEmail = "admin3@gmail.com"
                },
                new Employee
                {
                    EmployeeId = 4,
                    EmployeeName = "Admin4",
                    EmployeePassword = "admin4",
                    EmployeeEmail = "admin4@gmail.com"
                },
                new Employee
                {
                    EmployeeId = 5,
                    EmployeeName = "Admin5",
                    EmployeePassword = "admin5",
                    EmployeeEmail = "admin5@gmail.com"
                }

            );
            //Seeding Farmer data
            modelBuilder.Entity<Farmer>().HasData(
                new Farmer
                {
                    FarmerId = 1,
                    FarmerName = "Pieter",
                    FarmerSurname = "Visser",
                    FarmerPhone = "1234567890",
                    FarmerEmail = "pieter@gmail.com",
                    FarmerPassword = "pieter123"
                },
                new Farmer
                {
                    FarmerId = 2,
                    FarmerName = "John",
                    FarmerSurname = "Porker",
                    FarmerPhone = "0647512222",
                    FarmerEmail = "john@gmail.com",
                    FarmerPassword = "john123"
                },
                new Farmer
                {
                    FarmerId = 3,
                    FarmerName = "Jasper",
                    FarmerSurname = "Rasper",
                    FarmerPhone = "0761595555",
                    FarmerEmail = "jasper@gmail.com",
                    FarmerPassword = "jasper123"
                },
                new Farmer
                {
                    FarmerId = 4,
                    FarmerName = "Manie",
                    FarmerSurname = "Libbok",
                    FarmerPhone = "0541235678",
                    FarmerEmail = "manie@gmail.com",
                    FarmerPassword = "manie123"
                },
                new Farmer
                {
                    FarmerId = 5,
                    FarmerName = "Fanie",
                    FarmerSurname = "Bosveld",
                    FarmerPhone = "0671592345",
                    FarmerEmail = "fanie@gmail.com",
                    FarmerPassword = "fanie123"
                }
            );
        }

  
    }
    
}
//-----------================End of file=================--------------//