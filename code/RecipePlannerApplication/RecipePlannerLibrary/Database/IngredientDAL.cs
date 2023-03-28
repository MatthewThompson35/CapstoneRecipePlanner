using System;
using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    ///     Manages the data and functionality for a Ingredient DAL object
    /// </summary>
    public class IngredientDAL
    {
        #region Methods

        /// <summary>
        ///     Gets the ingredients from the ingredient table.
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>List of all ingredients</returns>
        public static List<Ingredient> getIngredients()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var ingredients = new List<Ingredient>();
            var user = ActiveUser.username;
            var query = @"SELECT i.ingredientID, i.username, i.quantity, ii.ingredientName, ii.measurementType FROM ingredient i, ingredient_info ii WHERE i.ingredientID = ii.ingredientID and username=@user;";
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
        ///     Adds the ingredient with the specified data into the table
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

            var query = @"INSERT INTO ingredient_info (ingredientName, measurementType) SELECT @name, @measurement WHERE NOT EXISTS (SELECT 1 FROM ingredient_info WHERE ingredientName = @name); INSERT INTO ingredient (ingredientID, username, quantity) SELECT ingredientID, @username, @quantity FROM ingredient_info WHERE ingredientName = @name;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
            command.Parameters.Add("@Measurement", MySqlDbType.VarChar).Value = measurement;
            command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Decrements the quantity of the ingredient with the given id in the database.
        /// </summary>
        /// <param name="id">The id of the ingredient.</param>
        /// <param name="quantity">The current quantity of the ingredient.</param>
        /// <precondition>none</precondition>
        /// <postcondition>Quantity for the given ingredient is decreased by 1</postcondition>
        public static void decrementQuantity(int id, int quantity)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = @"Update ingredient set quantity = @quantity where ingredientID = @id and username = @username";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity - 1;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Increments the quantity of the ingredient in the database.
        /// </summary>
        /// <param name="id">The id of the ingredient.</param>
        /// <param name="quantity">The quantity of the ingredient.</param>
        /// <precondition>none</precondition>
        /// <postcondition>Quantity of the given ingredient is incremented by 1</postcondition>
        public static void incrementQuantity(int id, int quantity)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = @"Update ingredient set quantity = @quantity where ingredientID = @id and username = @username";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity + 1;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Removes the ingredient from the database.
        /// </summary>
        /// <param name="id">The id of the ingredient.</param>
        /// <precondition>none</precondition>
        /// <postcondition>Ingredient is removed from the database</postcondition>
        public static void RemoveIngredient(int id, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"Delete from ingredient where ingredientID = @id AND USERNAME = @USER";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@USER", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.ExecuteNonQuery();
        }

        /// <summary>
        ///     Gets the ingredients by the specified ingredient name
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
            var query = @"SELECT i.*, ii.ingredientName, ii.measurementType FROM ingredient i, ingredient_info ii WHERE i.ingredientID = ii.ingredientID AND ii.ingredientName = @ingredientName AND username = @user;";
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
        ///     Gets the ingredients from the shopping list table.
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>List of all ingredients in the users shopping list</returns>
        public static List<Ingredient> GetIngredientsFromShoppingList()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var ingredients = new List<Ingredient>();
            var user = ActiveUser.username;
            var query = @"SELECT sl.ingredientID, sl.username, sl.quantity, ii.ingredientName, ii.measurementType FROM shopping_list sl, ingredient_info ii WHERE sl.ingredientID = ii.ingredientID and username=@user;";
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

        #endregion
    }
}