using RecipePlannerLibrary;

namespace RecipePlannerTests;

/// <summary>
///     Test class for Recipe DAL
/// </summary>
[TestClass]
public class RecipeDALTests
{
    #region Data members

    private const string ConnectionString = "insert your connection string here";

    #endregion

    #region Methods

    /// <summary>
    ///     Tests get recipes.
    /// </summary>
    [TestMethod]
    public void TestGetRecipes()
    {
        var expectedCount = 3;

        List<Recipe> recipes = RecipeDAL.getRecipes(Connection.TestsConnectionString);

        Assert.AreEqual(expectedCount, recipes.Count);
    }

    /// <summary>
    ///     Tests get ingredients for recipe.
    /// </summary>
    [TestMethod]
    public void TestGetIngredientsForRecipe()
    {
        var recipeId = 1;
        var expectedCount = 3;

        List<RecipeIngredient> ingredients =
            RecipeDAL.getIngredientsForRecipe(recipeId, Connection.TestsConnectionString);

        Assert.AreEqual(expectedCount, ingredients.Count);
    }

    /// <summary>
    ///     Tests getting  the name of the recipe name by identifier returns correct.
    /// </summary>
    [TestMethod]
    public void GetRecipeNameById_ReturnsCorrectName()
    {
        // Arrange
        var recipeId = 2; // Set the recipe ID to test
        var expectedName = "Bowl of Lucky Charms"; // Set the expected recipe name

        // Act
        var actualName = RecipeDAL.getRecipeNameById(recipeId, Connection.TestsConnectionString);

        // Assert
        Assert.AreEqual(expectedName, actualName);
    }

    /// <summary>
    ///     tests the get tags for recipe.
    /// </summary>
    [TestMethod]
    public void TestGetTagsForRecipe()
    {
        // Arrange
        var recipeId = 1;
        var expectedTags = new List<string> {"breakfast", "simple", "vegetarian"};

        // Act
        var actualTags = RecipeDAL.getTagsForRecipe(recipeId, Connection.TestsConnectionString);

        // Assert
        CollectionAssert.AreEqual(expectedTags, actualTags);
    }

    /// <summary>
    ///     Tests getting the recipe by name returns correct recipe.
    /// </summary>
    [TestMethod]
    public void GetRecipeByName_ReturnsCorrectRecipe()
    {
        // Arrange
        var name = "Bowl of Lucky Charms";
        var expectedRecipe = new Recipe
        {
            RecipeId = 2,
            Name = "Bowl of Lucky Charms",
            Description = "A bowl of delicious Lucky Charms and milk"
        };

        // Act
        var actualRecipe = RecipeDAL.getRecipeByName(name, Connection.TestsConnectionString);

        // Assert
        Assert.AreEqual(expectedRecipe.RecipeId, actualRecipe.RecipeId);
        Assert.AreEqual(expectedRecipe.Name, actualRecipe.Name);
        Assert.AreEqual(expectedRecipe.Description, actualRecipe.Description);
    }

    /// <summary>
    ///     Tests the get steps for recipe.
    /// </summary>
    [TestMethod]
    public void TestGetStepsForRecipe()
    {
        var recipeId = 1;
        var expectedCount = 7;

        List<RecipeStep> steps = RecipeDAL.getStepsForRecipe(recipeId, Connection.TestsConnectionString);

        Assert.AreEqual(expectedCount, steps.Count);
    }

    /// <summary>
    ///     Gets the shared recipes should return list of shared recipes.
    /// </summary>
    [TestMethod]
    public void GetSharedRecipes_ShouldReturnListOfSharedRecipes()
    {
        // Arrange
        ActiveUser.username = "global";
        var exp = new SharedRecipe(
            RecipeDAL.getRecipeByName(RecipeDAL.getRecipeNameById(3, Connection.TestsConnectionString),
                Connection.TestsConnectionString), "global", "global");
        Assert.AreEqual(RecipeDAL.getSharedRecipes(Connection.TestsConnectionString)[0].Recipe.Name, exp.Recipe.Name);
    }

    #endregion
}