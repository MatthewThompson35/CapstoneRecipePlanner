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

        /// <summary>
        /// Construct the sets properties correctly.
        /// </summary>
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

        /// <summary>
        /// Equals the returns true when object is equal.
        /// </summary>
        [TestMethod]
        public void Equals_ReturnsTrue_WhenObjectIsEqual()
        {
            // Arrange
            RecipeStep step1 = new RecipeStep(1, "Preheat the oven.");
            RecipeStep step2 = new RecipeStep(1, "Preheat the oven.");

            // Act
            bool result = step1.Equals(step2);

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
            RecipeStep step1 = new RecipeStep(1, "Preheat the oven.");
            RecipeStep step2 = new RecipeStep(2, "Preheat the oven.");

            // Act
            bool result = step1.Equals(step2);

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
            RecipeStep step1 = new RecipeStep(1, "Preheat the oven.");
            RecipeStep step2 = new RecipeStep(1, "Preheat the oven.");

            // Act
            int hash1 = step1.GetHashCode();
            int hash2 = step2.GetHashCode();

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
            RecipeStep step1 = new RecipeStep(1, "Preheat the oven.");
            RecipeStep step2 = new RecipeStep(2, "Preheat the oven.");

            // Act
            int hash1 = step1.GetHashCode();
            int hash2 = step2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hash1, hash2);
        }
    }
}
