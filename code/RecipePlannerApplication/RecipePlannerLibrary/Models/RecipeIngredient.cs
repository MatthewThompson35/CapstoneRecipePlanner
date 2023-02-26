using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Models
{
    /// <summary>
    ///     The Recipe Ingredient class.
    /// </summary>
    public class RecipeIngredient
    {
        /// <summary>
        /// Gets or sets the Recipe Id for the Recipe Ingredient.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// Gets or sets the Ingredient Name for the Recipe Ingredient.
        /// </summary>
        public string IngredientName { get; set; }

        /// <summary>
        /// Gets or sets the Quantity for the Recipe Ingredient.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Measurement for the Recipe Ingredient.
        /// </summary>
        public string Measurement { get; set; }

        /// <summary>
        /// Initializes the RecipeIngredient with the specified recipeId, ingredient name, quantity, and the measurement.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="ingredientName"></param>
        /// <param name="quantity"></param>
        /// <param name="measurement"></param>
        public RecipeIngredient(int recipeId, string ingredientName, int quantity, string measurement)
        {
            this.RecipeId = recipeId;
            this.IngredientName = ingredientName;
            this.Quantity = quantity;
            this.Measurement = measurement;
        }
    }
}
