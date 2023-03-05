using System.Diagnostics;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using RecipePlannerWebApplication.Models;

namespace RecipePlannerWebApplication.Controllers;

public class HomeController : Controller
{
    #region Data members

    private readonly ILogger<HomeController> _logger;

    #endregion

    #region Constructors

    public HomeController(ILogger<HomeController> logger)
    {
        this._logger = logger;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Takes the User to the login page
    /// </summary>
    /// <returns>The Login Page</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    ///     Checks the login and goes to recipe page on successful login. Prompts for retry on failed login
    /// </summary>
    /// <param name="ad">The ad.</param>
    /// <returns>The Recipe Page login on server connection error</returns>
    [HttpPost]
    public IActionResult Index([Bind] Login ad)
    {
        try
        {
            var res = Database.LoginCheck(ad);
            if (res == 1)
            {
                ActiveUser.username = ad.Username;
                this.setupForRecipePage();
                return View("RecipePage");
            }

            ad.ErrorMessage = "Incorrect username or password";
            return View(ad);
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
            return View("Index");
        }
    }

    private void setupForRecipePage(int? page = 1)
    {
        try
        {
            List<Recipe> recipes = RecipeDAL.getRecipes(Connection.ConnectionString);
            foreach (var recipe in recipes)
            {
                recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
                recipe.Steps = RecipeDAL.getStepsForRecipe(recipe.RecipeId, Connection.ConnectionString);
                recipe.Tags = RecipeDAL.getTagsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            }

           
            this.addToAvailableRecipes(recipes);
            const int pageSize = 1;
            int currentPage = page ?? 1;

            ViewBag.currentPage = currentPage;
            ViewBag.AvailableRecipes.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            ViewBag.AllRecipes.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            int totalAvailableRecipes = ViewBag.AvailableRecipes.Count;
            int totalAvailablePages = (int)Math.Ceiling((double)totalAvailableRecipes / pageSize);
            ViewBag.totalAvailablePages = totalAvailablePages;
            List<Recipe> availableRecipes = ViewBag.AvailableRecipes;


            List<Recipe> AvailableRecipesOnPage = availableRecipes
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.availableRecipesOnPage = AvailableRecipesOnPage;
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }
    }

    /// <summary>
    ///     Adds to the available recipes if the user can make that recipe.
    /// </summary>
    /// <param name="recipes">The recipes.</param>
    private void addToAvailableRecipes(List<Recipe> recipes)
    {
        try
        {
            ViewBag.AvailableRecipes = new List<Recipe>();
            ViewBag.AllRecipes = recipes;
            foreach (var recipe in ViewBag.AllRecipes)
            {
                var add = true;
                recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
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
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }
    }

    /// <summary>
    ///     Compares the name of the recipes so that it can be sorted alphabetically.
    /// </summary>
    /// <param name="recipe1">The recipe1.</param>
    /// <param name="recipe2">The recipe2.</param>
    /// <returns> 0 or 1 based on which recipe name comes first</returns>
    private int CompareRecipesByName(Recipe recipe1, Recipe recipe2)
    {
        return recipe1.Name.CompareTo(recipe2.Name);
    }

    /// <summary>
    ///     Decrements the quantity.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>The View</returns>
    public ActionResult decrementQuantity(string id)
    {
        try
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            var quantity = 0;
            var ingredientID = int.Parse(id);

            quantity = this.getItemQuantity(ingredientID);
            IngredientDAL.decrementQuantity(ingredientID, quantity);
            this.setupIngredientsPage(ViewBag.currentPage);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Gets the item quantity of the ingredient provided.
    /// </summary>
    /// <param name="id">The ingredient id.</param>
    /// <returns>The updated quantity</returns>
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
    ///     Increments the quantity of the ingredient that is provided.
    /// </summary>
    /// <param name="id">The Ingredient Id.</param>
    /// <returns>The ingredients page or login on server connection error</returns>
    public ActionResult incrementQuantity(string id)
    {
        try
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            var quantity = 0;
            var ingredientID = int.Parse(id);

            quantity = this.getItemQuantity(ingredientID);
            IngredientDAL.incrementQuantity(ingredientID, quantity);    
            this.setupIngredientsPage(ViewBag.currentPage);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Removes the ingredient from list.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>The ingredients page or login on server connection error</returns>
    public ActionResult removeIngredient(string id)
    {
        try
        {
            IngredientDAL.RemoveIngredient(int.Parse(id));
            this.setupIngredientsPage(ViewBag.currentPage);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Adds the ingredient to the list.
    /// </summary>
    /// <param name="txtIngredientName">Name of the text ingredient.</param>
    /// <param name="txtQuantity">The text quantity.</param>
    /// <returns>The ingredients page or login on server connection error</returns>
    [HttpPost]
    public ActionResult AddIngredient(string txtIngredientName, string txtQuantity, string measurement)
    {
        var measurements = Enum.GetNames(typeof(Measurement)).ToList();
        ViewBag.Measurements = measurements;
        var regex = new Regex("^[0-9]+$");
        try
        {
            if (txtIngredientName == null || txtQuantity == null || txtIngredientName == "" || txtQuantity == "")
            {
                ViewBag.Error = "Please enter values.";
                return View("AddIngredient", ViewBag.Measurements);
            }

            if (IngredientDAL.getIngredients(txtIngredientName).Count() > 0)
            {
                ViewBag.Error = "Ingredient is already entered.";
                return View("AddIngredient", ViewBag.Measurements);
            }

            if (!regex.Match(txtQuantity).Success)
            {
                ViewBag.Error = "Quantity must be an integer.";
                return View("AddIngredient", ViewBag.Measurements);
            }

            IngredientDAL.addIngredient(txtIngredientName, int.Parse(txtQuantity), measurement, Connection.ConnectionString);
            int totalPages = (int)Math.Ceiling((double)IngredientDAL.getIngredients().Count/ 5);
            this.setupIngredientsPage(totalPages);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    /// Goes to ingredients page.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <returns> the ingredients page with the specified page of ingredients</returns>
    public ActionResult goToIngredientsPage(int? page)
    {
        try
        {
            this.setupIngredientsPage(page);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
            return View("Index");
        }
    }

    private void setupIngredientsPage(int? page)
    {
        const int pageSize = 5; // Change this to the desired page size
        int currentPage = page ?? 1;
        List<Ingredient> allIngredients = IngredientDAL.getIngredients();
        int totalIngredients = allIngredients.Count;
        int totalPages = (int)Math.Ceiling((double)totalIngredients / pageSize);

        List<Ingredient> ingredientsOnPage = allIngredients
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.currentPage = currentPage;
        ViewBag.totalPages = totalPages;
        ViewBag.ingredientsOnPage = ingredientsOnPage;
    }

    /// <summary>
    ///     Goes to RecipesPage
    /// </summary>
    /// <returns>The recipes page or login on server connection error</returns>
    public ActionResult goToRecipePage(int? page)
    {
        try
        {
            this.setupForRecipePage(page);
            if (ViewBag.AvailableRecipes == null)
            {
                TempData["msg"] = "The connection to the server could not be made";
                return View("Index");
            }

            return View("RecipePage", ViewBag.AvailableRecipes);
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Goes to add ingredients page.
    /// </summary>
    /// <returns>The add ingredients page or login on server connection</returns>
    public ActionResult goToAddIngredientsPage()
    {
        var measurements = Enum.GetNames(typeof(Measurement)).ToList();
        ViewBag.Measurements = measurements;
        return View("AddIngredient", ViewBag.Measurements);
    }

    /// <summary>
    ///     Goes to add ingredients page.
    /// </summary>
    /// <returns>The add ingredients page or login on server connection</returns>
    public ActionResult goToPlannedMealsPage()
    {
        ViewBag.AllRecipes = RecipeDAL.getRecipes(Connection.ConnectionString);
        ViewBag.AllRecipes.Sort((Comparison<Recipe>)this.CompareRecipesByName);
    
        ViewBag.Header = "This weeks meals";
        return View("PlannedMealsPage");
    }

    /// <summary>
    ///     Creates the user.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <param name="repeatPassword">The repeat password.</param>
    /// <returns>The login page or register is user was not added or login on server connection error</returns>
    [HttpPost]
    public ActionResult CreateUser(string username, string password, string repeatPassword)
    {
        try
        {
            List<string> list = Database.ContainsUser(username);
            if (list.Count() > 0)
            {
                ViewBag.Error = "Username already exists. Please choose another and try again.";
                return View("Register");
            }

            if (password.Equals(repeatPassword))
            {
                Database.CreateUser(username, password);
                return View("Index");
            }

            ViewBag.Error = "Passwords do not match. Please try again.";
            return View("Register");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Register");
    }

    /// <summary>
    ///     Opens the register.
    /// </summary>
    /// <returns>The register page</returns>
    [HttpPost]
    public ActionResult OpenRegister()
    {
        return View("Register");
    }

    /// <summary>
    ///     Errors this instance.
    /// </summary>
    /// <returns>The view</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    /// <summary>
    /// Logs out this instance.
    /// </summary>
    /// <returns> The login page</returns>
    [HttpPost]
    public IActionResult Logout()
    {
        return View("Index");
    }

    #endregion
}