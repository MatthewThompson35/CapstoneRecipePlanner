using RecipePlannerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlannerTests
{
    [TestClass]
    public class DataAccessLayerTests
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
        public void CreateUser_ValidUsernamePassword()
        {
            string username = "newUser";
            string password = "newPassword";

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
