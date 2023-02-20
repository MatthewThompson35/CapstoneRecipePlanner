using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    /// Recipe DAL
    /// </summary>
    public class RecipeDAL
    {
        /// <summary>
        /// Gets all of the recipes from the recipe table.
        /// </summary>
        /// <returns>List of all recipes</returns>
        public static List<Recipe> getRecipes()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            List<Recipe> recipes = new List<Recipe>();
            string query = @"Select * from recipe;";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int recipeID = reader.GetInt32(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);

                Recipe recipe = new Recipe(recipeID, name, description);

                recipes.Add(recipe);
            }
            return recipes;
        }
    }
}
