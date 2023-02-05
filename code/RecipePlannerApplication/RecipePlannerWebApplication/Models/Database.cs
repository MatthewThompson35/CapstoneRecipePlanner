using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace RecipePlannerWebApplication.Models
{
    public class Database
    {
        private static MySqlConnection loginConnection = new MySqlConnection(Connection.LoginConnectionString);
        public static int LoginCheck(Login login)
        {
            MySqlCommand loginCommand = new MySqlCommand("SELECT username FROM login WHERE username=@Username AND password=@Password", loginConnection);
            loginCommand.Parameters.AddWithValue("@Username", login.Username);
            loginCommand.Parameters.AddWithValue("@Password", login.Password);

            loginConnection.Open();
            MySqlDataReader reader = loginCommand.ExecuteReader();

            int result = 0;
            if (reader.Read())
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            loginConnection.Close();
            return result;
        }

    }
}
