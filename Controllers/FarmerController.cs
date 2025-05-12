using ST10299399_PROG7311_GreenEnergy_POE.Models;
using ST10299399_PROG7311_GreenEnergy_POE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var farmerId = User.FindFirst("FarmerId")?.Value;
            if (farmerId != null)
            {
                return RedirectToAction("ViewMyProducts", new { farmerId = int.Parse(farmerId) } );
            }
            return RedirectToAction("Login", "Auth");
        }


        public IActionResult AddProduct()
        {
            ViewBag.Farmers = _context.Farmers
                .Select(f => new { f.FarmerId, FullName =  $"{f.FarmerName} {f.FarmerSurname}"}).ToList();
            
            string currentFarmerId = User.FindFirst("FarmerId")?.Value;
            if(!string.IsNullOrEmpty(currentFarmerId))
            {
                ViewBag.CurrentFarmerId = int.Parse(currentFarmerId);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(product.ProductDate == DateTime.MinValue)
                    {
                        product.ProductDate = DateTime.Now;
                    }

                    var farmerExists = await _context.Farmers
                        .AnyAsync(f => f.FarmerId == product.FarmerId);
                    if (!farmerExists)
                    {
                        ModelState.AddModelError("", "Farmer does not exist.");
                        return View(product);
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

            ViewBag.Farmers = _context.Farmers
                .Select(f => new { f.FarmerId, FullName = $"{f.FarmerName} {f.FarmerSurname}" }).ToList();
            return View(product);
        }

        public async Task<IActionResult> ViewMyProducst(int farmerId)
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
    }
}
