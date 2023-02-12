using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
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
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] Login ad)
        {
            int res = Database.LoginCheck(ad);
            if (res == 1)
            {
                ActiveUser.username = ad.Username;
                ViewBag.ingredients = IngredientDAL.getIngredients();
                return View("IngredientsPage");
            }
            else
            {
                TempData["msg"] = "The Username or Password is incorrect.";
                return View();
            }
            
        }

        public ActionResult decrementQuantity(string id)
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            var quantity = 0;
            var ingredientID = Int32.Parse(id);

            foreach (var item in ViewBag.ingredients)
            {
                if (item.id == ingredientID)
                {
                    quantity = item.quantity;

                }
            }
            IngredientDAL.decrementQuantity(ingredientID, quantity);
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }

        [HttpPost]
        public ActionResult AddIngredient(string txtIngredientName, string txtQuantity)
        {
            IngredientDAL.addIngredient(txtIngredientName, Int32.Parse(txtQuantity));
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}