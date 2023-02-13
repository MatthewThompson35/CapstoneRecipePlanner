namespace RecipePlannerTests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void TestGetHex()
        {
            var inputString = "test";
            var expectedResult = "7400650073007400";

            var result = Util.GetHex(inputString);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestGetHash()
        {
            var inputString = "test";
            var expectedResult = "098f6bcd4621d373cade4e832627b4f6";

            var result = Util.GetHash(inputString);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
