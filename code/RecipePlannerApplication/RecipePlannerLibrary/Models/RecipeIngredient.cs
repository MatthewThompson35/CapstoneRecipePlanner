using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }

        public RecipeIngredient(int recipeId, string ingredientName, int quantity)
        {
            this.RecipeId = recipeId;
            this.IngredientName = ingredientName;
            this.Quantity = quantity;
        }
    }
}
