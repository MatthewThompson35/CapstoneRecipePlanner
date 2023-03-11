using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;
using System.Collections.Generic;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    ///     Recipe DAL
    /// </summary>
    public class RecipeDAL
    {
        #region Methods

        /// <summary>
        ///     Gets all of the recipes from the recipe table.
        /// </summary>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <returns>List of all recipes</returns>
        public static List<Recipe> getRecipes(string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var recipes = new List<Recipe>();
            var query = @"Select * from recipe;";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var recipeID = reader.GetInt32(0);
                var name = reader.GetString(1);
                var description = reader.GetString(2);

                var recipe = new Recipe(recipeID, name, description);
                recipe.Tags = RecipeDAL.getTagsForRecipe(recipeID, connectionString);

                recipes.Add(recipe);
            }

            connection.Close();
            return recipes;
        }



        /// <summary>
        ///     Gets the ingredients associated with a specified recipeID.
        /// </summary>
        /// <param name="id">the recipe id.</param>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <returns>List of all ingredients associated with specified recipeID</returns>
        public static List<RecipeIngredient> getIngredientsForRecipe(int id, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var ingredients = new List<RecipeIngredient>();
            var query = @"Select * from recipe_ingredient where recipeID=@id;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var recipeID = reader.GetInt32(0);
                var ingredientName = reader.GetString(1);
                var quantity = reader.GetInt32(2);
                var measurement = reader.GetString(3);

                var ingredient = new RecipeIngredient(recipeID, ingredientName, quantity, measurement);
                ingredients.Add(ingredient);
            }

            connection.Close();
            return ingredients;
        }

        /// <summary>
        ///     Gets the recipe steps associated with a specified recipeID.
        /// </summary>
        ///
        /// <param name="id">The recipe id.</param>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <returns>List of all steps associated with a specified recipeID</returns>
        public static List<RecipeStep> getStepsForRecipe(int id, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var steps = new List<RecipeStep>();
            var query = @"Select * from recipe_step where recipeID=@id;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var recipeID = reader.GetInt32(0);
                var stepNumber = reader.GetInt32(1);
                var stepDescription = reader.GetString(2);

                var recipeStep = new RecipeStep(recipeID, stepNumber, stepDescription);
                steps.Add(recipeStep);
            }

            connection.Close();
            return steps;
        }

        /// <summary>
        ///     Gets the recipe tags associated with a specified recipeID.
        /// </summary>
        ///
        /// <param name="id">The recipe id.</param>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <returns>List of all tags associated with a specified recipeID</returns>
        public static List<string> getTagsForRecipe(int id, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var tags = new List<string>();
            var query = @"Select * from recipe_tag where recipeID=@id;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var tagName = reader.GetString(1);
                tags.Add(tagName);
            }

            connection.Close();
            return tags;
        }

        #endregion
    }
}