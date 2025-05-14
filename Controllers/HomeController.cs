/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG7311
/// </summary>
using Microsoft.AspNetCore.Mvc;
using ST10299399_PROG7311_GreenEnergy_POE.Models;
using System.Diagnostics;

namespace ST10299399_PROG7311_GreenEnergy_POE.Controllers
{
    //Controller for the Home page
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
         //-----------------------------------------=========------------------------------------//
         //Index page for the Home page
        public IActionResult Index()
        {
            return View();
        }
         //-----------------------------------------=========------------------------------------/
         // About page for the Home page
        public IActionResult Privacy()
        {
            return View();
        }
         //-----------------------------------------=========------------------------------------//
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public class ErrorViewModel
        {
            public string RequestId { get; set; }
            public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        }
    }
}
 //-----------================End of file=================--------------//