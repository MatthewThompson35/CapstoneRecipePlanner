﻿using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using RecipePlannerWebApplication.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;
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
                ActiveUser.username = ad.Username;
               this.setupForRecipePage();
               return View("RecipePage", ViewBag.AvailableRecipes);

            }
            if (res == 2)
            {
                TempData["msg"] = "The connection to the server could not be made";
                return View();
            }
            if (res == 0)
            {
                TempData["msg"] = "The Username or Password is incorrect.";
                return View();
            }

            return View();

        }

        private void setupForRecipePage()
        {
            List<Recipe> recipes = RecipeDAL.getRecipes();
            foreach (var recipe in recipes)
            {
                recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId);
                recipe.Steps = RecipeDAL.getStepsForRecipe(recipe.RecipeId);
            }
            this.addToAvailableRecipes(recipes);
            ViewBag.AvailableRecipes.Sort((Comparison<Recipe>)CompareRecipesByName);
            ViewBag.AllRecipes.Sort((Comparison<Recipe>)CompareRecipesByName);
        }
        /// <summary>
        /// Adds to the available recipes if the user can make that recipe.
        /// </summary>
        /// <param name="recipes">The recipes.</param>
        private void addToAvailableRecipes(List<Recipe> recipes)
        {
            ViewBag.AvailableRecipes = new List<Recipe>();
            ViewBag.AllRecipes = recipes;
            foreach (var recipe in ViewBag.AllRecipes)
            {
                var add = true;
                recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId);
                foreach (RecipeIngredient ingredient in recipe.Ingredients)
                {
                    var ing = IngredientDAL.getIngredients(ingredient.IngredientName);
                    if (ing != null && ing.Count > 0)
                    {
                        if (ing[0].quantity < ingredient.Quantity)
                        {
                            add = false;
                        }
                    }
                    else
                    {
                        add = false;
                    }


                }
                if (add)
                {
                    ViewBag.AvailableRecipes.Add(recipe);
                }
            }
        }

        /// <summary>
        /// Compares the name of the recipes so that it can be sorted alphabetically.
        /// </summary>
        /// <param name="recipe1">The recipe1.</param>
        /// <param name="recipe2">The recipe2.</param>
        /// <returns></returns>
        int CompareRecipesByName(Recipe recipe1, Recipe recipe2)
        {
            return recipe1.Name.CompareTo(recipe2.Name);
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

            quantity = getItemQuantity(ingredientID);
            IngredientDAL.decrementQuantity(ingredientID, quantity);
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }

        /// <summary>
        /// Gets the item quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private int getItemQuantity(int id)
        {
            var quantity = 0;
            foreach (var item in ViewBag.ingredients)
            {
                if (item.id == id)
                {
                    quantity = item.quantity;

                }
            }
            return quantity;
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

            quantity = getItemQuantity(ingredientID);
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
        /// Goes to RecipesPage
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult goToRecipePage()
        {
            this.setupForRecipePage();
            return View("RecipePage", ViewBag.AvailableRecipes);
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

        [HttpPost]
        public IActionResult Logout()
        {
            return View("Index");
        }


    }
}