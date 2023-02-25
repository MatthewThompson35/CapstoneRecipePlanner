using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    /// Database class
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The login connection
        /// </summary>
        private static MySqlConnection loginConnection = new MySqlConnection(Connection.ConnectionString);

        /// <summary>
        /// Logins the check.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static int LoginCheck(Login login)
        {
            try
            {
                var passwordHash = Util.GetHash(login.Password);
                MySqlCommand loginCommand =
                    new MySqlCommand("SELECT username FROM login WHERE username=@Username AND password=@Password",
                        loginConnection);
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
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
                return 2;
            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public static void CreateUser(string username, string password)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
            }
        }

        /// <summary>
        /// Determines whether the specified username contains user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List of users</returns>
        public static List<string> ContainsUser(string username)
        {
            try
            {
                using var connection = new MySqlConnection(Connection.ConnectionString);
                connection.Open();
                List<string> list = new List<string>();
                string query = @"Select * from login where username=@username;";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.Add("@userName", MySqlDbType.VarChar).Value = username;
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
                return null;
            }

        }

    }
}
