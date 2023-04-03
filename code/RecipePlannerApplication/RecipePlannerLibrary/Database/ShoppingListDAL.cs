using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    /// The Shopping list DAL that handles all of the methods for accessing or altering the shopping list
    /// </summary>
    public class ShoppingListDAL
    {
        /// <summary>
        /// Gets the ingredients for the shopping list.
        /// </summary>
        /// <returns></returns>
        public static List<Ingredient> getIngredients()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var ingredients = new List<Ingredient>();
            var user = ActiveUser.username;
            var query = @"SELECT i.ingredientID, i.username, i.quantity, ii.ingredientName, ii.measurementType FROM shopping_list i, ingredient_info ii WHERE i.ingredientID = ii.ingredientID and username=@user;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var username = reader.GetString(1);
                var name = reader.GetString(3);
                var quantity = reader.GetInt32(2);
                var id = reader.GetInt32(0);
                var measurement = reader.GetString(4).ToUpper();

                var ingredient = new Ingredient(username, name, quantity, id, measurement);

                ingredients.Add(ingredient);
            }

            return ingredients;
        }

        /// <summary>
        ///     Adds the shopping list ingredient with the specified data into the table
        /// </summary>
        /// <param name="name">The name of the ingredient.</param>
        /// <param name="quantity">The quantity of the ingredient.</param>
        /// <param name="measurement">The measurement type of the ingredient.</param>
        /// <precondition>none</precondition>
        /// <postcondition>The ingredient is added to the database</postcondition>
        public static void addIngredient(string name, int quantity, string measurement, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = @"INSERT INTO ingredient_info (ingredientName, measurementType) SELECT @name, @measurement WHERE NOT EXISTS (SELECT 1 FROM ingredient_info WHERE ingredientName = @name); INSERT INTO shopping_list (ingredientID, username, quantity) SELECT ingredientID, @username, @quantity FROM ingredient_info WHERE ingredientName = @name;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
            command.Parameters.Add("@Measurement", MySqlDbType.VarChar).Value = measurement;
            command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Decrements the quantity of the shopping list ingredient with the given id in the database.
        /// </summary>
        /// <param name="id">The id of the ingredient.</param>
        /// <param name="quantity">The current quantity of the ingredient.</param>
        /// <precondition>none</precondition>
        /// <postcondition>Quantity for the given ingredient is decreased by 1</postcondition>
        public static void decrementQuantity(int id, int quantity)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = @"Update shopping_list set quantity = @quantity where ingredientID = @id and username = @username";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity - 1;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Increments the quantity of the shopping list ingredient in the database.
        /// </summary>
        /// <param name="id">The id of the ingredient.</param>
        /// <param name="quantity">The quantity of the ingredient.</param>
        /// <precondition>none</precondition>
        /// <postcondition>Quantity of the given ingredient is incremented by 1</postcondition>
        public static void incrementQuantity(int id, int quantity)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = @"Update shopping_list set quantity = @quantity where ingredientID = @id and username = @username";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity + 1;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Removes the shopping list ingredient from the database.
        /// </summary>
        /// <param name="id">The id of the ingredient.</param>
        /// <precondition>none</precondition>
        /// <postcondition>Ingredient is removed from the database</postcondition>
        public static void RemoveIngredient(int id, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"Delete from shopping_list where ingredientID = @id AND USERNAME = @USER";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@USER", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Gets the ingredients by the specified ingredient name in the shopping list
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>List of ingredients that match ingredient name.</returns>
        public static List<Ingredient> getIngredients(string ingredientName)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var ingredients = new List<Ingredient>();
            var user = ActiveUser.username;
            var query = @"SELECT i.*, ii.ingredientName, ii.measurementType FROM shopping_list i, ingredient_info ii WHERE i.ingredientID = ii.ingredientID AND ii.ingredientName = @ingredientName AND username = @user;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
            command.Parameters.Add("@ingredientName", MySqlDbType.VarChar).Value = ingredientName;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var username = reader.GetString(1);
                var name = reader.GetString(3);
                var quantity = reader.GetInt32(2);
                var id = reader.GetInt32(0);
                var measurement = reader.GetString(4);

                var ingredient = new Ingredient(username, name, quantity, id, measurement);

                ingredients.Add(ingredient);
            }

            return ingredients;
        }

        /// <summary>
        ///     Updates the quantity of the ingredient in the database.
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>Quantity of the given ingredient is updated by the given quantity.</postcondition>
        /// <param name="id">The id of the ingredient.</param>
        /// <param name="quantity">The quantity of the ingredient.</param>
        public static void updateQuantity(int id, int quantity)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = @"Update shopping_list set quantity = @quantity where ingredientID = @id and username = @username";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.ExecuteNonQuery();

        }

        /// <summary>
        /// Removes all rows from the table where username matches.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public static void removeAll(string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"DELETE FROM shopping_list WHERE USERNAME = @user;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@USER", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.ExecuteNonQuery();
        }

    }
}
