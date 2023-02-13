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
            IngredientDAL.decrementQuantity((int)list[0].id, (int)list[0].quantity);
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
            IngredientDAL.incrementQuantity((int)list[0].id, (int)list[0].quantity);
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
    }
}
