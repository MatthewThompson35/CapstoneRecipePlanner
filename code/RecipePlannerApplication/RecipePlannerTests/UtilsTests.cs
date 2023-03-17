namespace RecipePlannerTests
{
    /// <summary>
    /// Tests the utils class
    /// </summary>
    [TestClass]
    public class UtilsTests
    {
        /// <summary>
        /// Tests the getHex method
        /// </summary>
        [TestMethod]
        public void TestGetHex()
        {
            var inputString = "test";
            var expectedResult = "7400650073007400";

            var result = Util.GetHex(inputString);

            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the getHash method
        /// </summary>
        [TestMethod]
        public void TestGetHash()
        {
            var inputString = "test";
            var expectedResult = "098f6bcd4621d373cade4e832627b4f6";

            var result = Util.GetHash(inputString);

            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests that getting the date of week day returns correct date for next week.
        /// </summary>
        [TestMethod]
        public void GetDateOfWeekDay_Returns_CorrectDate_For_NextWeek()
        {
            // Arrange
            DayOfWeek dayOfWeek = DayOfWeek.Tuesday;
            string week = "next";
            DateTime today = DateTime.Today;
            int daysUntilCurrentWeekDay = ((int)dayOfWeek - (int)today.DayOfWeek) + 7;
            DateTime expectedDate = today.AddDays(daysUntilCurrentWeekDay);

            // Act
            DateTime result = Util.GetDateOfWeekDay(dayOfWeek, week);

            // Assert
            Assert.AreEqual(expectedDate, result);
        }

        /// <summary>
        /// Tests that getting the date of week day returns correct date for current week.
        /// </summary>
        [TestMethod]
        public void GetDateOfWeekDay_Returns_CorrectDate_For_ThisWeek()
        {
            // Arrange
            DayOfWeek dayOfWeek = DayOfWeek.Friday;
            string week = "this";
            DateTime today = DateTime.Today;
            int daysUntilCurrentWeekDay = ((int)dayOfWeek - (int)today.DayOfWeek);
            DateTime expectedDate = today.AddDays(daysUntilCurrentWeekDay);

            // Act
            DateTime result = Util.GetDateOfWeekDay(dayOfWeek, week);

            // Assert
            Assert.AreEqual(expectedDate, result);
        }

        /// <summary>
        /// Tests getting the date of week day returns today when day of week is same as today.
        /// </summary>
        [TestMethod]
        public void GetDateOfWeekDay_Returns_Today_When_DayOfWeek_Is_Same_As_Today()
        {
            // Arrange
            DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
            string week = "this";
            DateTime expectedDate = DateTime.Today;

            // Act
            DateTime result = Util.GetDateOfWeekDay(dayOfWeek, week);

            // Assert
            Assert.AreEqual(expectedDate, result);
        }

        /// <summary>
        /// Tests getting the date of week day is not case sensitive.
        /// </summary>
        [TestMethod]
        public void GetDateOfWeekDay_Is_Not_Case_Sensitive()
        {
            // Arrange
            DayOfWeek dayOfWeek = DayOfWeek.Wednesday;
            string week = "THIS";
            DateTime today = DateTime.Today;
            int daysUntilCurrentWeekDay = ((int)dayOfWeek - (int)today.DayOfWeek);
            DateTime expectedDate = today.AddDays(daysUntilCurrentWeekDay);

            // Act
            DateTime result = Util.GetDateOfWeekDay(dayOfWeek, week);

            // Assert
            Assert.AreEqual(expectedDate, result);
        }
    }
}
