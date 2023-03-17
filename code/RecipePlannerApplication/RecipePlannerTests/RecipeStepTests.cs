namespace RecipePlannerTests
{
    /// <summary>
    /// Test the recipe step class
    /// </summary>
    [TestClass]
    public class RecipeStepTests
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
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
