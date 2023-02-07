using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerWebApplication.Models;
using System.Diagnostics;

namespace RecipePlannerWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Database.PopulateWebDB();
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] Login ad)
        {
            int res = Database.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "Successful Login!";
            }
            else
            {
                TempData["msg"] = "The Username or Password is incorrect.";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}