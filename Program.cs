using ST10299399_PROG7311_GreenEnergy_POE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ST10299399_PROG7311_GreenEnergy_POE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout to 30 minutes
                options.Cookie.HttpOnly = true; // Make the session cookie HTTP-only
                options.Cookie.IsEssential = true; // Make the session cookie essential
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login"; // Redirect to login page if not authenticated
                    options.AccessDeniedPath = "/Auth/Login";
                });

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Seed the database with initial data
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Check if the database is empty
                context.Database.EnsureCreated();
                Console.WriteLine("Checking for seeding users");
                if (!context.Employees.Any())
                {
                    context.Employees.Add(new Employee
                    {
                        EmployeeId = 1,
                        EmployeeName = "Admin",
                        EmployeePassword = "admin123"
                    });
                    context.SaveChanges();
                }

                if (!context.Farmers.Any())
                {
                    context.Farmers.Add(new Farmer
                    {
                        FarmerName = "John",
                        FarmerSurname = "Doe",
                        FarmerPhone = "1234567890",
                        FarmerEmail = "1234567890",
                        FarmerPassword = "password123"
                    });
                    context.SaveChanges();
                }
            }

            app.Run();

            
        }
    }
}
