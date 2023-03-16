namespace RecipePlannerTests
{
    [TestClass]
    public class IngredientsTests
    {
        /// <summary>
        /// Tests the Ingredients Constructor
        /// </summary>
        [TestMethod]
        public void ConstructorTests()
        {
            string expectedUsername = "testuser";
            string expectedName = "flour";
            int expectedQuantity = 2;
            int expectedId = 1;
            string measurement = "G";

            Ingredient ingredient = new Ingredient(expectedUsername, expectedName, expectedQuantity, expectedId, measurement);

            Assert.AreEqual(expectedUsername, ingredient.username, "The username was not set correctly");
            Assert.AreEqual(expectedName, ingredient.name, "The name was not set correctly");
            Assert.AreEqual(expectedQuantity, ingredient.quantity, "The quantity was not set correctly");
            Assert.AreEqual(expectedId, ingredient.id, "The id was not set correctly");
            Assert.AreEqual(measurement, ingredient.measurement, "The measurement was not set correctly");
        }

        /// <summary>
        /// Tests the toString Method
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            string username = "test";
            string name = "flour";
            int quantity = 2;
            int id = 1;
            string measurement = "G";
            Ingredient ingredient = new Ingredient(username, name, quantity, id, measurement);

            string result = ingredient.ToString();

            Assert.AreEqual(name + " - Quantity: " + quantity.ToString(), result, "The ToString method returned an incorrect string");
        }
    }
}
