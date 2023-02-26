using MySql.Data.MySqlClient;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    ///     The Homepage partial class.
    /// </summary>
    public partial class Homepage : Form
    {
        private Recipe selectedRecipe;

        /// <summary>
        ///     Gets or sets the list of Recipes for the Homepage.
        /// </summary>
        public List<Recipe> Recipes { get; set; }

        /// <summary>
        ///     Initializes a Homepage for the recipes.
        /// </summary>
        public Homepage()
        {
            InitializeComponent();
            this.Recipes = new List<Recipe>();

            this.showAvailableRecipesRadioButton.Checked = true;
        }

        /// <summary>
        ///     Gets a selected recipe from the recipes list view in the homepage.
        /// </summary>
        /// <returns>a selected recipe.</returns>
        public Recipe GetSelectedRecipe()
        {
            return this.selectedRecipe;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage login = new LoginPage();
            login.Show();
        }

        private void viewIngredientsButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            IngredientsPage ingredientsPage = new IngredientsPage();

            ingredientsPage.Show();
        }

        private void viewAllRecipes()
        {
            foreach (var recipe in RecipeDAL.getRecipes(Connection.ConnectionString))
            {
                this.recipeListView.Items.Add(new ListViewItem { Text = recipe.Name, Tag = recipe });
            }
            this.recipeListView.View = View.List;
            this.recipeListView.Sorting = SortOrder.Ascending;
        }

        private void showAvailableRecipes()
        {

            List<Recipe> availableRecipes = new List<Recipe>();

            foreach (var recipe in RecipeDAL.getRecipes(Connection.ConnectionString))
            {
                var add = true;
                recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
                foreach (RecipeIngredient ingredient in recipe.Ingredients)
                {
                    var ing = IngredientDAL.getIngredients(ingredient.IngredientName);
                    if (ing != null && ing.Count > 0)
                    {
                        if (ing[0].quantity < ingredient.Quantity)
                        {
                            add = false;
                        }
                    }
                    else
                    {
                        add = false;
                    }


                }
                if (add)
                {
                    availableRecipes.Add(recipe);
                }


            }

            if (availableRecipes.Count > 0)
            {
                this.noRecipesLabel.Visible = false;
                foreach (var availableRecipe in availableRecipes)
                {
                    this.recipeListView.Items.Add(new ListViewItem { Text = availableRecipe.Name, Tag = availableRecipe });
                }
            }
            else
            {
                this.noRecipesLabel.Visible = true;
            }

            this.recipeListView.View = View.List;
            this.recipeListView.Sorting = SortOrder.Ascending;
        }

        private void recipeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.recipeListView.SelectedItems.Count > 0)
            {
                this.selectedRecipe = (Recipe)this.recipeListView.SelectedItems[0].Tag;
                

                this.Hide();

                RecipeDetailsPage detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
                
            }
        }

        private void showAllRecipesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.showAllRecipesRadioButton.Checked)
            {
                this.viewAllRecipes();
                this.noRecipesLabel.Visible = false;
            }

            else
            {
                this.recipeListView.Clear();
                return;
            }
            
        }

        private void showAvailableRecipesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.showAvailableRecipesRadioButton.Checked)
            {
                this.showAvailableRecipes();
            }
            else
            {
                this.recipeListView.Clear();
                return;
            }
        }
    }
}
