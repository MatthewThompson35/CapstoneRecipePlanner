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


        public ActionResult AddIngredient(string txtIngredientName, string txtQuantity, string measurement)
        {
            IngredientDAL.addIngredient(txtIngredientName, Int32.Parse(txtQuantity), measurement);
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }
    }
}

