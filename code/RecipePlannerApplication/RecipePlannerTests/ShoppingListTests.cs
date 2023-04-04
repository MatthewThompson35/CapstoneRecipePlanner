using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Models;

namespace RecipePlannerTests
{
    public class ShoppingListTests
    {
        [TestClass]
        public class ShoppingListDALTests
        {
            [TestMethod]
            public void getIngredients_ShouldReturnListOfIngredients()
            {
                ActiveUser.username = "test";
                // Arrange
                var expectedIngredients = new List<Ingredient>()
            {
                new Ingredient("test", "milk", 3, 4, "OZ"),
               
            };

                // Act
                var actualIngredients = ShoppingListDAL.getIngredients(Connection.TestsConnectionString);

                // Assert
                Assert.AreEqual(expectedIngredients[0].quantity, actualIngredients[0].quantity);
                Assert.AreEqual(expectedIngredients[0].id, actualIngredients[0].id);
                Assert.AreEqual(expectedIngredients[0].name, actualIngredients[0].name);
            }

            [TestMethod]
            public void addIngredient_ShouldAddIngredientToDatabase()
            {
                ActiveUser.username = "test";
                // Arrange
                var name = "Milk";
                var quantity = 1;
                var measurement = "OZ";
                var connectionString = Connection.TestsConnectionString;

                // Act
                ShoppingListDAL.RemoveIngredient(56, Connection.TestsConnectionString);
                ShoppingListDAL.addIngredient(name, quantity, measurement, connectionString);

                // Assert
                var ingredients = ShoppingListDAL.getIngredients(Connection.TestsConnectionString);
                Assert.IsTrue(ingredients.Exists(i => i.name == name && i.quantity == quantity && i.measurement == measurement));
                ShoppingListDAL.RemoveIngredient(56, Connection.TestsConnectionString);
            }

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
        }
    }
}
