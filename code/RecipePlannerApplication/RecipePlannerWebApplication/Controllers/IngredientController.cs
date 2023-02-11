using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;

namespace RecipePlannerWebApplication.Controllers
{
    public class IngredientsController : Controller
    {
        public IActionResult Index()
        {
            List<Ingredient> ingredients = new List<Ingredient>
            {
                new Ingredient( 1, "Sugar", 2),
                new Ingredient (2, "Flour", 1),
                new Ingredient (3, "Eggs", 4),
                new Ingredient (4, "Milk", 3),
                new Ingredient (5,  "Butter", 1)
            };
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("/Views/IngredientsPage", ViewBag.ingredients);
        }


        public ActionResult AddIngredient(string txtID, string txtIngredientName, string txtQuantity)
        {
            // Add the new ingredient to your data source
            var ingredient = new Ingredient(Int32.Parse(txtID), txtIngredientName, Int32.Parse(txtQuantity));
            // Add the ingredient to the list of ingredients (e.g. a database, a collection, etc.)

            // Redirect the user back to the index page to see the updated list of ingredients
            return RedirectToAction("Index");
        }
    }
}
    
