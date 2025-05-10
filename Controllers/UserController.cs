using Microsoft.AspNetCore.Mvc;
using ST10299399_PROG7311_GreenEnergy_POE.Models;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
           var user = _context.Users
                .FirstOrDefault(u => u.UserName == username && u.UserPassword == password);

            if (user != null)
            {
                // Set user session or cookie here
                HttpContext.Session.SetString("Username", user.UserName);
                HttpContext.Session.SetString("Role", user.Role);

                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();

        }
        public IActionResult Logout()
        {
            // Clear user session or cookie here
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
