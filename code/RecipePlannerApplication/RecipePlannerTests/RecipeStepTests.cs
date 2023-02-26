namespace RecipePlannerTests
{
    [TestClass]
    public class RecipeStepTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            int recipeId = 1;
            int stepNumber = 2;
            string stepDescription = "Boil water";

            RecipeStep step = new RecipeStep(recipeId, stepNumber, stepDescription);

            Assert.AreEqual(recipeId, step.recipeId);
            Assert.AreEqual(stepNumber, step.stepNumber);
            Assert.AreEqual(stepDescription, step.stepDescription);
        }
    }
}
