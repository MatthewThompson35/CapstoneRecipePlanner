using MySql.Data.MySqlClient;
using RecipePlannerLibrary;

namespace RecipePlannerTests
{
    /// <summary>
    /// Test class for Recipe DAL
    /// </summary>
    [TestClass]
    public class RecipeDALTests
    {
        /// <summary>
        /// Tests get recipes.
        /// </summary>
        [TestMethod]
        public void TestGetRecipes()
        {
            int expectedCount = 2;

            List<Recipe> recipes = RecipeDAL.getRecipes(Connection.TestsConnectionString);
            
            Assert.AreEqual(expectedCount, recipes.Count);
        }

        /// <summary>
        /// Tests get ingredients for recipe.
        /// </summary>
        [TestMethod]
        public void TestGetIngredientsForRecipe()
        {
            int recipeId = 1;
            int expectedCount = 2;

            List<RecipeIngredient> ingredients = RecipeDAL.getIngredientsForRecipe(recipeId, Connection.TestsConnectionString);

            Assert.AreEqual(expectedCount, ingredients.Count);
        }

        /// <summary>
        /// Tests getting  the name of the recipe name by identifier returns correct.
        /// </summary>
        [TestMethod]
        public void GetRecipeNameById_ReturnsCorrectName()
        {
            // Arrange
            var recipeId = 1; // Set the recipe ID to test
            var expectedName = "Bowl of Lucky Charms"; // Set the expected recipe name

            // Act
            var actualName = RecipeDAL.getRecipeNameById(recipeId, Connection.TestsConnectionString);

            // Assert
            Assert.AreEqual(expectedName, actualName);
        }

        /// <summary>
        /// tests the get tags for recipe.
        /// </summary>
        [TestMethod]
        public void TestGetTagsForRecipe()
        {
            // Arrange
            int recipeId = 1;
            var expectedTags = new List<string> { "test" };

            // Act
            var actualTags = RecipeDAL.getTagsForRecipe(recipeId, Connection.TestsConnectionString);

            // Assert
            CollectionAssert.AreEqual(expectedTags, actualTags);
        }

        /// <summary>
        /// Tests the get steps for recipe.
        /// </summary>
        [TestMethod]
        public void TestGetStepsForRecipe()
        {
            int recipeId = 1;
            int expectedCount = 3;

            List<RecipeStep> steps = RecipeDAL.getStepsForRecipe(recipeId, Connection.TestsConnectionString);

            Assert.AreEqual(expectedCount, steps.Count);
        }

    }
}
