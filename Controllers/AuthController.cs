/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
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
    //Controller for handling authentication
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Constructor for initializing the context and httpContextAccessor
        public AuthController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
         //-----------------------------------------=========------------------------------------//
        //Login action method
        public IActionResult Login()
        {
            //Check if the user is already authenticated
            if (User.Identity.IsAuthenticated) 
            { 
                if (User.IsInRole("Employee"))
                {
                    return RedirectToAction("Index", "Employee");
                }
                else if (User.IsInRole("Farmer"))
                {
                    return RedirectToAction("Index", "Farmer");
                }
            }
            return View();
        }
         //-----------------------------------------=========------------------------------------//
         //Login action method for handling post requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, string userRole)
        {
            //Check if the user is already authenticated
            if (userRole == "Employee")
            {
                //Find the employee by email
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeEmail == email);

                //Check if the employee exists and the password is correct
                if (employee != null && employee.EmployeePassword == password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, employee.EmployeeName),
                        new Claim(ClaimTypes.Email, employee.EmployeeEmail),
                        new Claim(ClaimTypes.Role, "Employee"),
                        new Claim("EmployeeId", employee.EmployeeId.ToString())
                    };

                    //Create claims identity and sign in the user
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    // Sign in the user with the claims identity
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    
                    // Redirect to the employee index page
                    return RedirectToAction("Index", "Employee");
                }
            }
            //If the user is a farmer, find the farmer by email
            else if (userRole == "Farmer")
            {
                var farmer = await _context.Farmers
                    .FirstOrDefaultAsync(f => f.FarmerEmail == email);

                if (farmer != null && farmer.FarmerPassword == password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, farmer.FarmerName),
                        new Claim(ClaimTypes.Email, farmer.FarmerEmail),
                        new Claim(ClaimTypes.Role, "Farmer"),
                        new Claim("FarmerId", farmer.FarmerId.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Farmer", new {FarmerId = farmer.FarmerId});
                }
            }
            //If the login attempt fails, add a model error and return to the login view
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();

        }
        //-----------------------------------------=========------------------------------------//
        //Logout action method
        public async Task<IActionResult> Logout()
        {
            //Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        //-----------------------------------------=========------------------------------------//
    }
}
 //-----------================End of file=================--------------//