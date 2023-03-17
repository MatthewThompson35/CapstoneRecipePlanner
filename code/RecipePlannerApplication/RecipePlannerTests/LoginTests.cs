using RecipePlannerLibrary;

namespace RecipePlannerTests
{
    [TestClass]
    public class LoginTests
    {
        /// <summary>
        /// Tests the login initialization.
        /// </summary>
        [TestMethod]
        public void TestLoginInitialization()
        {
            string expectedUsername = "";
            string expectedPassword = "";
            string expectedErrorMessage = "";

            Login login = new Login();

            Assert.AreEqual(expectedUsername, login.Username);
            Assert.AreEqual(expectedPassword, login.Password);
            Assert.AreEqual(expectedErrorMessage, login.ErrorMessage);
        }

        /// <summary>
        /// Tests the login properties.
        /// </summary>
        [TestMethod]
        public void TestLoginProperties()
        {
            Login login = new Login();

            string expectedUsername = "testuser";
            string expectedPassword = "password123";
            string expectedErrorMessage = "Invalid username or password.";

            login.Username = "testuser";
            login.Password = "password123";
            login.ErrorMessage = "Invalid username or password.";

            Assert.AreEqual(expectedUsername, login.Username);
            Assert.AreEqual(expectedPassword, login.Password);
            Assert.AreEqual(expectedErrorMessage, login.ErrorMessage);
        }
    }
}
