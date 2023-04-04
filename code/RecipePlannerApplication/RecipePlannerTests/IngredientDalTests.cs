using MySql.Data.MySqlClient;
using RecipePlannerLibrary;

namespace RecipePlannerTests
{
    [TestClass]
    public class IngredientDalTests
    {
        /// <summary>
        /// Tests the count for getIngredients
        /// </summary>
        [TestMethod]
        public void TestGetIngredientsWithName()
        {
            ActiveUser.username = "global";
            List<Ingredient> actualIngredients = IngredientDAL.getIngredients("cheese");

            Assert.AreEqual(true, actualIngredients.Count > 0);
        }

        /// <summary>
        /// Tests the get ingredients.
        /// </summary>
        [TestMethod]
        public void TestGetIngredients()
        {
            ActiveUser.username = "global";
            List<Ingredient> actualIngredients = IngredientDAL.getIngredients();

            Assert.AreEqual(true, actualIngredients.Count > 0);
        }

        /// <summary>
        /// Tests decrementing the quantity.
        /// </summary>
        [TestMethod]
        public void DecrementQuantity()
        {

            ActiveUser.username = "global";
            var list = IngredientDAL.getIngredients();
            var expectedQuantity = list[0].quantity - 1;
            IngredientDAL.decrementQuantity((int) list[0].id, (int) list[0].quantity);
            list = IngredientDAL.getIngredients();
            Assert.IsNotNull(list[0]);
            Assert.AreEqual(list[0].quantity, expectedQuantity);
        }

        /// <summary>
        /// Tests incrementing the quantity.
        /// </summary>
        [TestMethod]
        public void IncrementQuantity()
        {

            ActiveUser.username = "global";
            var list = IngredientDAL.getIngredients();
            var expectedQuantity = list[0].quantity + 1;
            IngredientDAL.incrementQuantity((int) list[0].id, (int) list[0].quantity);
            list = IngredientDAL.getIngredients();
            Assert.IsNotNull(list[0]);
            Assert.AreEqual(list[0].quantity, expectedQuantity);
        }

        /// <summary>
        /// Tests the remove ingredient.
        /// </summary>
        [TestMethod]
        public void TestRemoveIngredient()
        {

            int ingredientId = 900;

            IngredientDAL.RemoveIngredient(ingredientId, Connection.TestsConnectionString);
            ActiveUser.username = "global";
            var ingredients = IngredientDAL.getIngredients();
            Ingredient ingredient = null;
            foreach (var item in ingredients)
            {
                if (item.id == 900)
                {
                    ingredient = item;
                }
            }

            Assert.IsNull(ingredient);
        }

        /// <summary>
        /// Tests the add ingredient.
        /// </summary>
        [TestMethod]
        public void TestAddIngredient()
        {
            ActiveUser.username = "global";

            string name = "Flour";
            int quantity = 2;
            string measurement = "G";

            IngredientDAL.RemoveIngredient(11, Connection.TestsConnectionString);
            IngredientDAL.addIngredient(name, quantity, measurement, Connection.TestsConnectionString);

            using var connection = new MySqlConnection(Connection.TestsConnectionString);
            connection.Open();
            var query = @"SELECT i.ingredientID, i.quantity, ii.measurementType FROM ingredient i, ingredient_info ii WHERE i.ingredientID = ii.ingredientID and username=@user;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@user", ActiveUser.username);
            command.Parameters.AddWithValue("@name", name);
            using var reader = command.ExecuteReader();
            
            Assert.IsTrue(reader.Read());
            Assert.AreEqual(quantity, reader.GetInt32("quantity"));
            Assert.AreEqual(measurement, reader.GetString("measurementType"));
        }


        [TestMethod]
        public void GetIngredientId_WithValidIngredientName_ReturnsCorrectId()
        {
            // Arrange
            string ingredientName = "cheese";

            // Act
            int id = IngredientDAL.getIngredientId(ingredientName);

            // Assert
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void GetIngredientId_WithInvalidIngredientName_ReturnsZero()
        {
            // Arrange
            string ingredientName = "InvalidIngredient";

            // Act
            int id = IngredientDAL.getIngredientId(ingredientName);

            // Assert
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void GetIngredientsFromShoppingList_ReturnsListOfIngredients()
        {
            // Arrange

            // Act
            List<Ingredient> ingredients = IngredientDAL.GetIngredientsFromShoppingList();

            // Assert
            Assert.IsNotNull(ingredients);
            Assert.IsTrue(ingredients.Count > 0);
        }
    }
}
