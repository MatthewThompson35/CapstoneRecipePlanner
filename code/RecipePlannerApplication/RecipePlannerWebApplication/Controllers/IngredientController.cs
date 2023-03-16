using Microsoft.AspNetCore.Mvc;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;

namespace RecipePlannerWebApplication.Controllers
{
    public class IngredientsController : Controller
    {
        /// <summary>
        /// Shows the ingredients page
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>The ingredients page</returns>
        public IActionResult Index()
        {
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }


        /// <summary>
        /// Adds the ingredient to the database and displays it to the user.
        /// </summary>
        /// <param name="txtIngredientName">Name of the text ingredient.</param>
        /// <param name="txtQuantity">The text quantity.</param>
        /// <param name="measurement">The measurement.</param>
        /// <precondition>none</precondition>
        /// <postcondition>Ingredient is added to the database</postcondition>
        /// <returns>The ingredients page</returns>
        public ActionResult AddIngredient(string txtIngredientName, string txtQuantity, string measurement)
        {
            IngredientDAL.addIngredient(txtIngredientName, Int32.Parse(txtQuantity), measurement, Connection.ConnectionString);
            ViewBag.ingredients = IngredientDAL.getIngredients();
            return View("IngredientsPage", ViewBag.ingredients);
        }


        /// <summary>
        /// Logs out of this instance.
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>The login page</returns>
        [HttpPost]
        public IActionResult Logout()
        {
            return View("..//Home//Index");
        }
    }
}

