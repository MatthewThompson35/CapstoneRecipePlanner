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
    }
}
