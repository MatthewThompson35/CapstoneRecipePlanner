namespace RecipePlannerTests
{
    /// <summary>
    /// Tests the recipe Class
    /// </summary>
    [TestClass]
    public class RecipeTests
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            int recipeId = 1;
            string name = "Chocolate Cake";
            string description = "A delicious chocolate cake recipe.";

            Recipe recipe = new Recipe(recipeId, name, description);

            Assert.AreEqual(recipeId, recipe.RecipeId);
            Assert.AreEqual(name, recipe.Name);
            Assert.AreEqual(description, recipe.Description);
            Assert.AreEqual(0, recipe.Steps.Count);
            Assert.AreEqual(0, recipe.Ingredients.Count);
        }

        /// <summary>
        /// Tests that the constructor sets recipe id and Name.
        /// </summary>
        [TestMethod]
        public void RecipeConstructor_SetsRecipeIdAndName()
        {
            // Arrange
            int recipeId = 1;
            string name = "Test Recipe";

            // Act
            Recipe recipe = new Recipe(recipeId, name);

            // Assert
            Assert.AreEqual(recipeId, recipe.RecipeId);
            Assert.AreEqual(name, recipe.Name);
        }

        /// <summary>
        /// Test that getting Tags returns expected tags.
        /// </summary>
        [TestMethod]
        public void Tags_Returns_ExpectedTags()
        {
            // Arrange
            var recipe = new Recipe();
            var expectedTags = new List<string> { "technology", "programming", "software" };

            // Act
            recipe.Tags = expectedTags;
            var resultTags = recipe.Tags;

            // Assert
            CollectionAssert.AreEqual(expectedTags, resultTags);
        }
    }
}

