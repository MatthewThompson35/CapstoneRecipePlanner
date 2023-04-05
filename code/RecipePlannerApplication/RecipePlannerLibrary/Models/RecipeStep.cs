using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Models
{
    /// <summary>
    ///     The Recipe Step class for the recipe.
    /// </summary>
    public class RecipeStep
    {
        /// <summary>
        /// Gets or sets the Recipe Id for the Recipe Step.
        /// </summary>
        public int? recipeId { get; set; }

        /// <summary>
        /// Gets or sets the Step Number for the Recipe Step.
        /// </summary>
        public int stepNumber { get; set; }

        /// <summary>
        /// Gets or sets the Step Description for the Recipe Step.
        /// </summary>
        public string stepDescription { get; set; }

        /// <summary>
        ///     Initializes the Recipe Step with the specified recipe Id, step number and step description.
        /// </summary>
        /// <param name="recipeId">The recipe id of the Recipe Step.</param>
        /// <param name="stepNumber">The step number of the Recipe Step.</param>
        /// <param name="stepDescription">The step description of the Recipe Step.</param>
        /// <precondition>none</precondition>
        /// <postcondition>recipeID = recipeId && stepNumber = stepNumber && stepDescription = stepDescription</postcondition>
        public RecipeStep(int recipeId, int stepNumber, string stepDescription)
        {
            this.recipeId = recipeId;
            this.stepNumber = stepNumber;
            this.stepDescription = stepDescription;
        }

        /// <summary>
        ///     Initializes the Recipe Step with the specified step number and step description.
        /// </summary>
        /// <param name="stepNumber">the step number</param>
        /// <param name="stepDescription">the step description</param>
        public RecipeStep(int stepNumber, string stepDescription)
        {
            this.stepNumber = stepNumber;
            this.stepDescription = stepDescription;
        }
    }
}
