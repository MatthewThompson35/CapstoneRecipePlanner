using MySql.Data.MySqlClient;
using RecipePlannerLibrary;

namespace RecipePlannerTests
{
    [TestClass]
    public class DatabaseTests
    {
        /// <summary>
        /// Checks the login for correct information.
        /// </summary>
        [TestMethod]
        public void LoginCheck_Correct_Info()
        {
            Login login = new Login { Username = "global", Password = "user" };

            int result = Database.LoginCheck(login);

            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Tests login with incorrect info
        /// </summary>
        [TestMethod]
        public void LoginCheck_Incorrect_Info()
        {
            Login login = new Login { Username = "user", Password = "incorrect" };

            int result = Database.LoginCheck(login);

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Tests remove user with given username.
        /// </summary>
        [TestMethod]
        public void RemoveUser_RemovesUserWithGivenUsername()
        {
            // Arrange
            string username = "testuser";
            string password = "testpassword";
            // Create a test user for removal
            Database.RemoveUser(username);
            Database.CreateUser(username, password);

            // Act
            Database.RemoveUser(username);

            // Assert
            // Attempt to retrieve the user after removal - this should return null
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = @"SELECT * FROM login WHERE username = @userName;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userName", username);
            using var reader = command.ExecuteReader();
            Assert.IsFalse(reader.Read());
        }

        /// <summary>
        /// Tests Create the user valid username password.
        /// </summary>
        [TestMethod]
        public void CreateUser_ValidUsernamePassword()
        {
            string username = "newUser";
            string password = "newPassword";
            Database.RemoveUser(username);
            Database.CreateUser(username, password);

            List<string> users = Database.ContainsUser(username);
            Assert.IsTrue(users.Contains(username));
        }

        /// <summary>
        /// Tests containsUser whether [contains user valid username].
        /// </summary>
        [TestMethod]
        public void ContainsUser_ValidUsername()
        {
            string username = "global";

            List<string> result = Database.ContainsUser(username);

            Assert.IsTrue(result.Contains(username));
        }

        /// <summary>
        /// Tests containsUser whether [contains user invalid username].
        /// </summary>
        [TestMethod]
        public void ContainsUser_InvalidUsername()
        {
            string username = "invalid";

            List<string> result = Database.ContainsUser(username);

            Assert.AreEqual(0, result.Count);
        }
    }
}
