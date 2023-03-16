﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    ///     The PlannedMealDal class for database incorporation and modification.
    /// </summary>
    public class PlannedMealDal
    {
        #region Methods
        /// <summary>
        ///     Adds a planned meal to the database.
        /// </summary>
        /// <param name="connectionString">the connection string</param>
        /// <param name="recipeId">the recipe id.</param>
        /// <param name="day">the day</param>
        /// <param name="type">the meal type</param>
        /// <param name="date">the date for the meal to be added.</param>
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

        /// <summary>
        ///     Gets all this week's meals based on the specified connection string provided to connect to the database.
        /// </summary>
        /// <param name="connectionString">the connection string</param>
        /// <returns>all of this week's meals from the database.</returns>
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

        /// <summary>
        ///     Gets next week's meals based on the specified connection string provided to connect to the database.
        /// </summary>
        /// <param name="connectionString">the connection string.</param>
        /// <returns>all of next week's meals from the database.</returns>
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

        /// <summary>
        ///     Removes a meal from this week based on the specified connection string, id, day, meal type, and date of the meal.
        /// </summary>
        /// <param name="connectionString">the connection string</param>
        /// <param name="id">the recipe id</param>
        /// <param name="day">the day</param>
        /// <param name="type">the meal type</param>
        /// <param name="date">the date of the meal</param>
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

        /// <summary>
        ///     Determines whether an item in the database exists from the planned_recipe schema.
        /// </summary>
        /// <param name="connectionString">the connection string.</param>
        /// <param name="type">the meal type</param>
        /// <param name="date">the date of the meal</param>
        /// <returns>true if an item exists, otherwise false.</returns>
        public static bool exists(string connectionString, string type, DateTime date)
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

        /// <summary>
        ///     Updates a meal from this week based on the specified connection string, day, meal type, and date.
        /// </summary>
        /// <param name="connectionString">the connection string.</param>
        /// <param name="day">the day</param>
        /// <param name="type">the meal type</param>
        /// <param name="date">the date of the meal</param>
        /// <param name="recipeId">the recipe id.</param>
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
    
        #endregion
    }
