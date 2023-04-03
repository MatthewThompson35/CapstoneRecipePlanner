using MySql.Data.MySqlClient;
using RecipePlannerLibrary.Models;
using System.Collections.Generic;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    ///     Manages the data and functionality for a Recipe DAL object
    /// </summary>
    public class RecipeDAL
    {
        #region Methods

        /// <summary>
        ///     Gets all of the recipes from the recipe table.
        /// </summary>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
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
        ///     Gets all of the recipes shared with the active user from the shared recipe table.
        /// </summary>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>List of all shared recipes</returns>
        public static List<Recipe> getSharedRecipes(string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var recipes = new List<Recipe>();
            var query = @"Select r.recipeID, r.name, r.description from shared_recipe sr, recipe r where r.recipeID = sr.recipeID and sr.receiver_username = @user;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = ActiveUser.username;
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
        ///     Gets the recipe name based on the specified recipe id.
        /// </summary>
        /// <param name="recipeId">the recipe id.</param>
        /// <param name="connectionString">the connection string.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>the recipe name.</returns>
        public static string getRecipeNameById(int recipeId, string connectionString)
        {
            Recipe recipe = new Recipe();
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"Select name from recipe where recipeID=@recipeId;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@recipeId", MySqlDbType.Int32).Value = recipeId;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(0);

                recipe.Name = name;
            }

            connection.Close();
            return recipe.Name;
        }

        /// <summary>
        ///     Gets the recipe with the given name.
        /// </summary>
        /// <param name="name">the name of the recipe</param>
        /// <param name="connectionString">the connection string</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>a recipe based on the recipe name.</returns>
        public static Recipe getRecipeByName(string name, string connectionString)
        {
            Recipe recipe = new Recipe();
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var query = @"Select * from recipe where name = @name;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@name", MySqlDbType.String).Value = name;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var recipeId = reader.GetInt32(0);
                var recipeName = reader.GetString(1);
                var description = reader.GetString(2);

                recipe.RecipeId = recipeId;
                recipe.Name = recipeName;
                recipe.Description = description;
                
            }

            connection.Close();
            return recipe;
        }

        /// <summary>
        ///     Gets the ingredients associated with a specified recipeID.
        /// </summary>
        /// <param name="id">the recipe id.</param>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>List of all ingredients associated with specified recipeID</returns>
        public static List<RecipeIngredient> getIngredientsForRecipe(int id, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var ingredients = new List<RecipeIngredient>();
            var query = @"Select ri.recipeID, ii.ingredientName, ri.quantity, ri.measurement from recipe_ingredient ri, ingredient_info ii where recipeID = @id and ri.ingredientID = ii.ingredientID;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = ActiveUser.username;
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
        /// <param name="id">The recipe id.</param>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
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
        /// <param name="id">The recipe id.</param>
        /// <param name="connectionString">The connection string for the table.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
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

        /// <summary>
        ///     Shares the recipe with the specified user. Adds recipe to shared recipe table
        /// </summary>
        /// <param name="username">The usernname the recipe is being shared to.</param>
        /// <precondition>none</precondition>
        /// <postcondition>The shared recipe is added to the database</postcondition>
        public static void shareRecipe(string username, int recipeID, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query =
                @"INSERT INTO shared_recipe (sender_username, receiver_username, recipeID) VALUES (@senderUsername, @receiverUsername, @recipeID);";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@senderUsername", MySqlDbType.VarChar).Value = ActiveUser.username;
            command.Parameters.Add("@receiverUsername", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@recipeID", MySqlDbType.Int32).Value = recipeID;
            command.ExecuteNonQuery();
        }

        #endregion
    }
}