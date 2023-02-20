using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using RecipePlannerWebApplication.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipePlannerWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The view</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Indexes the specified ad.
        /// </summary>
        /// <param name="ad">The ad.</param>
        /// <returns>The view</returns>
        [HttpPost]
        public IActionResult Index([Bind] Login ad)
        {
            int res = Database.LoginCheck(ad);
            if (res == 1)
            {
                List<Recipe> recipes = RecipeDAL.getRecipes();
                foreach (var recipe in recipes)
                {
                    recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId);
                    recipe.Steps = RecipeDAL.getStepsForRecipe(recipe.RecipeId);
                }

                ViewBag.recipes = recipes;
                return View("RecipePage", ViewBag.recipes);

            }
            else
            {
                TempData["msg"] = "The Username or Password is incorrect.";
                return View();
            }

        }

        /// <summary>
        /// Decrements the quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The View</returns>
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

        /// <summary>
        /// Increments the quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The view</returns>
        public ActionResult incrementQuantity(string id)
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
            IngredientDAL.incrementQuantity(ingredientID, quantity);
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }

        /// <summary>
        /// Removes the ingredient.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The view</returns>
        public ActionResult removeIngredient(string id)
        {
            IngredientDAL.RemoveIngredient(Int32.Parse(id));
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }

        /// <summary>
        /// Adds the ingredient.
        /// </summary>
        /// <param name="txtIngredientName">Name of the text ingredient.</param>
        /// <param name="txtQuantity">The text quantity.</param>
        /// <returns>The view</returns>
        [HttpPost]
        public ActionResult AddIngredient(string txtIngredientName, string txtQuantity, string measurement)
        {
            var measurements = Enum.GetNames(typeof(Measurement)).ToList();
            ViewBag.Measurements = measurements;
            Regex regex = new Regex("^[0-9]+$");

            if (txtIngredientName == null || txtQuantity == null || txtIngredientName == "" || txtQuantity == "")
            {
                TempData["msg"] = "Please enter values.";
                return View("AddIngredient", ViewBag.Measurements);
            }
            else if (IngredientDAL.getIngredients(txtIngredientName).Count() > 0)
            {
                TempData["msg"] = "Ingredient is already entered.";
                return View("AddIngredient", ViewBag.Measurements);
            }
            else if (!regex.Match(txtQuantity).Success)
            {
	            TempData["msg"] = "Quantity must be an integer.";
	            return View("AddIngredient", ViewBag.Measurements);
			}
            else
            {
                IngredientDAL.addIngredient(txtIngredientName, Int32.Parse(txtQuantity), measurement);
                ViewBag.ingredients = IngredientDAL.getIngredients();
                return View("IngredientsPage", ViewBag.ingredients);
            }
        }

        /// <summary>
        /// Goes to ingredients page.
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult goToIngredientsPage()
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }

        /// <summary>
        /// Goes to add ingredients page.
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult goToAddIngredientsPage()
        {
            var measurements = Enum.GetNames(typeof(Measurement)).ToList();
            ViewBag.Measurements = measurements;
            return View("AddIngredient", ViewBag.Measurements);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="repeatPassword">The repeat password.</param>
        /// <returns>The view</returns>
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

        /// <summary>
        /// Opens the register.
        /// </summary>
        /// <returns>The view</returns>
        [HttpPost]
        public ActionResult OpenRegister()
        {
            return View("Register");

        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns>The view</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            return View("Index");
        }
    }
}