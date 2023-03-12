using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Database
{
    public class PlannedMealDal
    {
        public static void addPlannedMeal(string connectionString, int recipeId, string day, string type, DateTime date)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"Insert into planned_recipe values (@recipeId, @day, @type, @date)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@recipeId", MySqlDbType.Int32).Value = recipeId;
            command.Parameters.Add("@day", MySqlDbType.VarChar).Value = day;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            using var reader = command.ExecuteReader();


            connection.Close();
        }

        public static Dictionary<(string, string), int> getThisWeeksMeals(string connectionString)
        {
            var thisWeeksMeals = new Dictionary<(string, string), int>();
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"SELECT *
            FROM planned_recipe
            WHERE YEARWEEK(dateUsed) = YEARWEEK(NOW());";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var recipeId = reader.GetInt32(0);
                var day = reader.GetString(1);
                var type = reader.GetString(2);
                thisWeeksMeals.Add((day, type), recipeId);
            }

            return thisWeeksMeals;
        }

        public static Dictionary<(string, string), int> getNextWeeksMeals(string connectionString)
        {
            var nextWeeksMeals = new Dictionary<(string, string), int>();
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"SELECT *
            FROM planned_recipe
            WHERE YEARWEEK(dateUsed) = YEARWEEK(DATE_ADD(NOW(), INTERVAL 1 WEEK));";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var recipeId = reader.GetInt32(0);
                var day = reader.GetString(1);
                var type = reader.GetString(2);
                nextWeeksMeals.Add((day, type), recipeId);
            }

            return nextWeeksMeals;
        }

        public static void RemoveThisWeekMeal(string connectionString, int id, string day, string type, DateTime date)
        {

            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"DELETE FROM planned_recipe WHERE recipeID = @id and dayOfTheWeek = @day and mealType = @type and dateUsed = @date;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@day", MySqlDbType.VarChar).Value = day;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            using var reader = command.ExecuteReader();

        }

        public static Boolean exists(string connectionString, string type, DateTime date)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) > 0 FROM planned_recipe WHERE dateUsed = @date AND mealType = @type", connection);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@type", type);

                long result = (long)command.ExecuteScalar();
                bool exists = (result > 0);

                connection.Close();

                return exists;
            }
        }

        public static void UpdateThisWeeksMeal(string connectionString, string day, string type, DateTime date,
            int recipeId)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"Update planned_recipe set recipeID = @id WHERE dayOfTheWeek = @day and mealType = @type and dateUsed = @date;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = recipeId;
            command.Parameters.Add("@day", MySqlDbType.VarChar).Value = day;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            using var reader = command.ExecuteReader();
        }
    }
    
}
