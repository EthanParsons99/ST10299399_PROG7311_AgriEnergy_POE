using Microsoft.EntityFrameworkCore;

namespace ST10299399_PROG7311_GreenEnergy_POE.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }
  
    }
    
}
