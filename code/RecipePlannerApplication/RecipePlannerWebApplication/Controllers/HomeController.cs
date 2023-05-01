using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using RecipePlannerWebApplication.Models;

namespace RecipePlannerWebApplication.Controllers;

/// <summary>
///     Manages the data and functionality for HomeController
/// </summary>
public class HomeController : Controller
{
    #region Data members

    private readonly ILogger<HomeController> _logger;

    #endregion

    #region Constructors

    /// <summary>
    ///     Creates a new instance of a HomeController object with the specified Logger object
    /// </summary>
    /// <param name="logger"></param>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    public HomeController(ILogger<HomeController> logger)
    {
        this._logger = logger;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Takes the User to the login page
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The Login Page</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    ///     Checks the login and goes to recipe page on successful login. Prompts for retry on failed login
    /// </summary>
    /// <param name="ad">The Login object containing user credentials</param>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>
    ///     The Recipe Page view on successful login, Login Page view with error message on failed login or connection
    ///     error
    /// </returns>
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
            const int pageSize = 10;
            var currentPage = page ?? 1;

            ViewBag.currentPage = currentPage;
            ViewBag.AvailableRecipes.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            ViewBag.AllRecipes.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            int totalAvailableRecipes = ViewBag.AvailableRecipes.Count;
            var totalAvailablePages = (int) Math.Ceiling((double) totalAvailableRecipes / pageSize);
            ViewBag.totalAvailablePages = totalAvailablePages;
            ViewBag.totalPages = (int) Math.Ceiling((double) recipes.Count / pageSize);
            ;
            List<Recipe> availableRecipes = ViewBag.AvailableRecipes;
            List<Recipe> allRecipes = ViewBag.AllRecipes;
            var currentAllPage = 1;

            var AvailableRecipesOnPage = availableRecipes
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.availableRecipesOnPage = AvailableRecipesOnPage;

            var AllRecipesOnPage = allRecipes
                .Skip((currentAllPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.AllRecipesOnPage = AllRecipesOnPage;
            ViewBag.CurrentSelectedRadio = "available";
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }
    }

    private void setupForSharedRecipePage(int? page = 1)
    {
        try
        {
            List<SharedRecipe> sharedRecipes = RecipeDAL.getSharedRecipes(Connection.ConnectionString);
            var recipes = new List<Recipe>();

            foreach (var sharedRecipe in sharedRecipes)
            {
                var recipe = sharedRecipe.Recipe;

                recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
                recipe.Steps = RecipeDAL.getStepsForRecipe(recipe.RecipeId, Connection.ConnectionString);
                recipe.Tags = RecipeDAL.getTagsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            }

            this.addToAvailableRecipes(recipes);
            const int pageSize = 10;
            var currentPage = page ?? 1;

            ViewBag.currentPage = currentPage;
            ViewBag.AvailableRecipes.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            ViewBag.AllRecipes.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            int totalAvailableRecipes = ViewBag.AvailableRecipes.Count;
            var totalAvailablePages = (int) Math.Ceiling((double) totalAvailableRecipes / pageSize);
            ViewBag.totalAvailablePages = totalAvailablePages;
            ViewBag.totalPages = (int) Math.Ceiling((double) recipes.Count / pageSize);
            ;
            List<Recipe> availableRecipes = ViewBag.AvailableRecipes;
            List<Recipe> allRecipes = ViewBag.AllRecipes;
            var currentAllPage = 1;

            var AvailableRecipesOnPage = sharedRecipes
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.availableRecipesOnPage = AvailableRecipesOnPage;

            var AllRecipesOnPage = sharedRecipes
                .Skip((currentAllPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.AllSharedRecipesOnPage = AllRecipesOnPage;
            ViewBag.AllRecipes = sharedRecipes;
            ViewBag.currentAllPage = currentPage;
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }
    }

    /// <summary>
    ///     Adds to the available recipes if the user can make that recipe.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>
    ///     If there are available recipes in the database, ViewBag.AvailableRecipes.Count = the amount of recipes
    ///     available
    /// </postcondition>
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
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns> 0 or 1 based on which recipe name comes first</returns>
    private int CompareRecipesByName(Recipe recipe1, Recipe recipe2)
    {
        return recipe1.Name.CompareTo(recipe2.Name);
    }

    /// <summary>
    ///     Decrements the quantity of a given ingredient by its id.
    /// </summary>
    /// <param name="id">The id of the ingredient to decrement quantity for.</param>
    /// <param name="page"> The current page of the ingredient</param>
    /// <precondition>none</precondition>
    /// <postcondition>Ingredient quantity is decremented in the database</postcondition>
    /// <returns>The view of the ingredients page.</returns>
    public ActionResult decrementQuantity(string id, int page)
    {
        try
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            var quantity = 0;
            var ingredientID = int.Parse(id);

            quantity = this.getItemQuantity(ingredientID);
            if (quantity > 1)
            {
                IngredientDAL.decrementQuantity(ingredientID, quantity);
            }
            else
            {
                IngredientDAL.RemoveIngredient(ingredientID, Connection.ConnectionString);
            }

            this.setupIngredientsPage(page);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Adds the needed planned meal ingredients to the shopping list.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>shopping list has needed planned meal ingredients</postcondition>
    /// <returns>Shopping List page or login page on connection error</returns>
    public ActionResult addNeededPlannedMealIngredients()
    {
        try
        {
            var allIngredientsPresent = true;
            var user = ActiveUser.username;
            var totalIngredients = new List<Ingredient>();
            var remainingMeals =
                PlannedMealDal.getRemainingMeals(Connection.ConnectionString);
            List<Ingredient> pantry = IngredientDAL.getIngredients();
            List<Ingredient> shoppingList = ShoppingListDAL.getIngredients(Connection.ConnectionString);

            foreach (var shoppingItem in shoppingList)
            {
                var pantryItem = pantry.Find(i => i.name == shoppingItem.name);

                if (pantryItem != null)
                {
                    pantryItem.quantity += shoppingItem.quantity;
                }
                else
                {
                    pantry.Add(shoppingItem);
                }
            }

            foreach (var recipeId in remainingMeals)
            {
                var recipeIngredients = RecipeDAL.getIngredientsForRecipe(recipeId, Connection.ConnectionString);

                foreach (var ingredient in recipeIngredients)
                {
                    var existingIngredient = totalIngredients.Find(i =>
                        i.name == ingredient.IngredientName && i.measurement == ingredient.Measurement);

                    if (existingIngredient != null)
                    {
                        existingIngredient.quantity += ingredient.Quantity;
                    }
                    else
                    {
                        var id = IngredientDAL.getIngredientId(ingredient.IngredientName);
                        var addIngredient = new Ingredient(user, ingredient.IngredientName, ingredient.Quantity,
                            id,
                            ingredient.Measurement);
                        totalIngredients.Add(addIngredient);
                    }
                }
            }

            foreach (var ingredient in totalIngredients)
            {
                var pantryItem = pantry.Find(i => i.name == ingredient.name);

                if (pantryItem != null)
                {
                    if (ingredient.quantity > pantryItem.quantity)
                    {
                        var quantity = (int) ingredient.quantity - (int) pantryItem.quantity;
                        var shoppingListItem = shoppingList.Find(i => i.name == ingredient.name);

                        if (shoppingListItem != null)
                        {
                            allIngredientsPresent = false;
                            ShoppingListDAL.updateQuantity((int) ingredient.id, quantity, Connection.ConnectionString);
                        }
                        else
                        {
                            allIngredientsPresent = false;
                            ShoppingListDAL.addIngredient(ingredient.name, quantity, ingredient.measurement,
                                Connection.ConnectionString);
                        }
                    }
                }
                else
                {
                    allIngredientsPresent = false;
                    ShoppingListDAL.addIngredient(ingredient.name, (int) ingredient.quantity, ingredient.measurement,
                        Connection.ConnectionString);
                }
            }

            if (allIngredientsPresent)
            {
                ViewBag.error = "There are no ingredients needed";
                this.setupPlannedMeals();
                return View("PlannedMealsPage");
            }

            this.setupShoppingListPage(1);
            return View("ShoppingList");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Adds all planned meal ingredients to the shopping list.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>All planned meal ingredients are in shopping list</postcondition>
    /// <returns>Shopping List page or login page on connection error</returns>
    public ActionResult addAllPlannedMealIngredients()
    {
        try
        {
            var user = ActiveUser.username;
            var totalIngredients = new List<Ingredient>();
            var remainingMeals =
                PlannedMealDal.getRemainingMeals(Connection.ConnectionString);
            List<Ingredient> pantry = IngredientDAL.getIngredients();
            List<Ingredient> shoppingList = ShoppingListDAL.getIngredients(Connection.ConnectionString);

            foreach (var shoppingItem in shoppingList)
            {
                var pantryItem = pantry.Find(i => i.name == shoppingItem.name);

                if (pantryItem != null)
                {
                    pantryItem.quantity += shoppingItem.quantity;
                }
                else
                {
                    pantry.Add(shoppingItem);
                }
            }

            foreach (var recipeId in remainingMeals)
            {
                var recipeIngredients = RecipeDAL.getIngredientsForRecipe(recipeId, Connection.ConnectionString);

                foreach (var ingredient in recipeIngredients)
                {
                    var existingIngredient = totalIngredients.Find(i =>
                        i.name == ingredient.IngredientName && i.measurement == ingredient.Measurement);

                    if (existingIngredient != null)
                    {
                        existingIngredient.quantity += ingredient.Quantity;
                    }
                    else
                    {
                        var id = IngredientDAL.getIngredientId(ingredient.IngredientName);
                        var addIngredient = new Ingredient(user, ingredient.IngredientName, ingredient.Quantity,
                            id,
                            ingredient.Measurement);
                        totalIngredients.Add(addIngredient);
                    }
                }
            }

            foreach (var ingredient in totalIngredients)
            {
                var shoppingListItem = shoppingList.Find(i => i.name == ingredient.name);

                if (shoppingListItem != null)
                {
                    var quantity = (int) shoppingListItem.quantity + (int) ingredient.quantity;
                    ShoppingListDAL.updateQuantity((int) ingredient.id, quantity, Connection.ConnectionString);
                }
                else
                {
                    ShoppingListDAL.addIngredient(ingredient.name, (int) ingredient.quantity, ingredient.measurement,
                        Connection.ConnectionString);
                }
            }

            this.setupShoppingListPage(1);
            return View("ShoppingList");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Decrements the quantity of a given shopping list ingredient by its id.
    /// </summary>
    /// <param name="id">The id of the ingredient to decrement quantity for.</param>
    /// <param name="page"> The current page of the ingredient</param>
    /// <precondition>none</precondition>
    /// <postcondition>Ingredient quantity is decremented in the database</postcondition>
    /// <returns>The view of the shopping list page.</returns>
    public ActionResult decrementShoppingListQuantity(string id, int page)
    {
        try
        {
            var quantity = 0;
            var ingredientID = int.Parse(id);

            quantity = this.getShoppingListItemQuantity(ingredientID);
            if (quantity > 1)
            {
                ShoppingListDAL.decrementQuantity(ingredientID, quantity, Connection.ConnectionString);
            }
            else
            {
                ShoppingListDAL.RemoveIngredient(ingredientID, Connection.ConnectionString);
            }

            this.setupShoppingListPage(page);
            return View("ShoppingList");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Adds the recipe to the database.
    /// </summary>
    /// <param name="recipeName">Name of the recipe.</param>
    /// <param name="description">The description.</param>
    /// <param name="steps">The steps.</param>
    /// <param name="ingredients">The ingredients.</param>
    /// <param name="tags">The tags.</param>
    /// <precondition>none</precondition>
    /// <postcondition>recipe is added to the database</postcondition>
    /// <returns>The Recipe Page or the login page on database error</returns>
    [HttpPost]
    public ActionResult AddRecipe(string recipeName, string description, string steps, string ingredients, string tags)
    {
        try
        {
            var exists = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);
            if (exists.Name == null)
            {
                RecipeDAL.addRecipe(recipeName, description, Connection.ConnectionString);

                var recipeSteps = new List<RecipeStep>();
                var recipeIngredients = new List<RecipeIngredient>();
                var recipeTags = new List<string>();
                var tagsList = new List<string>();
                var tagsSubstrings = tags.Split(':');
                foreach (var substring in tagsSubstrings)
                {
                    tagsList.Add(substring);
                }

                foreach (var tag in tagsList)
                {
                    var tagsStrings = tag.Split(',');
                    for (var i = 0; i < 1; i++)
                    {
                        var Rtag = tagsStrings[0];
                        recipeTags.Add(Rtag);
                    }
                }

                var stepsList = new List<string>();
                var stepsSubstrings = steps.Split(':');
                foreach (var substring in stepsSubstrings)
                {
                    stepsList.Add(substring);
                }

                foreach (var step in stepsList)
                {
                    var stepsStrings = step.Split(',');
                    for (var i = 0; i < 1; i++)
                    {
                        var Rstep =
                            new RecipeStep(RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId,
                                int.Parse(stepsStrings[0]), stepsStrings[1]);
                        recipeSteps.Add(Rstep);
                    }
                }

                var ingredientsList = new List<string>();
                var ingredientsSubstrings = ingredients.Split(':');
                foreach (var substring in ingredientsSubstrings)
                {
                    ingredientsList.Add(substring);
                }

                foreach (var ing in ingredientsList)
                {
                    var IngStrings = ing.Split(',');
                    for (var i = 0; i < 1; i++)
                    {
                        var name = IngStrings[0];
                        var quantity = IngStrings[1];
                        var measurement = IngStrings[2];
                        var Ring = new RecipeIngredient(
                            RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId, IngStrings[0],
                            int.Parse(IngStrings[1]), IngStrings[2]);
                        recipeIngredients.Add(Ring);
                    }
                }

                foreach (var tag in recipeTags)
                {
                    RecipeDAL.addRecipeTag(RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId,
                        tag, Connection.ConnectionString);
                }

                foreach (var step in recipeSteps)
                {
                    RecipeDAL.addRecipeStep((int) step.recipeId, step.stepNumber, step.stepDescription,
                        Connection.ConnectionString);
                }

                foreach (var ing in recipeIngredients)
                {
                    RecipeDAL.addRecipeIngredient(ing.RecipeId, ing.IngredientName,
                        IngredientDAL.getIngredientId(ing.IngredientName), ing.Quantity, ing.Measurement,
                        Connection.ConnectionString);
                }
                this.setupForRecipePage();
                return View("RecipePage");
            }

            ViewBag.test = 1;
            var measurements = Enum.GetNames(typeof(Measurement)).ToList();
            ViewBag.Measurements = measurements;
            ViewBag.error = "Recipe with name was already added";
            ViewBag.page = "pantry";
            return View("AddRecipesPage", ViewBag.Measurements);
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    /// Checks to see if the recipe exists.
    /// </summary>
    /// <param name="recipeName">Name of the recipe.</param>
    /// <returns>True or false</returns>
    public ActionResult CheckRecipeExists(string recipeName)
    {

        bool exists = false;
        var recipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);
        if (recipe.Name != null)
        {
            exists = true;
        }

        return Json(new { Exists = exists});
    }

    /// <summary>
    ///     Gets the quantity of the ingredient with the given id.
    /// </summary>
    /// <param name="id">The ingredient id.</param>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The quantity of the ingredient</returns>
    private int getItemQuantity(int id)
    {
        List<Ingredient> pantry = IngredientDAL.getIngredients();
        var quantity = 0;
        foreach (var item in pantry)
        {
            if (item.id == id)
            {
                quantity = (int) item.quantity;
            }
        }

        return quantity;
    }

    /// <summary>
    ///     Gets the quantity of the shopping list ingredient with the given id.
    /// </summary>
    /// <param name="id">The ingredient id.</param>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The quantity of the ingredient</returns>
    private int getShoppingListItemQuantity(int id)
    {
        List<Ingredient> shoppingList = ShoppingListDAL.getIngredients(Connection.ConnectionString);
        var quantity = 0;
        foreach (var item in shoppingList)
        {
            if (item.id == id)
            {
                quantity = (int) item.quantity;
            }
        }

        return quantity;
    }

    /// <summary>
    ///     Increments the quantity of the ingredient with the given id.
    /// </summary>
    /// <param name="id">The id of the ingredient to increment quantity for.</param>
    /// <param name="page"> The current page of the ingredient</param>
    /// <precondition>none</precondition>
    /// <postcondition>Quantity will be incremented in the database</postcondition>
    /// <returns>The ingredients page or login on server connection error</returns>
    public ActionResult incrementQuantity(string id, int page)
    {
        try
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            var quantity = 0;
            var ingredientID = int.Parse(id);

            quantity = this.getItemQuantity(ingredientID);
            IngredientDAL.incrementQuantity(ingredientID, quantity);
            this.setupIngredientsPage(page);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Increments the quantity of the shopping list ingredient with the given id.
    /// </summary>
    /// <param name="id">The id of the ingredient to increment quantity for.</param>
    /// <param name="page"> The current page of the ingredient</param>
    /// <precondition>none</precondition>
    /// <postcondition>Quantity will be incremented in the database</postcondition>
    /// <returns>The shopping list page or login on server connection error</returns>
    public ActionResult incrementShoppingListQuantity(string id, int page)
    {
        try
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            var quantity = 0;
            var ingredientID = int.Parse(id);

            quantity = this.getShoppingListItemQuantity(ingredientID);
            ShoppingListDAL.incrementQuantity(ingredientID, quantity, Connection.ConnectionString);
            this.setupShoppingListPage(page);
            return View("ShoppingList");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Removes the ingredient from the list.
    /// </summary>
    /// <param name="id">The id of the ingredient to remove.</param>
    /// <param name="page"> The current page of the ingredient</param>
    /// <precondition>none</precondition>
    /// <postcondition>Ingredient will be removed from the database</postcondition>
    /// <returns>The ingredients page or login on server connection error.</returns>
    public ActionResult removeIngredient(string id, int page)
    {
        try
        {
            page = 1;
            IngredientDAL.RemoveIngredient(int.Parse(id), Connection.ConnectionString);
            this.setupIngredientsPage(page);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Removes the shopping list ingredient from the list.
    /// </summary>
    /// <param name="id">The id of the ingredient to remove.</param>
    /// <param name="page"> The current page of the ingredient</param>
    /// <precondition>none</precondition>
    /// <postcondition>Ingredient will be removed from the database</postcondition>
    /// <returns>The shopping list page or login on server connection error.</returns>
    public ActionResult removeShoppingListIngredient(string id, int page)
    {
        try
        {
            page = 1;
            ShoppingListDAL.RemoveIngredient(int.Parse(id), Connection.ConnectionString);
            this.setupShoppingListPage(page);
            return View("ShoppingList");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Adds the ingredient to the the database and is then displayed to the user.
    /// </summary>
    /// <param name="txtIngredientName">The name of the ingredient.</param>
    /// <param name="txtQuantity">The quantity of the ingredient.</param>
    /// <param name="measurement">The measurement unit of the ingredient.</param>
    /// <precondition>parameters must not be null, ingredient must not be in database.</precondition>
    /// <postcondition>Ingredient is added to the database</postcondition>
    /// <returns>The ingredients page or login on server connection error.</returns>
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
                ViewBag.page = "pantry";
                return View("AddIngredient", ViewBag.Measurements);
            }

            if (IngredientDAL.getIngredients(txtIngredientName).Count() > 0)
            {
                ViewBag.Error = "Ingredient is already entered.";
                ViewBag.page = "pantry";
                return View("AddIngredient", ViewBag.Measurements);
            }

            if (!regex.Match(txtQuantity).Success)
            {
                ViewBag.Error = "Quantity must be an integer.";
                ViewBag.page = "pantry";
                return View("AddIngredient", ViewBag.Measurements);
            }

            IngredientDAL.addIngredient(txtIngredientName, int.Parse(txtQuantity), measurement,
                Connection.ConnectionString);
            var totalPages = (int) Math.Ceiling((double) IngredientDAL.getIngredients().Count / 5);
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
    ///     Adds the shopping list ingredient to the the database and is then displayed to the user.
    /// </summary>
    /// <param name="txtIngredientName">The name of the ingredient.</param>
    /// <param name="txtQuantity">The quantity of the ingredient.</param>
    /// <param name="measurement">The measurement unit of the ingredient.</param>
    /// <precondition>parameters must not be null, ingredient must not be in database.</precondition>
    /// <postcondition>Shopping listIngredient is added to the database</postcondition>
    /// <returns>The shopping list page or login on server connection error.</returns>
    [HttpPost]
    public ActionResult AddShoppingListIngredient(string txtIngredientName, string txtQuantity, string measurement)
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
            if (ShoppingListDAL.getIngredients(txtIngredientName, Connection.ConnectionString).Any())
            {
                ViewBag.Error = "Ingredient is already entered.";
                return View("AddIngredient", ViewBag.Measurements);
            }

            if (!regex.Match(txtQuantity).Success)
            {
                ViewBag.Error = "Quantity must be an integer.";
                return View("AddIngredient", ViewBag.Measurements);
            }

            ShoppingListDAL.addIngredient(txtIngredientName, int.Parse(txtQuantity), measurement,
                Connection.ConnectionString);
            var totalPages = (int) Math.Ceiling((double) ShoppingListDAL.getIngredients(Connection.ConnectionString).Count / 5);
            this.setupShoppingListPage(totalPages);
            return View("ShoppingList");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    /// <summary>
    ///     Goes to ingredients page with specified page number.
    /// </summary>
    /// <param name="page">The page number to navigate to.</param>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>Returns the ingredients page with the specified page of ingredients.</returns>
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

    /// <summary>
    ///     Goes to add recipes page.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns> The add recipes page or login on connection error</returns>
    public ActionResult goToAddRecipesPage()
    {
        try
        {
            ViewBag.test = 1;
            var measurements = Enum.GetNames(typeof(Measurement)).ToList();
            ViewBag.Measurements = measurements;
            ViewBag.page = "pantry";
            return View("AddRecipesPage", ViewBag.Measurements);
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
            return View("Index");
        }
    }

    /// <summary>
    ///     Goes to shopping list page with specified page number.
    /// </summary>
    /// <param name="page">The page number to navigate to.</param>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>Returns the shopping list page with the specified page of ingredients.</returns>
    public ActionResult goToShoppingListPage(int? page)
    {
        try
        {
            this.setupShoppingListPage(page);
            return View("ShoppingList");
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
        var currentPage = page ?? 1;
        List<Ingredient> allIngredients = IngredientDAL.getIngredients();
        var totalIngredients = allIngredients.Count;
        var totalPages = (int) Math.Ceiling((double) totalIngredients / pageSize);

        var ingredientsOnPage = allIngredients
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.currentPage = currentPage;
        ViewBag.totalPages = totalPages;
        ViewBag.ingredientsOnPage = ingredientsOnPage;
    }

    private void setupShoppingListPage(int? page)
    {
        const int pageSize = 5;
        var currentPage = page ?? 1;
        List<Ingredient> allIngredients = IngredientDAL.GetIngredientsFromShoppingList();
        var totalIngredients = allIngredients.Count;
        var totalPages = (int) Math.Ceiling((double) totalIngredients / pageSize);

        var ingredientsOnPage = allIngredients
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.currentPage = currentPage;
        ViewBag.totalPages = totalPages;
        ViewBag.ingredientsOnPage = ingredientsOnPage;
    }

    /// <summary>
    ///     Goes to RecipesPage that displays the available recipes by default with the specified page number
    /// </summary>
    /// <param name="page">The page number to navigate to.</param>
    /// <precondition>ViewBag.AvailableRecipes != null </precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The recipes page with the specified page or login on server connection error</returns>
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
    ///     Goes to RecipesPage that displays all recipes by default with the specified page number
    /// </summary>
    /// <precondition>ViewBag.AvailableRecipes != null</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The recipes page with the specified page or login on server connection error</returns>
    public ActionResult goToRecipePageAll(int? page)
    {
        try
        {
            this.setupForRecipePageAll(page);
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

    private void setupForRecipePageAll(int? page)
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

            var currentPage = 1;
            this.addToAvailableRecipes(recipes);
            const int pageSize = 10;
            var currentAllPage = page ?? 1;

            ViewBag.currentAllPage = currentAllPage;
            ViewBag.AvailableRecipes.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            ViewBag.AllRecipes.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            int totalAvailableRecipes = ViewBag.AvailableRecipes.Count;
            var totalAvailablePages = (int) Math.Ceiling((double) totalAvailableRecipes / pageSize);
            ViewBag.totalAvailablePages = totalAvailablePages;
            ViewBag.totalPages = (int) Math.Ceiling((double) recipes.Count / pageSize);
            List<Recipe> availableRecipes = ViewBag.AvailableRecipes;
            List<Recipe> allRecipes = ViewBag.AllRecipes;

            var AvailableRecipesOnPage = availableRecipes
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.availableRecipesOnPage = AvailableRecipesOnPage;

            var AllRecipesOnPage = allRecipes
                .Skip((currentAllPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.AllRecipesOnPage = AllRecipesOnPage;
            ViewBag.CurrentSelectedRadio = "all";
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }
    }

    /// <summary>
    ///     Goes to RecipesPage that displays all recipes by default with the specified page number
    /// </summary>
    /// <precondition>ViewBag.AvailableRecipes != null</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The recipes page with the specified page or login on server connection error</returns>
    public ActionResult goToSharedRecipePageAll(int? page)
    {
        try
        {
            this.setupForSharedRecipePageAll(page);
            if (ViewBag.AvailableRecipes == null)
            {
                TempData["msg"] = "The connection to the server could not be made";
                return View("Index");
            }

            return View("SharedRecipes");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }

        return View("Index");
    }

    private void setupForSharedRecipePageAll(int? page)
    {
        try
        {
            List<SharedRecipe> sharedRecipes = RecipeDAL.getSharedRecipes(Connection.ConnectionString);
            var recipes = new List<Recipe>();

            foreach (var sharedRecipe in sharedRecipes)
            {
                var recipe = sharedRecipe.Recipe;
                recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
                recipe.Steps = RecipeDAL.getStepsForRecipe(recipe.RecipeId, Connection.ConnectionString);
                recipe.Tags = RecipeDAL.getTagsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            }

            var currentPage = 1;
            this.addToAvailableRecipes(recipes);
            const int pageSize = 10;
            var currentSharedPage = page ?? 1;

            ViewBag.currentSharedPage = currentSharedPage;

            ViewBag.AllRecipes = sharedRecipes;
            ViewBag.totalPages = (int) Math.Ceiling((double) sharedRecipes.Count / pageSize);
            var allRecipes = sharedRecipes;

            var AllRecipesOnPage = allRecipes
                .Skip((currentSharedPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.AllSharedRecipesOnPage = AllRecipesOnPage;
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
        }
    }

    /// <summary>
    ///     Adds the planned meal with the specified data to the database.
    /// </summary>
    /// <param name="recipeId">The id for the recipe.</param>
    /// <param name="week">The week of the meal.</param>
    /// <param name="day">The day of the meal.</param>
    /// <param name="type">The meal type</param>
    /// <precondition>none</precondition>
    /// <postcondition>Meal is added to the specified slot in the database</postcondition>
    /// <returns>The Recipe Page Defaulted to page one</returns>
    public ActionResult addPlannedMeal(int recipeId, string week, string day, string type)
    {
        var recipeID = recipeId;
        var Week = week;
        var Day = day;
        var Type = type;
        DayOfWeek dayOfWeek;
        Enum.TryParse(day, out dayOfWeek);
        DateTime date;
        if (week.Equals("This Week"))
        {
            date = Util.GetDateOfWeekDay(dayOfWeek, "this");
        }
        else
        {
            date = Util.GetDateOfWeekDay(dayOfWeek, "next");
        }

        if (PlannedMealDal.exists(Connection.ConnectionString, Type, date))
        {
            ViewBag.day = day;
            ViewBag.type = type;
            ViewBag.date = date;
            ViewBag.recipeId = recipeId;
            return View("OverwriteConformation");
        }

        PlannedMealDal.addPlannedMeal(Connection.ConnectionString, recipeId, day, type, date);
        this.setupForRecipePage();
        if (ViewBag.day == null)
        {
            ViewBag.day = "Monday";
        }

        if (ViewBag.type == null)
        {
            ViewBag.type = "Breakfast";
        }

        if (ViewBag.week == null)
        {
            ViewBag.week = "This Week";
        }

        if (ViewBag.AvailableRecipes == null)
        {
            TempData["msg"] = "The connection to the server could not be made";
            return View("Index");
        }

        return View("RecipePage", ViewBag.AvailableRecipes);
    }

    public ActionResult addPlannedMealPlannedMealsPage(int recipeId, string week, string day, string type)
    {
        var recipeID = recipeId;
        var Week = week;
        var Day = day;
        var Type = type;
        DayOfWeek dayOfWeek;
        Enum.TryParse(day, out dayOfWeek);
        DateTime date;
        if (week.Equals("This Week"))
        {
            date = Util.GetDateOfWeekDay(dayOfWeek, "this");
        }
        else
        {
            date = Util.GetDateOfWeekDay(dayOfWeek, "next");
        }

        if (PlannedMealDal.exists(Connection.ConnectionString, Type, date))
        {
            ViewBag.day = day;
            ViewBag.type = type;
            ViewBag.date = date;
            ViewBag.recipeId = recipeId;
            return View("OverwriteConformation");
        }

        PlannedMealDal.addPlannedMeal(Connection.ConnectionString, recipeId, day, type, date);
        this.setupForRecipePage();
        if (ViewBag.day == null)
        {
            ViewBag.day = "Monday";
        }

        if (ViewBag.type == null)
        {
            ViewBag.type = "Breakfast";
        }

        if (ViewBag.week == null)
        {
            ViewBag.week = "This Week";
        }

        if (ViewBag.AvailableRecipes == null)
        {
            TempData["msg"] = "The connection to the server could not be made";
            return View("Index");
        }
        this.setupPlannedMeals();
        return View("PlannedMealsPage");
    }

    /// <summary>
    ///     Overwrites the recipe for the specified day and meal type.
    /// </summary>
    /// <param name="day">The day of the week.</param>
    /// <param name="type">The type of meal (e.g. breakfast, lunch, dinner).</param>
    /// <param name="date">The date of the meal.</param>
    /// <param name="recipeId">The ID of the recipe to use.</param>
    /// <precondition>none</precondition>
    /// <postcondition>Meal at specified time is overwritten in the database</postcondition>
    /// <returns>The recipes page or login on server connection error.</returns>
    public ActionResult overwriteAddedMeal(string day, string type, string date, int recipeId)
    {
        var Date = DateTime.Parse(date);
        PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, day, type, Date, recipeId);
        return this.goToRecipePage(1);
    }

    /// <summary>
    ///     Updates the planned meal for a given recipe on a specific week day.
    /// </summary>
    /// <param name="recipeId">The ID of the recipe to update.</param>
    /// <param name="week">The week to update the planned meal for.</param>
    /// <param name="day">The day of the week to update the planned meal for.</param>
    /// <param name="type">The type of meal to update (e.g. breakfast, lunch, dinner).</param>
    /// <precondition>none</precondition>
    /// <postcondition>The meal is updated in the database to match the correct values</postcondition>
    /// <returns>The updated recipes page or login on server connection error.</returns>
    public ActionResult UpdateThisWeeksMeal(int recipeId, string week, string day, string type)
    {
        var recipeID = recipeId;
        var Week = week;
        var Day = day;
        var Type = type;
        DayOfWeek dayOfWeek;
        Enum.TryParse(day, out dayOfWeek);
        DateTime date;
        if (week.Equals("This Week"))
        {
            date = Util.GetDateOfWeekDay(dayOfWeek, "this");
        }
        else
        {
            date = Util.GetDateOfWeekDay(dayOfWeek, "next");
        }

        PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, Day, Type, date, recipeID);
        this.setupForRecipePage();
        if (ViewBag.AvailableRecipes == null)
        {
            TempData["msg"] = "The connection to the server could not be made";
            return View("Index");
        }

        return View("RecipePage", ViewBag.AvailableRecipes);
    }

    /// <summary>
    ///     Goes to add ingredients page.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The add ingredients page or login on bad server connection</returns>
    public ActionResult goToAddIngredientsPage()
    {
        var measurements = Enum.GetNames(typeof(Measurement)).ToList();
        ViewBag.Measurements = measurements;
        ViewBag.page = "pantry";
        return View("AddIngredient", ViewBag.Measurements);
    }

    /// <summary>
    ///     Goes to add ingredients page for shopping list.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The add ingredients page or login on bad server connection</returns>
    public ActionResult goToAddShoppingListIngredientsPage()
    {
        var measurements = Enum.GetNames(typeof(Measurement)).ToList();
        ViewBag.Measurements = measurements;
        ViewBag.page = "shopping";
        return View("AddIngredient", ViewBag.Measurements);
    }

    /// <summary>
    ///     Goes to shared recipes page.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The shared recipes page or login on bad server connection</returns>
    public ActionResult goToSharedRecipesPage()
    {
        this.setupForSharedRecipePage();
        return View("SharedRecipes", ViewBag.Measurements);
    }

    /// <summary>
    ///     Toggles the week for Planned Meals page.
    /// </summary>
    /// <param name="currentWeek">The current week. (This week or next week)</param>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The planned meals page based on which week is given</returns>
    public ActionResult ToggleWeek(string currentWeek)
    {
        if (currentWeek.Equals("Next Week"))
        {
            this.goToPlannedMealsPage();
        }
        else
        {
            this.goToPlannedMealsPageNextWeek();
        }

        return View("PlannedMealsPage");
    }

    /// <summary>
    ///     Gets the name of the recipe at the specified planned meal slot.
    /// </summary>
    /// <param name="day">The day.</param>
    /// <param name="mealType">Type of the meal.</param>
    /// <param name="week">The week.</param>
    /// <precondition>none</precondition>
    /// <postcondition>The planned meal slot will be updated with the recipe name</postcondition>
    /// <returns>The recipeName and RecipeId as a json Result</returns>
    public JsonResult GetRecipeName(string day, string mealType, string week)
    {
        try
        {
            var ThisWeeksMeals = new Dictionary<(string, string), int>();
            if (week.Equals("Next Week"))
            {
                ThisWeeksMeals = PlannedMealDal.getNextWeeksMeals(Connection.ConnectionString);
            }
            else
            {
                ThisWeeksMeals = PlannedMealDal.getThisWeeksMeals(Connection.ConnectionString);
            }

            var recipeId = ThisWeeksMeals[(day, mealType)];
            var allRecipes = RecipeDAL.getRecipes(Connection.ConnectionString);
            var recipeName = "";
            foreach (var recipe in allRecipes)
            {
                if (recipe.RecipeId == recipeId)
                {
                    recipeName = recipe.Name;
                }
            }

            ViewBag.Header = "This weeks meals";
            return Json(new {RecipeId = recipeId, RecipeName = recipeName});
        }
        catch (Exception ex)
        {
            var recipeId = "You have not yet added a meal for this time";
            return Json(new {RecipeId = recipeId, RecipeName = "You Have not yet added a meal for this time"});
        }
    }

    /// <summary>
    ///     Removes the meal at the specified planned meal slot.
    /// </summary>
    /// <param name="day">The day.</param>
    /// <param name="mealType">Type of the meal.</param>
    /// <param name="week">The week.</param>
    /// <precondition>none</precondition>
    /// <postcondition>The planned meal is removed from the database</postcondition>
    /// <returns>Returns a Json Result that gives the string that is updated in place of the removed recipe</returns>
    public JsonResult RemoveThisWeeksMeal(string day, string mealType, string week)
    {
        try
        {
            var ThisWeeksMeals = new Dictionary<(string, string), int>();
            if (week.Equals("Next Week"))
            {
                ThisWeeksMeals = PlannedMealDal.getNextWeeksMeals(Connection.ConnectionString);
            }
            else
            {
                ThisWeeksMeals = PlannedMealDal.getThisWeeksMeals(Connection.ConnectionString);
            }

            var recipeId = ThisWeeksMeals[(day, mealType)];
            DayOfWeek dayOfWeek;
            Enum.TryParse(day, out dayOfWeek);
            DateTime date;
            if (week.Equals("Next Week"))
            {
                date = Util.GetDateOfWeekDay(dayOfWeek, "next");
            }
            else
            {
                date = Util.GetDateOfWeekDay(dayOfWeek, "this");
            }

            PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, recipeId, day, mealType, date);

            ViewBag.Header = "This weeks meals";
            return Json(new {RecipeId = recipeId, RecipeName = "You Have not yet added a meal for this time"});
        }
        catch (Exception ex)
        {
            try
            {
                var ThisWeeksMeals = PlannedMealDal.getThisWeeksMeals(Connection.ConnectionString);
                var recipeId = ThisWeeksMeals[(day, mealType)];
                var allRecipes = RecipeDAL.getRecipes(Connection.ConnectionString);
                var recipeName = "";
                foreach (var recipe in allRecipes)
                {
                    if (recipe.RecipeId == recipeId)
                    {
                        recipeName = recipe.Name;
                    }
                }

                return Json(new {RecipeName = recipeName});
            }
            catch (Exception ex2)
            {
                return Json(new {RecipeName = "You Have not yet added a meal for this time"});
            }
        }
    }

    /// <summary>
    ///     Goes to planned meals page.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The planned meals page or login on bad server connection</returns>
    public ActionResult goToPlannedMealsPage()
    {
        ViewBag.CurrentWeek = "This Week";
        List<Recipe> recipes = RecipeDAL.getRecipes(Connection.ConnectionString);
        foreach (var recipe in recipes)
        {
            recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            recipe.Steps = RecipeDAL.getStepsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            recipe.Tags = RecipeDAL.getTagsForRecipe(recipe.RecipeId, Connection.ConnectionString);
        }

        ViewBag.AllRecipes = recipes;
        var breakfast = new List<string>();
        var lunch = new List<string>();
        var dinner = new List<string>();
        var dictionary = PlannedMealDal.getThisWeeksMeals(Connection.ConnectionString);
        var daysOfWeek = new List<string>
            {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Breakfast", "This Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            breakfast.Add(recipeName);
        }

        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Lunch", "This Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            lunch.Add(recipeName);
        }

        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Dinner", "This Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            dinner.Add(recipeName);
        }

        ViewBag.DefaultValues = breakfast;
        ViewBag.Lunch = lunch;
        ViewBag.Dinner = dinner;
        ViewBag.Header = "This weeks meals";
        ViewBag.CurrentWeek = "This Week";
        return View("PlannedMealsPage");
    }

    /// <summary>
    ///     Purchases all shopping list and adds it to pantry.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>Pantry is updated with shopping list values</postcondition>
    /// <returns>Ingredients Page or login on bag connection</returns>
    public ActionResult purchaseAllShoppingList()
    {
        try
        {
            List<Ingredient> list = ShoppingListDAL.getIngredients(Connection.ConnectionString);
            List<Ingredient> pantry = IngredientDAL.getIngredients();

            foreach (var ingredient in list)
            {
                var found = false;
                foreach (var pantryIngredient in pantry)
                {
                    if (pantryIngredient.id.Equals(ingredient.id))
                    {
                        var quantity = (int) pantryIngredient.quantity + (int) ingredient.quantity;
                        found = true;
                        IngredientDAL.updateQuantity((int) pantryIngredient.id, quantity);
                        break;
                    }
                }

                if (!found)
                {
                    IngredientDAL.addIngredient(ingredient.name, (int) ingredient.quantity, ingredient.measurement,
                        Connection.ConnectionString);
                }

                ShoppingListDAL.removeAll(Connection.ConnectionString);
            }

            this.setupIngredientsPage(1);
            return View("IngredientsPage");
        }
        catch (Exception ex)
        {
            TempData["msg"] = "The connection to the server could not be made";
            return View("Index");
        }
    }

    private void setupPlannedMeals()
    {
        ViewBag.CurrentWeek = "This Week";
        List<Recipe> recipes = RecipeDAL.getRecipes(Connection.ConnectionString);
        foreach (var recipe in recipes)
        {
            recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            recipe.Steps = RecipeDAL.getStepsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            recipe.Tags = RecipeDAL.getTagsForRecipe(recipe.RecipeId, Connection.ConnectionString);
        }

        ViewBag.AllRecipes = recipes;
        var breakfast = new List<string>();
        var lunch = new List<string>();
        var dinner = new List<string>();
        var dictionary = PlannedMealDal.getThisWeeksMeals(Connection.ConnectionString);
        var daysOfWeek = new List<string>
            {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Breakfast", "This Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            breakfast.Add(recipeName);
        }

        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Lunch", "This Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            lunch.Add(recipeName);
        }

        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Dinner", "This Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            dinner.Add(recipeName);
        }

        ViewBag.DefaultValues = breakfast;
        ViewBag.Lunch = lunch;
        ViewBag.Dinner = dinner;
        ViewBag.Header = "This weeks meals";
        ViewBag.CurrentWeek = "This Week";
    }

    /// <summary>
    ///     Goes to next week's planned meal page.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns>The next week's planned meal page or login on bad server connection</returns>
    public ActionResult goToPlannedMealsPageNextWeek()
    {
        ViewBag.CurrentWeek = "Next Week";
        List<Recipe> recipes = RecipeDAL.getRecipes(Connection.ConnectionString);
        foreach (var recipe in recipes)
        {
            recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            recipe.Steps = RecipeDAL.getStepsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            recipe.Tags = RecipeDAL.getTagsForRecipe(recipe.RecipeId, Connection.ConnectionString);
        }

        ViewBag.AllRecipes = recipes;
        var breakfast = new List<string>();
        var daysOfWeek = new List<string>
            {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
        var lunch = new List<string>();
        var dinner = new List<string>();
        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Breakfast", "Next Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            breakfast.Add(recipeName);
        }

        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Lunch", "Next Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            lunch.Add(recipeName);
        }

        foreach (var day in daysOfWeek)
        {
            var json = this.GetRecipeName(day, "Dinner", "Next Week");
            var recipeName = (string) json.Value.GetType().GetProperty("RecipeName").GetValue(json.Value);
            dinner.Add(recipeName);
        }

        ViewBag.DefaultValues = breakfast;
        ViewBag.Lunch = lunch;
        ViewBag.Dinner = dinner;
        ViewBag.Header = "Next weeks meals";
        ViewBag.CurrentWeek = "Next Week";
        return View("PlannedMealsPage");
    }

    /// <summary>
    ///     Creates the user.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <param name="repeatPassword">The repeat password.</param>
    /// <precondition>none</precondition>
    /// <postcondition>The user is added to the database</postcondition>
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

            if (username == null)
            {
                ViewBag.Error = "Please enter a username";
                return View("Register");
            }

            if (password == null)
            {
                ViewBag.Error = "Please enter a password";
                return View("Register");
            }

            if (repeatPassword == null)
            {
                ViewBag.Error = "Please re-enter your password";
                return View("Register");
            }

            if (!password.Equals(repeatPassword))
            {
                ViewBag.Error = "The passwords do not match";
                return View("Register");
            }

            if (password != null && repeatPassword != null && password.Equals(repeatPassword))
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
            return View("Register");
        }

        return View("Register");
    }

    /// <summary>
    ///     Opens the register page.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
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
    ///     Logs out of this instance.
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns> The login page</returns>
    [HttpPost]
    public IActionResult Logout()
    {
        return View("Index");
    }

    /// <summary>
    ///     Marks recipe as cooked and removes ingredients from pantry
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns> The recipe page</returns>
    [HttpPost]
    public IActionResult CookMeal(int recipeID)
    {
        var totalIngredients = IngredientDAL.getIngredients();
        foreach (var ingredient in
                 RecipeDAL.getIngredientsForRecipe(recipeID, Connection.ConnectionString))
        {
            var existingIngredient = totalIngredients.Find(i =>
                i.name == ingredient.IngredientName && i.measurement == ingredient.Measurement);

            if (existingIngredient != null)
            {
                if (existingIngredient.quantity - ingredient.Quantity > 0)
                {
                    IngredientDAL.updateQuantity((int) existingIngredient.id,
                        (int) existingIngredient.quantity - ingredient.Quantity);
                }
                else
                {
                    IngredientDAL.RemoveIngredient((int) existingIngredient.id, Connection.ConnectionString);
                }
            }
        }

        this.setupIngredientsPage(1);
        return View("IngredientsPage");
    }

    /// <summary>
    /// Takes you to cook meal confirmation.
    /// </summary>
    /// <param name="recipeID">The recipe identifier.</param>
    /// <returns>Cook meal confirmation page</returns>
    [HttpPost]
    public IActionResult CookMealConfirmation(int recipeID)
    {
        ViewBag.id = recipeID;
        bool hasAllIngredients = true;

        var totalIngredients = IngredientDAL.getIngredients();
        foreach (var ingredient in
                 RecipeDAL.getIngredientsForRecipe(recipeID, Connection.ConnectionString))
        {
            var existingIngredient = totalIngredients.Find(i =>
                i.name == ingredient.IngredientName && i.measurement == ingredient.Measurement);

            if (existingIngredient == null || existingIngredient.quantity - ingredient.Quantity < 0)
            {
                hasAllIngredients = false;
            }
        }

        if (hasAllIngredients)
        {
            return View("CookMealConfirmation");
        }

        return View("MissingIngredientsConfirmation");
    }

    /// <summary>
    ///     Opens the share recipe form
    /// </summary>
    /// <precondition>none</precondition>
    /// <postcondition>none</postcondition>
    /// <returns> The recipe page</returns>
    [HttpPost]
    public IActionResult ShareMeal(int sharedRecipeID)
    {
        var username = Request.Form["txtUsername"].ToString();
        var isValid = Database.ContainsUser(username).Count != 0;
        var recipe =
            new SharedRecipe(
                RecipeDAL.getRecipeByName(RecipeDAL.getRecipeNameById(sharedRecipeID, Connection.ConnectionString),
                    Connection.ConnectionString), ActiveUser.username, username);
        if (RecipeDAL.ContainsSharedRecipe(recipe).Count > 0)
        {
            ViewBag.ErrorMessage = "You have already shared this recipe with " + username;
            this.setupForRecipePage();
            return View("RecipePage");
        }

        if (isValid)
        {
            if (sharedRecipeID == 0)
            {
                ViewBag.ErrorMessage = "Please select a recipe and try again.";
                this.setupForRecipePage();
                return View("RecipePage");
            }

            ViewBag.ErrorMessage = "";
            RecipeDAL.shareRecipe(username, sharedRecipeID, Connection.ConnectionString);
            TempData["SharedRecipeID"] = sharedRecipeID;
            return RedirectToAction("RecipePage");
        }

        ViewBag.ErrorMessage = "This is not a valid Username. Enter another and try again.";
        this.setupForRecipePage();
        return View("RecipePage");
    }

    /// <summary>
    /// Shows the recipe page with shared recipe.
    /// </summary>
    /// <returns>The current recipe page</returns>
    public IActionResult RecipePage()
    {
        var sharedRecipeID = 0;
        if (TempData["SharedRecipeID"] != null)
        {
            sharedRecipeID = (int) TempData["SharedRecipeID"];
        }

        List<SharedRecipe> allRecipes = RecipeDAL.getSharedRecipes(Connection.ConnectionString);
        var sharedRecipe = allRecipes.FirstOrDefault(r => r.Recipe.RecipeId == sharedRecipeID);
        ViewBag.AllRecipes = allRecipes;
        ViewBag.SharedRecipe = sharedRecipe;

        this.setupForRecipePage();
        return View();
    }

    #endregion
}