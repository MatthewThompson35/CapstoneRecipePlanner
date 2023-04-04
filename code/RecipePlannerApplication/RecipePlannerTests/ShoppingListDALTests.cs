using RecipePlannerLibrary;

namespace RecipePlannerTests;

/// <summary>
///     The shopping lists dal class
/// </summary>
[TestClass]
public class ShoppingListDALTests
{
    #region Methods

    /// <summary>
    ///     Gets the ingredients should return list of ingredients.
    /// </summary>
    [TestMethod]
    public void getIngredients_ShouldReturnListOfIngredients()
    {
        ActiveUser.username = "test";
        // Arrange
        var expectedIngredients = new List<Ingredient>
        {
            new("test", "milk", 3, 4, "OZ")
        };

        // Act
        var actualIngredients = ShoppingListDAL.getIngredients(Connection.TestsConnectionString);

        // Assert
        Assert.AreEqual(expectedIngredients[0].quantity, actualIngredients[0].quantity);
        Assert.AreEqual(expectedIngredients[0].id, actualIngredients[0].id);
        Assert.AreEqual(expectedIngredients[0].name, actualIngredients[0].name);
    }

    /// <summary>
    ///     Adds the ingredient should add ingredient to database.
    /// </summary>
    [TestMethod]
    public void addIngredient_ShouldAddIngredientToDatabase()
    {
        ActiveUser.username = "test";
        // Arrange
        var name = "milk";
        var quantity = 2;
        var measurement = "OZ";
        var connectionString = Connection.TestsConnectionString;

        // Act
        ShoppingListDAL.RemoveIngredient(4, Connection.TestsConnectionString);
        ShoppingListDAL.addIngredient(name, quantity, measurement, connectionString);

        // Assert
        var ingredients = ShoppingListDAL.getIngredients(Connection.TestsConnectionString);
        Assert.IsTrue(ingredients.Exists(i =>
            i.name == name && i.quantity == quantity && i.measurement == measurement));
    }

    /// <summary>
    ///     Decrements the quantity should decrease ingredient quantity.
    /// </summary>
    [TestMethod]
    public void decrementQuantity_ShouldDecreaseIngredientQuantity()
    {
        ActiveUser.username = "test";
        // Arrange
        var id = 4;
        var quantity = 2;

        // Act
        ShoppingListDAL.decrementQuantity(id, quantity, Connection.TestsConnectionString);

        // Assert
        var ingredients = ShoppingListDAL.getIngredients(Connection.TestsConnectionString);
        var ingredient = ingredients.Find(i => i.id == id);
        Assert.AreEqual(quantity - 1, ingredient.quantity);
    }

    /// <summary>
    ///     Increments the quantity should increase ingredient quantity.
    /// </summary>
    [TestMethod]
    public void incrementQuantity_ShouldIncreaseIngredientQuantity()
    {
        ActiveUser.username = "test";
        // Arrange
        var id = 4;
        var quantity = 2;

        // Act
        ShoppingListDAL.incrementQuantity(id, quantity, Connection.TestsConnectionString);

        // Assert
        var ingredients = ShoppingListDAL.getIngredients(Connection.TestsConnectionString);
        var ingredient = ingredients.Find(i => i.id == id);
        Assert.AreEqual(quantity + 1, ingredient.quantity);
    }

    /// <summary>
    ///     Removes the ingredient should remove ingredient from database.
    /// </summary>
    [TestMethod]
    public void RemoveIngredient_ShouldRemoveIngredientFromDatabase()
    {
        ActiveUser.username = "test";
        // Arrange
        var id = 1;
        var connectionString = Connection.TestsConnectionString;

        // Act
        ShoppingListDAL.RemoveIngredient(id, connectionString);

        // Assert
        var ingredients = ShoppingListDAL.getIngredients(Connection.TestsConnectionString);
        Assert.IsFalse(ingredients.Exists(i => i.id == id));
    }

    #endregion
}