using ST10299399_PROG7311_GreenEnergy_POE.Models;
using ST10299399_PROG7311_GreenEnergy_POE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult AddProduct()
        {
            ViewBag.Farmers = _context.Farmers
                .Select(f => new { f.FarmerId, FullName =  $"{f.FarmerName} {f.FarmerSurname}"}).ToList();
            
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
                    var farmerexsists = await _context.Farmers.AnyAsync(f => f.FarmerId == product.FarmerId);
                    if (!farmerexsists)
                    {
                        ModelState.AddModelError("", "Farmer does not exist.");
                        return View(product);
                    }

                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Product added successfully!";
                    return RedirectToAction("Index");
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

            ViewBag.FarmerName = $"{farmer.FarmerName} {farmer.FarmerSurname}";
            return View(farmer.Products.ToList());
        }
    }
}
