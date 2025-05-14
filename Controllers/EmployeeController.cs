/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
using ST10299399_PROG7311_GreenEnergy_POE.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    // Check if the user is authorized as an Employee
    [Authorize(Roles = "Employee")]
    // This class handles the Employee-related actions
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _context;
        
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
         //-----------------------------------------=========------------------------------------//
         // This action method is for the Employee's main page
         // It returns the view for the Employee dashboard
        public IActionResult Index()
        {
            return View();
        }
         //-----------------------------------------=========------------------------------------//
         // This action method is for adding a new Farmer
         // It returns the view for adding a Farmer
        public IActionResult AddFarmer()
        {
            return View();
        }
         //-----------------------------------------=========------------------------------------//
         // This action method handles the POST request for adding a new Farmer
         // It takes a Farmer object as a parameter
         // If the model state is valid, it adds the Farmer to the database
         // If there is an error, it adds the error to the model state
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFarmer(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    _context.Farmers.Add(farmer);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Farmer added successfully!";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                }
            }
            return View(farmer);
        }
         //-----------------------------------------=========------------------------------------//
         // This action method is for viewing all the Farmers Products
         // It returns a view with a list of Farmers Products
        public async Task<IActionResult> ViewProducts(string searchCategory = null,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var productsQuery = _context.Products
                .Include(p => p.Farmer)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchCategory))
            {
                productsQuery = productsQuery.Where(p => p.ProductCategory.ToLower().Contains(searchCategory.ToLower()));
            }

            if (startDate.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ProductDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ProductDate <= endDate.Value);
            }

            var products = await productsQuery.OrderByDescending(p => p.ProductDate).ToListAsync();

            ViewBag.Categories = _context.Products
                .Select(p => p.ProductCategory)
                .Distinct()
                .ToList();

            ViewBag.CurrentCategory = searchCategory;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            return View(products);
        }
        //-----------------------------------------=========------------------------------------//
    }
}
 //-----------================End of file=================--------------//