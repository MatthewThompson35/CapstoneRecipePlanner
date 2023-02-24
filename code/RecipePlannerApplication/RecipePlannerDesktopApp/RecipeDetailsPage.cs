using RecipePlannerLibrary.Database;
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
    public partial class RecipeDetailsPage : Form
    {
        private Homepage homepage;
        
        public RecipeDetailsPage(Homepage page)
        {
            InitializeComponent();
            this.homepage = page;

            this.recipeDetailsTextBox.Text = this.displayRecipeDetails();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            Homepage homepage = new Homepage();
            homepage.Show();

        }

        private string displayRecipeDetails()
        {
            string output = null;

            string description = this.homepage.getSelectedRecipe().Name + Environment.NewLine + this.homepage.getSelectedRecipe().Description + Environment.NewLine + Environment.NewLine;

            string steps = "Steps" + Environment.NewLine;

            foreach (var step in RecipeDAL.getStepsForRecipe(this.homepage.getSelectedRecipe().RecipeId))
            {
                steps += step.stepNumber + ". " + step.stepDescription + Environment.NewLine;
            }

            string ingredients = Environment.NewLine + "Ingredients" + Environment.NewLine;

            foreach (var ingredient in RecipeDAL.getIngredientsForRecipe(this.homepage.getSelectedRecipe().RecipeId))
            {
                ingredients += ingredient.Quantity + " " + ingredient.Measurement + " " + ingredient.IngredientName + Environment.NewLine;
            }
            
            output += description + steps + ingredients;
            return output;
        }
    }
}
