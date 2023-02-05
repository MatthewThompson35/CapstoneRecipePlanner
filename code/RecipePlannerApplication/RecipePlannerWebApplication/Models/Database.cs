using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace RecipePlannerWebApplication.Models
{
    public class Database
    {
        private static MySqlConnection con = new MySqlConnection(Connection.LoginConnectionString);
        public static int LoginCheck(Login ad)
        {
            MySqlCommand com = new MySqlCommand("SELECT username FROM login WHERE username=@Username AND password=@Password", con);
            com.Parameters.AddWithValue("@Username", ad.Username);
            com.Parameters.AddWithValue("@Password", ad.Password);

            con.Open();
            MySqlDataReader reader = com.ExecuteReader();

            int result = 0;
            if (reader.Read())
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            con.Close();
            return result;
        }

    }
}
