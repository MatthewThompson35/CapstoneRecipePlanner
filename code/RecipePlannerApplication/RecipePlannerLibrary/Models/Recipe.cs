using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Models
{
    public class Recipe
    {
        public int recipeId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<string> steps { get; set; }
        public List<Ingredient> ingredients { get; set; } = new List<Ingredient>();
    }
}
