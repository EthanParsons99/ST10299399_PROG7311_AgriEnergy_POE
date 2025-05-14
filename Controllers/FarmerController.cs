/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
using ST10299399_PROG7311_GreenEnergy_POE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    //Check if the user is logged in and has the role of Farmer
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }
         //-----------------------------------------=========------------------------------------//
         //This action method is for the Farmer's main page
         //It returns the view for the Farmer dashboard
        public IActionResult Index()
        {
            //Check if the user is authenticated
            var farmerId = User.FindFirst("FarmerId")?.Value;
            if (farmerId == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            //Check if the user is logged in as a Farmer
            int id = int.Parse(farmerId);
            var farmer = _context.Farmers // Get the Farmer from the database
                .Include(f => f.Products) // Include the Products related to the Farmer
                .FirstOrDefault(f => f.FarmerId == id);

            return View(farmer);
            
        }
         //-----------------------------------------=========------------------------------------//
         //This action method is for adding a new Product
         //It returns the view for adding a Product
        public IActionResult AddProduct()
        { 
            //Check if the user is authenticated
            string currentFarmerId = User.FindFirst("FarmerId")?.Value;
            //If the user is not authenticated, redirect to the login page
            if(string.IsNullOrEmpty(currentFarmerId))
            {
               return RedirectToAction("Login", "Auth"); 
            }
            //If the user is authenticated, create a new Product object
            var product = new Product
            {
                FarmerId = int.Parse(currentFarmerId),
                ProductDate = DateTime.Now
            };

            return View(product);
        }
         //-----------------------------------------=========------------------------------------//
         //This action method handles the POST request for adding a new Product
         //It takes a Product object as a parameter
         //If the model state is valid, it adds the Product to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product)
        {
            Console.WriteLine($"Recieved Data: {product.ProductName}, {product.ProductCategory}, {product.ProductPrice}, {product.ProductDate}, {product.FarmerId}");

            string currentFarmerId = User.FindFirst("FarmerId")?.Value;
            if (!string.IsNullOrEmpty(currentFarmerId))
            {
                product.FarmerId = int.Parse(currentFarmerId);
            }
            //Remove the Farmer property from the model state to prevent validation errors
            ModelState.Remove("Farmer");
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ProductDate == DateTime.MinValue)
                    {
                        product.ProductDate = DateTime.Now;
                    }

                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Product added successfully!";
                    return RedirectToAction("ViewMyProducts", new { farmerId = product.FarmerId });
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                }
            }
            return View(product);
        }
         //-----------------------------------------=========------------------------------------//
         //This action method is for viewing the Farmer's Products
         //It takes a farmerId as a parameter
         //It returns a view with a list of the Farmer's Products
        public async Task<IActionResult> ViewMyProducts(int farmerId)
        {
            var farmer = await _context.Farmers
                .Include(f => f.Products)
                .FirstOrDefaultAsync(f => f.FarmerId == farmerId);

            if (farmer == null)
            {
                return NotFound();
            }

            string currentFarmerId = User.FindFirst("FarmerId")?.Value;
            if (!string.IsNullOrEmpty(currentFarmerId) && currentFarmerId != farmerId.ToString())
            {
                return Forbid();
            }

            ViewBag.FarmerName = $"{farmer.FarmerName} {farmer.FarmerSurname}";
            return View(farmer.Products.OrderByDescending(p => p.ProductDate).ToList());
        }
         //-----------------------------------------=========------------------------------------//
         //This action method is for viewing the Marketplace
         //It returns a view with a list of all Products
        public async Task<IActionResult> Marketplace()
        {
            var products = await _context.Products
                .Include(p => p.Farmer)
                .ToListAsync();

            return View(products);
        }
         //-----------------------------------------=========------------------------------------//
    }
}
 //-----------================End of file=================--------------//