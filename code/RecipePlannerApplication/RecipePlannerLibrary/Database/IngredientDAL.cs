using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    ///     Ingredient DAL
    /// </summary>
    public class IngredientDAL
    {
        #region Methods

        /// <summary>
        ///     Gets the ingredients.
        /// </summary>
        /// <returns>List of ingredients</returns>
        public static List<Ingredient> getIngredients()
        {
            try
            {
                using var connection = new MySqlConnection(Connection.ConnectionString);
                connection.Open();
                var ingredients = new List<Ingredient>();
                var user = ActiveUser.username;
                var query = @"Select * from ingredient where username=@user;";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var username = reader.GetString(0);
                    var name = reader.GetString(1);
                    var quantity = reader.GetInt32(2);
                    var id = reader.GetInt32(3);
                    var measurement = reader.GetString(4).ToUpper();

                    var ingredient = new Ingredient(username, name, quantity, id, measurement);

                    ingredients.Add(ingredient);
                }

                return ingredients;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
                return null;
            }
        }

        /// <summary>
        ///     Adds the ingredient.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="quantity">The quantity.</param>
        public static void addIngredient(string name, int quantity, string measurement)
        {
            try
            {
                using var connection = new MySqlConnection(Connection.ConnectionString);
                connection.Open();
                var query =
                    @"Insert into ingredient (username, ingredientName, quantity, Measurement) values(@username, @name, @quantity, @Measurement);";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ActiveUser.username;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
                command.Parameters.Add("@Measurement", MySqlDbType.VarChar).Value = measurement;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
            }
        }

        /// <summary>
        ///     Decrements the quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        public static void decrementQuantity(int id, int quantity)
        {
            try
            {
                using var connection = new MySqlConnection(Connection.ConnectionString);
                connection.Open();
                var query = @"Update ingredient set quantity = @quantity where ingredientID = @id";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity - 1;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
            }
        }

        /// <summary>
        ///     Increments the quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        public static void incrementQuantity(int id, int quantity)
        {
            try
            {
                using var connection = new MySqlConnection(Connection.ConnectionString);
                connection.Open();
                var query = @"Update ingredient set quantity = @quantity where ingredientID = @id";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity + 1;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
            }
        }

        /// <summary>
        ///     Removes the ingredient.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public static void RemoveIngredient(int id)
        {
            try
            {
                using var connection = new MySqlConnection(Connection.ConnectionString);
                connection.Open();
                var query = @"Delete from ingredient where ingredientID = @id";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
            }
        }

        /// <summary>
        ///     Gets the ingredients.
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient.</param>
        /// <returns></returns>
        public static List<Ingredient> getIngredients(string ingredientName)
        {
            try
            {
                using var connection = new MySqlConnection(Connection.ConnectionString);
                connection.Open();
                var ingredients = new List<Ingredient>();
                var user = ActiveUser.username;
                var query = @"Select * from ingredient where username=@user and ingredientName = @ingredientName;";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
                command.Parameters.Add("@ingredientName", MySqlDbType.VarChar).Value = ingredientName;
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var username = reader.GetString(0);
                    var name = reader.GetString(1);
                    var quantity = reader.GetInt32(2);
                    var id = reader.GetInt32(3);
                    var measurement = reader.GetString(4);

                    var ingredient = new Ingredient(username, name, quantity, id, measurement);

                    ingredients.Add(ingredient);
                }

                return ingredients;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection to the server was not made. Please try again: " + ex.ToString());
                return null;
            }
        }

            #endregion
    }
}