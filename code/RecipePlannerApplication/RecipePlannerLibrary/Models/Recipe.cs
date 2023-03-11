using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Models
{
    /// <summary>
    ///     The Recipe class.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets or sets the Recipe Id for the Recipe.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Recipe.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description for the Recipe.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Steps for the Recipe.
        /// </summary>
        public List<RecipeStep> Steps { get; set; }

        /// <summary>
        /// Gets or sets the Ingredients for the Recipe.
        /// </summary>
        public List<RecipeIngredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the Tags for the Recipe.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        ///     Initializes the Recipe with the specified recipe id, the recipe name, and the description.
        /// </summary>
        /// <param name="recipeId">The recipe id of the recipe.</param>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The description of the recipe.</param>
        public Recipe(int recipeId, string name, string description)
        {
            this.RecipeId = recipeId;
            this.Name = name;
            this.Description = description;
            this.Steps = new List<RecipeStep>();
            this.Ingredients = new List<RecipeIngredient>();
            this.Tags = new List<string>();
        }

        public Recipe(int recipeId, string name) 
        {
            this.RecipeId = recipeId;
            this.Name = name;
        }

        public Recipe()
        {

        }

    }
}
