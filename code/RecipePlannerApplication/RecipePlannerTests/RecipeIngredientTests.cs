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

        /// <summary>
        /// Equals the returns true when object is equal.
        /// </summary>
        [TestMethod]
        public void Equals_ReturnsTrue_WhenObjectIsEqual()
        {
            // Arrange
            RecipeIngredient ingredient1 = new RecipeIngredient("flour", 2, "cups");
            RecipeIngredient ingredient2 = new RecipeIngredient("flour", 2, "cups");

            // Act
            bool result = ingredient1.Equals(ingredient2);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Equals the returns false when object is not equal.
        /// </summary>
        [TestMethod]
        public void Equals_ReturnsFalse_WhenObjectIsNotEqual()
        {
            // Arrange
            RecipeIngredient ingredient1 = new RecipeIngredient("flour", 2, "cups");
            RecipeIngredient ingredient2 = new RecipeIngredient("sugar", 2, "cups");

            // Act
            bool result = ingredient1.Equals(ingredient2);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Gets the hash code returns same hash code when object is equal.
        /// </summary>
        [TestMethod]
        public void GetHashCode_ReturnsSameHashCode_WhenObjectIsEqual()
        {
            // Arrange
            RecipeIngredient ingredient1 = new RecipeIngredient("flour", 2, "cups");
            RecipeIngredient ingredient2 = new RecipeIngredient("flour", 2, "cups");

            // Act
            int hash1 = ingredient1.GetHashCode();
            int hash2 = ingredient2.GetHashCode();

            // Assert
            Assert.AreEqual(hash1, hash2);
        }

        /// <summary>
        /// Gets the hash code returns different hash code when object is not equal.
        /// </summary>
        [TestMethod]
        public void GetHashCode_ReturnsDifferentHashCode_WhenObjectIsNotEqual()
        {
            // Arrange
            RecipeIngredient ingredient1 = new RecipeIngredient("flour", 2, "cups");
            RecipeIngredient ingredient2 = new RecipeIngredient("sugar", 2, "cups");

            // Act
            int hash1 = ingredient1.GetHashCode();
            int hash2 = ingredient2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hash1, hash2);
        }
    }
}
