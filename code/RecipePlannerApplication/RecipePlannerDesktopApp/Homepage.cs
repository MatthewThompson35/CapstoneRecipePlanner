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
    public partial class Homepage : Form
    {
        public Recipe currentRecipe { get; set; }
        public List<Recipe> recipes { get; set; }

        public Homepage()
        {
            InitializeComponent();
            this.recipes = new List<Recipe>();

            this.showAvailableRecipesRadioButton.Checked = true;
            
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
            foreach (var recipe in RecipeDAL.getRecipes())
            {
                this.recipeListView.Items.Add(recipe.Name);
            }
            this.recipeListView.View = View.List;
        }

        private void showAvailableRecipes()
        {

            List<Recipe> availableRecipes = new List<Recipe>();

            foreach (var recipe in RecipeDAL.getRecipes())
            {
                var add = true;
                recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId);
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
                    this.recipeListView.Items.Add(availableRecipe.Name);
                }
            }
            else
            {
                this.noRecipesLabel.Visible = true;
            }

            this.recipeListView.View = View.List;
        }

        private void recipeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.recipeListView.SelectedItems.Count > 0)
            {
                //this.currentRecipe = (Recipe) this.recipeListView.SelectedItems[0].Tag;
                //int recipeId = Convert.ToInt32(this.recipeListView.SelectedItems[0].SubItems[1].Text);
                //string name = this.recipeListView.SelectedItems[0].Text;
                //string description = this.recipeListView.SelectedItems[0].SubItems[2].Text;

                //Recipe recipe = new Recipe(recipeId, name, description);

                //string message = "Name: " + this.recipeListView.SelectedItems[0].Text + Environment.NewLine;
                //message += "ID: " + this.recipeListView.SelectedItems[0].SubItems[1].Text;
                //MessageBox.Show(message);

                this.Hide();

                RecipeDetailsPage detailsPage = new RecipeDetailsPage();
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
