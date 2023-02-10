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
    }
}
    
