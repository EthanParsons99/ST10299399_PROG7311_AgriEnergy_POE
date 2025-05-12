using Microsoft.AspNetCore.Mvc;
using ST10299399_PROG7311_GreenEnergy_POE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            { 
                if (User.IsInRole("Employee"))
                {
                    return RedirectToAction("ViewProducts", "Employee");
                }
                else if (User.IsInRole("Farmer"))
                {
                    var farmerId = User.FindFirst("FarmerId")?.Value;
                    return RedirectToAction("Index", "Farmer", new { FarmerId = farmerId });
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password, string userRole)
        {
            if (userRole == "Employee")
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeName == username);

                if (employee != null && employee.EmployeePassword == password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, employee.EmployeeName),
                        new Claim(ClaimTypes.Role, "Employee"),
                        new Claim("EmployeeId", employee.EmployeeId.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("ViewProducts", "Employee");
                }
            }
            else if (userRole == "Farmer")
            {
                var farmer = await _context.Farmers
                    .FirstOrDefaultAsync(f => f.FarmerName == username);

                if (farmer != null && farmer.FarmerPassword == password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, farmer.FarmerName),
                        new Claim(ClaimTypes.Role, "Farmer"),
                        new Claim("FarmerId", farmer.FarmerId.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("ViewMyProducts", "Farmer", new {FarmerId = farmer.FarmerId});
                }
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
