using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Database
{
    public class Database
    {
        private static MySqlConnection loginConnection = new MySqlConnection(Connection.ConnectionString);
        public static int LoginCheck(Login login)
        {
            var passwordHash = Util.GetHash(login.Password);
            MySqlCommand loginCommand = new MySqlCommand("SELECT username FROM login WHERE username=@Username AND password=@Password", loginConnection);
            loginCommand.Parameters.AddWithValue("@Username", login.Username);
            loginCommand.Parameters.AddWithValue("@Password", passwordHash);

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

        public static void CreateUser(string username, string password)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query =
                @"Insert into login (username, password) values (@userName, @password);";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@userName", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = Util.GetHash(password);
            command.ExecuteNonQuery();
        }

        public static void PopulateDB()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            string query = System.IO.File.ReadAllText("..\\RecipePlannerLibrary\\Scripts\\PrepopulateDB.sql");
            using var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public static void PopulateWebDB()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            string query = System.IO.File.ReadAllText("..\\RecipePlannerLibrary\\Scripts\\PrepopulateDB.sql");
            using var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

    }
}
