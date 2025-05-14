/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public string DbPath { get; private set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Farmer>()
                .HasMany(f => f.Products)
                .WithOne(p => p.Farmer)
                .HasForeignKey(p => p.FarmerId);

            modelBuilder.Entity<Employee>().HasData(
                new Employee 
                { 
                    EmployeeId = 1, 
                    EmployeeName = "Admin", 
                    EmployeePassword = "admin123",
                    EmployeeEmail = "admin@gmail.com"
                }

            );
        }

  
    }
    
}
 //-----------================End of file=================--------------//