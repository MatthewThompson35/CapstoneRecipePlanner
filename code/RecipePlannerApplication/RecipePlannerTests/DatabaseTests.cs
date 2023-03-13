using MySql.Data.MySqlClient;
using RecipePlannerLibrary;

namespace RecipePlannerTests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void LoginCheck_Correct_Info()
        {
            Login login = new Login { Username = "global", Password = "user" };

            int result = Database.LoginCheck(login);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LoginCheck_Incorrect_Info()
        {
            Login login = new Login { Username = "user", Password = "incorrect" };

            int result = Database.LoginCheck(login);

            Assert.AreEqual(0, result);
        }

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


        [TestMethod]
        public void ContainsUser_ValidUsername()
        {
            string username = "global";

            List<string> result = Database.ContainsUser(username);

            Assert.IsTrue(result.Contains(username));
        }

        [TestMethod]
        public void ContainsUser_InvalidUsername()
        {
            string username = "invalid";

            List<string> result = Database.ContainsUser(username);

            Assert.AreEqual(0, result.Count);
        }
    }
}
