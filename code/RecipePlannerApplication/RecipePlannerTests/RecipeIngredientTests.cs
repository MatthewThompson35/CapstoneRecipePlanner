namespace RecipePlannerTests
{
    /// <summary>
    /// Test the recipe Ingredients class
    /// </summary>
    [TestClass]
    public class RecipeIngredientTests
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            int recipeId = 1;
            string ingredientName = "Flour";
            int quantity = 2;
            string measurement = "G";

            RecipeIngredient ingredient = new RecipeIngredient(recipeId, ingredientName, quantity, measurement);

            Assert.AreEqual(recipeId, ingredient.RecipeId);
            Assert.AreEqual(ingredientName, ingredient.IngredientName);
            Assert.AreEqual(quantity, ingredient.Quantity);
            Assert.AreEqual(measurement, ingredient.Measurement);
        }
    }
}
