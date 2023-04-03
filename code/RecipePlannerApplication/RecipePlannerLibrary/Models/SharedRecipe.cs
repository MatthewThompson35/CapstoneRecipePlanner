namespace RecipePlannerLibrary.Models
{
    /// <summary>
    ///     The Shared Recipe class.
    /// </summary>
    public class SharedRecipe
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the Recipe Id for the Shared Recipe.
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        ///     Gets or sets the username of the user sharing the recipe.
        /// </summary>
        public string SenderUsername { get; set; }

        /// <summary>
        ///     Gets or sets the username of the user receiving the recipe.
        /// </summary>
        public string ReceiverUsername { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes the Shared Recipe with the specified recipe id, sender, and receiver.
        /// </summary>
        /// <param name="recipe">The recipe being shared.</param>
        /// <param name="senderUsername">The user sending the recipe.</param>
        /// <param name="receiverUsername">The user receiving the recipe.</param>
        /// <precondition> none </precondition>
        /// <postcondition>
        ///     this.RecipeId = recipeId && this.SenderUsername = senderUsername && this.receiverUsername =
        ///     receiverUsername
        /// </postcondition>
        public SharedRecipe(Recipe recipe, string senderUsername, string receiverUsername)
        {
            this.Recipe = recipe;
            this.SenderUsername = senderUsername;
            this.ReceiverUsername = receiverUsername;
        }

        #endregion
    }
}