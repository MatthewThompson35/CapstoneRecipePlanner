using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerWebApplication.Models;
using System.Diagnostics;
using System.Reflection.Metadata;

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

        [HttpPost]
        public ActionResult CreateUser(string username, string password, string repeatPassword)
        {
            List<string> list = Database.ContainsUser(username);
            if (list.Count() > 0)
            {
                TempData["msg"] = "This username is already taken. Please choose another and try again.";
                return View("Register");
            }
            if (password.Equals(repeatPassword))
            {
                Database.CreateUser(username, password);

                return View("Index");

            }
            else
            {
                TempData["msg"] = "The password must match in both fields. Please try again.";
                return View("Register");
            }

        }

        [HttpPost]
        public ActionResult OpenRegister()
        {
            return View("Register");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}