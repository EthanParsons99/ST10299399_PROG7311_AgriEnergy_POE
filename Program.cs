using ST10299399_PROG7311_GreenEnergy_POE.Models;
using Microsoft.EntityFrameworkCore;

namespace ST10299399_PROG7311_GreenEnergy_POE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            // Seed the database with initial data
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Check if the database is empty
                context.Database.EnsureCreated();
                Console.WriteLine("Checking for seeding users");
                if (!context.Users.Any())
                {
                    context.Users.AddRange
                    (
                        new User
                        {
                            UserName = "admin",
                            UserPassword = "admin123",
                            Role = "Employee"
                        },
                        new User
                        {
                            UserName = "farmer",
                            UserPassword = "farmer123",
                            Role = "Farmer"
                        }
                    );
                    context.SaveChanges();
                }
            }

            app.Run();

            
        }
    }
}
