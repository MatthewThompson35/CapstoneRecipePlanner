namespace RecipePlannerTests;

/// <summary>
/// The Shared Recipe Test Class
/// </summary>
[TestClass]
public class SharedRecipeClassTests
{
    #region Methods

    /// <summary>
    /// Constructors the sets properties correctly.
    /// </summary>
    [TestMethod]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        var recipe = new Recipe();
        var senderUsername = "sender";
        var receiverUsername = "receiver";

        // Act
        var sharedRecipe = new SharedRecipe(recipe, senderUsername, receiverUsername);

        // Assert
        Assert.AreEqual(recipe, sharedRecipe.Recipe);
        Assert.AreEqual(recipe.Name, sharedRecipe.recipeName);
        Assert.AreEqual(senderUsername, sharedRecipe.SenderUsername);
        Assert.AreEqual(receiverUsername, sharedRecipe.ReceiverUsername);
    }

    /// <summary>
    /// Recipes the property can be set and get.
    /// </summary>
    [TestMethod]
    public void RecipeProperty_CanBeSetAndGet()
    {
        // Arrange
        var recipe = new Recipe();
        var sharedRecipe = new SharedRecipe(new Recipe(), "test", "test");

        // Act
        sharedRecipe.Recipe = recipe;

        // Assert
        Assert.AreEqual(recipe, sharedRecipe.Recipe);
    }

    /// <summary>
    /// Recipes the name property can be set and get.
    /// </summary>
    [TestMethod]
    public void RecipeNameProperty_CanBeSetAndGet()
    {
        // Arrange
        var recipeName = "Test Recipe";
        var sharedRecipe = new SharedRecipe(new Recipe(), "test", "test");

        // Act
        sharedRecipe.recipeName = recipeName;

        // Assert
        Assert.AreEqual(recipeName, sharedRecipe.recipeName);
    }

    /// <summary>
    /// Senders the username property can be set and get.
    /// </summary>
    [TestMethod]
    public void SenderUsernameProperty_CanBeSetAndGet()
    {
        // Arrange
        var senderUsername = "sender";
        var sharedRecipe = new SharedRecipe(new Recipe(), "test", "test");

        // Act
        sharedRecipe.SenderUsername = senderUsername;

        // Assert
        Assert.AreEqual(senderUsername, sharedRecipe.SenderUsername);
    }

    /// <summary>
    /// Receivers the username property can be set and get.
    /// </summary>
    [TestMethod]
    public void ReceiverUsernameProperty_CanBeSetAndGet()
    {
        ActiveUser.username = "global";
        // Arrange
        var receiverUsername = "receiver";
        var sharedRecipe = new SharedRecipe(new Recipe(), "test", receiverUsername);

        // Act
        sharedRecipe.ReceiverUsername = receiverUsername;

        // Assert
        Assert.AreEqual(receiverUsername, sharedRecipe.ReceiverUsername);
    }

    #endregion
}