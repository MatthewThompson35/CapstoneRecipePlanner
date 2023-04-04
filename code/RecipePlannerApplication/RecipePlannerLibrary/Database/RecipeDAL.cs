using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using RecipePlannerLibrary.Models;
using System.Collections.Generic;
using Org.BouncyCastle.Tls;
using System.Xml.Linq;


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
        public static List<SharedRecipe> getSharedRecipes(string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var recipes = new List<SharedRecipe>();
            var query = @"Select * from shared_recipe sr, recipe r where r.recipeID = sr.recipeID and sr.receiver_username = @user;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = ActiveUser.username;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(4);
                var description = reader.GetString(5);

                var sender = reader.GetString(0);
                var receiver = reader.GetString(1);
                var recipeID = reader.GetInt32(2);


                Recipe recipe = new Recipe(recipeID, name, description);
                recipe.Tags = RecipeDAL.getTagsForRecipe(recipeID, connectionString);

                var sharedRecipe = new SharedRecipe(recipe, sender, receiver);
                recipes.Add(sharedRecipe);
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
        ///     Adds a new Recipe to the database.
        /// </summary>
        /// <param name="name">the name of the recipe.</param>
        /// <param name="description">the description of the recipe.</param>
        /// <param name="connectionString">the connection string to the database.</param>
        public static void addRecipe(string name, string description, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = @"insert into recipe(name, description) values(@name, @description);";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Adds the recipe ingredient to the database.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="ingredientName">Name of the ingredient.</param>
        /// <param name="ingredientId">The ingredient identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="measurement">The measurement.</param>
        /// <param name="connectionString">The connection string.</param>
        public static void addRecipeIngredient(int recipeId,string ingredientName, int ingredientId, int quantity, string measurement, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = @"INSERT INTO ingredient_info (ingredientName, measurementType) SELECT @name, @measurement WHERE NOT EXISTS (SELECT 1 FROM ingredient_info WHERE ingredientName = @name); INSERT INTO recipe_ingredient (recipeID, ingredientID, quantity, measurement) SELECT @recipeID, ingredientID, @quantity, @measurement FROM ingredient_info WHERE ingredientName = @name;";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@recipeId", MySqlDbType.Int32).Value = recipeId;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = ingredientName;
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
            command.Parameters.Add("@measurement", MySqlDbType.VarChar).Value = measurement;
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Adds the recipe step to the database.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="stepNumber">The step number.</param>
        /// <param name="stepDescription">The step description.</param>
        /// <param name="connectionString">The connection string.</param>
        public static void addRecipeStep(int recipeId, int stepNumber, string stepDescription, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = @"Insert Into recipe_step (recipeID, stepNumber, stepDescription) values (@recipeId, @stepNumber, @stepDescription)";
            using var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@recipeId", MySqlDbType.Int32).Value = recipeId;
            command.Parameters.Add("@stepNumber", MySqlDbType.Int32).Value = stepNumber;
            command.Parameters.Add("@stepDescription", MySqlDbType.VarChar).Value = stepDescription;
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Adds the recipe tag to the database.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="connectionString">The connection string.</param>
        public static void addRecipeTag(int recipeId, string tagName, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var query = @"insert into recipe_tag(recipeID, tagName) values (@recipeId, @tagName)";
            using var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@recipeId", MySqlDbType.Int32).Value = recipeId;
            command.Parameters.Add("@tagName", MySqlDbType.VarChar).Value = tagName;
            command.ExecuteNonQuery();
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

        /// <summary>
        ///     Determines whether the database contains the shared recipe.
        /// </summary>
        /// <param name="recipe">The recipe being searched for.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>List of Shared Recipes that match the recipe</returns>
        public static List<string> ContainsSharedRecipe(SharedRecipe recipe)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var list = new List<string>();
            var sender = recipe.SenderUsername;
            var receiver = recipe.ReceiverUsername;
            var id = recipe.Recipe.RecipeId;
            var query = @"Select * from shared_recipe where sender_username=@sender and receiver_username=@receiver and recipeID=@id;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@sender", MySqlDbType.VarChar).Value = sender;
            command.Parameters.Add("@receiver", MySqlDbType.VarChar).Value = receiver;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }

            return list;
        }

        /// <summary>
        ///     Gets the shared recipe name based on the specified recipe id.
        /// </summary>
        /// <param name="recipeId">the recipe id.</param>
        /// <param name="connectionString">the connection string.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>the recipe name.</returns>
        public static SharedRecipe ContainsSharedRecipe(int recipeId)
        {
            SharedRecipe shared = null;
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = @"Select * from shared_recipe sr, recipe r where r.recipeID=sr.recipeID and sr.recipeID=@recipeId;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@recipeId", MySqlDbType.Int32).Value = recipeId;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var sender = reader.GetString(0);
                var receiver = reader.GetString(1);
                var recipeID = reader.GetInt32(2);
                var recipeName = reader.GetString(4);
                var description = reader.GetString(5);

                Recipe recipe = new Recipe(recipeID, recipeName, description);
                shared = new SharedRecipe(recipe, sender, receiver);
            }

            connection.Close();
            return shared;
        }

        #endregion
    }
}