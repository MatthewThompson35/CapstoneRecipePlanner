using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
        /// <precondition>none</precondition>
        /// <postcondition> this.RecipeId = recipeId && this.IngredientName = ingredientName && this.Quantity = quantity && this.Measurement = measurement</postcondition>
        public RecipeIngredient(int recipeId, string ingredientName, int quantity, string measurement)
        {
            this.RecipeId = recipeId;
            this.IngredientName = ingredientName;
            this.Quantity = quantity;
            this.Measurement = measurement;
        }

        /// <summary>
        ///     Initializes the RecipeIngredient with the specified ingredient name, quantity, and the measurement.
        /// </summary>
        /// <param name="ingredientName">the ingredient name</param>
        /// <param name="quantity">the quantity</param>
        /// <param name="measurement">the measurement</param>
        public RecipeIngredient(string ingredientName, int quantity, string measurement)
        {
            this.IngredientName = ingredientName;
            this.Quantity = quantity;
            this.Measurement = measurement;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            RecipeIngredient other = (RecipeIngredient)obj;
            return IngredientName == other.IngredientName && Quantity == other.Quantity && Measurement == other.Measurement;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (IngredientName != null ? IngredientName.GetHashCode() : 0);
                hash = hash * 23 + Quantity.GetHashCode();
                hash = hash * 23 + (Measurement != null ? Measurement.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
