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
            int expectedCount = 1;

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
        public void TestGetStepsForRecipe()
        {
            int recipeId = 1;
            int expectedCount = 3;

            List<RecipeStep> steps = RecipeDAL.getStepsForRecipe(recipeId, Connection.TestsConnectionString);

            Assert.AreEqual(expectedCount, steps.Count);
        }

    }
}
