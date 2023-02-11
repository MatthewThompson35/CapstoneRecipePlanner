using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Database
{
    public class IngredientDAL
    {
        public static List<Ingredient> getIngredients()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            List<Ingredient> ingredients = new List<Ingredient>();
            string query = @"Select * from ingredient;";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int quantity = reader.GetInt32(2);

                Ingredient ingredient = new Ingredient(id, name, quantity);

                ingredients.Add(ingredient);
            }
            return ingredients;
        }

        public static void addIngredient(string name, int quantity)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            string query = @"Insert into ingredient (ingredientName, quantity) values(@name, @quantity);";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
            command.ExecuteNonQuery();
        }

        public static void decrementQuantity(int quantity, int id)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            string query = @"Update ingredient set quantity = @quantity where ingredientID = @id";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity - 1;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.ExecuteNonQuery();
        }
    }
}
