using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary.Database;

namespace RecipePlannerWebApplication.Controllers
{
    public class IngredientsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }


        public ActionResult AddIngredient(string txtIngredientName, string txtQuantity)
        {
            IngredientDAL.addIngredient(txtIngredientName, Int32.Parse(txtQuantity));
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }
    }
}

