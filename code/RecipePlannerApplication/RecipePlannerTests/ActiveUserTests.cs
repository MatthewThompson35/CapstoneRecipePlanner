using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
