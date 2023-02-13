namespace RecipePlannerTests
{
    [TestClass]
    public class ActiveUserTests
    {
        [TestMethod]
        public void SetUsername()
        {

            string expectedUsername = "test";


            ActiveUser.username = expectedUsername;
            string actualUsername = ActiveUser.username;


            Assert.AreEqual(expectedUsername, actualUsername, "The username was not set correctly");
        }

        [TestMethod]
        public void GetUsername()
        {
            string expectedUsername = "test";

            ActiveUser.username = expectedUsername;

            string actualUsername = ActiveUser.username;

            Assert.AreEqual(expectedUsername, actualUsername, "The username was not returned correctly");
        }
    }



}
