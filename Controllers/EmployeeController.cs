using ST10299399_PROG7311_GreenEnergy_POE.Models;   
using Microsoft.AspNetCore.Mvc;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFarmer(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Farmers.Add(farmer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(farmer);
        }
    }
}
