namespace RecipePlannerTests
{
    [TestClass]
    public class RecipeTests
    {
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

