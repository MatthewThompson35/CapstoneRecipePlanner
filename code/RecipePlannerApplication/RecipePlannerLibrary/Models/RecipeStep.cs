using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Models
{
    public class RecipeStep
    {
        public int recipeId { get; set; }
        public int stepNumber { get; set; }
        public string stepDescription { get; set; }

        public RecipeStep(int recipeId, int stepNumber, string stepDescription)
        {
            this.recipeId = recipeId;
            this.stepNumber = stepNumber;
            this.stepDescription = stepDescription;
        }
    }
}
