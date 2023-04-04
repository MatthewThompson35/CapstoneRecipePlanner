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

        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int expectedStepNumber = 1;
            string expectedStepDescription = "Preheat the oven to 350°F.";

            // Act
            RecipeStep recipeStep = new RecipeStep(expectedStepNumber, expectedStepDescription);

            // Assert
            Assert.AreEqual(expectedStepNumber, recipeStep.stepNumber);
            Assert.AreEqual(expectedStepDescription, recipeStep.stepDescription);
        }
    }
}
