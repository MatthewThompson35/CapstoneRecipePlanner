using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RecipeStep> Steps { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }

        public Recipe(int recipeId, string name, string description)
        {
            this.RecipeId = recipeId;
            this.Name = name;
            this.Description = description;
            this.Steps = new List<RecipeStep>();
            this.Ingredients = new List<RecipeIngredient>();
        }

    }
}
