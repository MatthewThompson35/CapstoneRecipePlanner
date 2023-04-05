using MySql.Data.MySqlClient;
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

    /// <summary>
    /// Tests the add recipe.
    /// </summary>
    [TestMethod]
    public void TestAddRecipe()
    {
        // Arrange
        var name = "Test Recipe";
        var description = "This is a test recipe.";
        RecipeDAL.removeRecipe(RecipeDAL.getRecipeByName(name, Connection.TestsConnectionString).RecipeId, Connection.TestsConnectionString);
        // Act
        RecipeDAL.addRecipe(name, description, Connection.TestsConnectionString);

        // Assert
        using var connection = new MySqlConnection(Connection.TestsConnectionString);
        connection.Open();
        var query = @"select count(*) from recipe where name = @name and description = @description";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@description", description);
        var result = command.ExecuteScalar();
        Assert.AreEqual(1, Convert.ToInt32(result));
    }

    [TestMethod]
    public void TestAddRecipeIngredient()
    {
        // Arrange
        var recipeId = RecipeDAL.getRecipeByName("Test Recipe", Connection.TestsConnectionString).RecipeId;
        var ingredientName = "Test Ingredient";
        var ingredientId = 1;
        var quantity = 1;
        var measurement = "OZ";

        // Act
        RecipeDAL.addRecipeIngredient(recipeId, ingredientName, ingredientId, quantity, measurement, Connection.TestsConnectionString);

        // Assert
        using var connection = new MySqlConnection(Connection.TestsConnectionString);
        connection.Open();
        var query = @"select count(*) from recipe_ingredient ri join ingredient_info ii on ri.ingredientID = ii.ingredientID where ri.recipeID = @recipeId and ii.ingredientName = @ingredientName and ri.quantity = @quantity and ri.measurement = @measurement";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@recipeId", recipeId);
        command.Parameters.AddWithValue("@ingredientName", ingredientName);
        command.Parameters.AddWithValue("@quantity", quantity);
        command.Parameters.AddWithValue("@measurement", measurement);
        var result = command.ExecuteScalar();
        Assert.AreEqual(1, Convert.ToInt32(result));
    }

    [TestMethod]
    public void TestAddRecipeStep()
    {
        // Arrange
        var recipeId = RecipeDAL.getRecipeByName("Test Recipe", Connection.TestsConnectionString).RecipeId;
        var stepNumber = 1;
        var stepDescription = "This is a test step.";

        // Act
        RecipeDAL.addRecipeStep(recipeId, stepNumber, stepDescription, Connection.TestsConnectionString);

        // Assert
        using var connection = new MySqlConnection(Connection.TestsConnectionString);
        connection.Open();
        var query = @"select count(*) from recipe_step where recipeID = @recipeId and stepNumber = @stepNumber and stepDescription = @stepDescription";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@recipeId", recipeId);
        command.Parameters.AddWithValue("@stepNumber", stepNumber);
        command.Parameters.AddWithValue("@stepDescription", stepDescription);
        var result = command.ExecuteScalar();
        Assert.AreEqual(1, Convert.ToInt32(result));
    }

    [TestMethod]
    public void TestAddRecipeTag()
    {
        // Arrange
        var recipeId = RecipeDAL.getRecipeByName("Test Recipe", Connection.TestsConnectionString).RecipeId;
        var tagName = "Test Tag";

        // Act
        RecipeDAL.addRecipeTag(recipeId, tagName, Connection.TestsConnectionString);

        // Assert
        using var connection = new MySqlConnection(Connection.TestsConnectionString);
        connection.Open();
        var query = @"select count(*) from recipe_tag where recipeID = @recipeId and tagName = @tagName";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@recipeId", recipeId);
        command.Parameters.AddWithValue("@tagName", tagName);
        var result = command.ExecuteScalar();
        RecipeDAL.removeRecipe(recipeId, Connection.TestsConnectionString);
        Assert.AreEqual(1, Convert.ToInt32(result));
    }

    /*[TestMethod]
    public void TestContainsSharedRecipe()
    {
        // Arrange
        SharedRecipe recipe = new SharedRecipe(RecipeDAL.getRecipeByName("Scrambled Eggs", Connection.ConnectionString), "global", "global");

        // Act
        List<string> sharedRecipeList = RecipeDAL.ContainsSharedRecipe(recipe);

        // Assert
        // Check that the shared recipe exists in the shared_recipe table
        Assert.IsTrue(sharedRecipeList.Count > 0);
    }*/

    [TestMethod]
    public void TestContainsSharedRecipeById()
    {
        // Arrange
        int recipeId = 1;

        // Act
        SharedRecipe sharedRecipe = RecipeDAL.ContainsSharedRecipe(recipeId);

        // Assert
        // Check that the shared recipe exists in the shared_recipe table
        Assert.IsNotNull(sharedRecipe);
    }

    #endregion
}