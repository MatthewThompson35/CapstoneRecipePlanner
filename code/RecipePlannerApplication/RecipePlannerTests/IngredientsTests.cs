using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RecipePlannerTests
{
    [TestClass]
    public class IngredientsTests
    {
        [TestMethod]
        public void ConstructorTests()
        {
            string expectedUsername = "testuser";
            string expectedName = "flour";
            int expectedQuantity = 2;
            int expectedId = 1;

            Ingredient ingredient = new Ingredient(expectedUsername, expectedName, expectedQuantity, expectedId);

            Assert.AreEqual(expectedUsername, ingredient.username, "The username was not set correctly");
            Assert.AreEqual(expectedName, ingredient.name, "The name was not set correctly");
            Assert.AreEqual(expectedQuantity, ingredient.quantity, "The quantity was not set correctly");
            Assert.AreEqual(expectedId, ingredient.id, "The id was not set correctly");
        }

        [TestMethod]
        public void ToStringTest()
        {
            string username = "test";
            string name = "flour";
            int quantity = 2;
            int id = 1;
            Ingredient ingredient = new Ingredient(username, name, quantity, id);

            string result = ingredient.ToString();

            Assert.AreEqual(name + " - Quantity: " + quantity.ToString(), result, "The ToString method returned an incorrect string");
        }
    }
   

}
