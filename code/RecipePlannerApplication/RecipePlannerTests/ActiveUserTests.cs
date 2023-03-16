namespace RecipePlannerTests
{
    [TestClass]
    public class ActiveUserTests
    {
        /// <summary>
        /// Tests the set username method
        /// </summary>
        [TestMethod]
        public void SetUsername()
        {

            string expectedUsername = "test";


            ActiveUser.username = expectedUsername;
            string actualUsername = ActiveUser.username;


            Assert.AreEqual(expectedUsername, actualUsername, "The username was not set correctly");
        }
        /// <summary>
        /// Tests the method to get the username
        /// </summary>
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
