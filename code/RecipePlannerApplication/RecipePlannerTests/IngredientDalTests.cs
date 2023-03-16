using MySql.Data.MySqlClient;
using RecipePlannerLibrary;

namespace RecipePlannerTests
{
    [TestClass]
    public class IngredientDalTests
    {
        [TestMethod]
        public void TestGetIngredientsWithName()
        {
            ActiveUser.username = "global";
            List<Ingredient> actualIngredients = IngredientDAL.getIngredients("cheese");

            Assert.AreEqual(true, actualIngredients.Count > 0);
        }

        [TestMethod]
        public void TestGetIngredients()
        {
            ActiveUser.username = "global";
            List<Ingredient> actualIngredients = IngredientDAL.getIngredients();

            Assert.AreEqual(true, actualIngredients.Count > 0);
        }


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

        [TestMethod]
        public void TestRemoveIngredient()
        {

            int ingredientId = 900;

            IngredientDAL.RemoveIngredient(ingredientId);
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

        [TestMethod]
        public void TestAddIngredient()
        {
            ActiveUser.username = "global";

            string name = "Flour";
            int quantity = 2;
            string measurement = "G";

            IngredientDAL.addIngredient(name, quantity, measurement, Connection.TestsConnectionString);

            using var connection = new MySqlConnection(Connection.TestsConnectionString);
            connection.Open();
            var query = @"Select * from ingredient where username = @username and ingredientName = @name";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", ActiveUser.username);
            command.Parameters.AddWithValue("@name", name);
            using var reader = command.ExecuteReader();
            
            Assert.IsTrue(reader.Read());
            Assert.AreEqual(quantity, reader.GetInt32("quantity"));
            Assert.AreEqual(measurement, reader.GetString("Measurement"));
        }
    }
}
