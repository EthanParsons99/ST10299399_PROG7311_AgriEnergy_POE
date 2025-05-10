using ST10299399_PROG7311_GreenEnergy_POE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var farmers = await _context.Farmers.Include(f => f.Products).ToListAsync();
            return View(farmers);
        }

        public IActionResult AddProduct(int farmerId)
        {
            var model = new Product
            {
                FarmerId = farmerId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
