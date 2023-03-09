using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;
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
            Dictionary<(string, string), int> thisWeeksMeals = new Dictionary<(string, string), int>();
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"SELECT *
            FROM planned_recipe
            WHERE dateUsed BETWEEN DATE_SUB(DATE(CURDATE()), INTERVAL WEEKDAY(CURDATE()) DAY) AND DATE_ADD(DATE_SUB(DATE(CURDATE()), INTERVAL WEEKDAY(CURDATE()) DAY), INTERVAL 6 DAY);";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int recipeId = reader.GetInt32(0); 
                string day = reader.GetString(1); 
                string type = reader.GetString(2);
                thisWeeksMeals.Add((day,type), recipeId);
            }
            return thisWeeksMeals;
        }
    }
}
