using MySql.Data.MySqlClient;
using RecipePlannerLibrary;

namespace RecipePlannerTests
{
    [TestClass]
    public class RecipeDALTests
    {
        [TestMethod]
        public void TestGetRecipes()
        {
            int expectedCount = 2;

            List<Recipe> recipes = RecipeDAL.getRecipes(Connection.TestsConnectionString);
            
            Assert.AreEqual(expectedCount, recipes.Count);
        }

        [TestMethod]
        public void TestGetIngredientsForRecipe()
        {
            int recipeId = 1;
            int expectedCount = 2;

            List<RecipeIngredient> ingredients = RecipeDAL.getIngredientsForRecipe(recipeId, Connection.TestsConnectionString);

            Assert.AreEqual(expectedCount, ingredients.Count);
        }

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
