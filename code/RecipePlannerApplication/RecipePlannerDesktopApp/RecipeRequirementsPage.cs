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
    public partial class RecipeRequirementsPage : Form
    {
        public List<RecipeIngredient> recipeIngredients { get; set; }
        public List<RecipeStep> recipeSteps { get; set; }
        public List<string> tags { get; set; }

        /// <summary>
        ///     Initializes the recipe requirements page.
        /// </summary>
        public RecipeRequirementsPage()
        {
            InitializeComponent();

            recipeIngredients = new List<RecipeIngredient>();
            recipeSteps = new List<RecipeStep>();
            tags = new List<string>();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var recipePage = new RecipePage();

            this.Hide();

            recipePage.Show();
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            string ingredientName = null;
            string quantity = null;
            string measurement = null;

            if (String.IsNullOrEmpty(this.ingredientNameTextBox.Text))
            {
                this.errorIngredientsFieldsLabel.Visible = true;
            } 
            else
            {
                this.errorIngredientsFieldsLabel.Visible = false;
                ingredientName = this.ingredientNameTextBox.Text;
            }
                
            if (String.IsNullOrEmpty(this.quantityTextBox.Text))
            {
                this.errorIngredientsFieldsLabel.Visible = true;
            }
            else
            {
                this.errorIngredientsFieldsLabel.Visible = false;
                quantity = this.quantityTextBox.Text;
            }

            if (String.IsNullOrEmpty(this.measurementTextBox.Text))
            {
                this.errorIngredientsFieldsLabel.Visible = true;
            }
            else
            {
                this.errorIngredientsFieldsLabel.Visible = false;
                measurement = this.measurementTextBox.Text;
            }

            var recipePage = new RecipePage();

            recipePage.AddRowToIngredientGridView(ingredientName, quantity, measurement);

            this.Hide();
            recipePage.Show();

            this.ingredientSuccessLabel.Visible = true;
                
        }

        private void addStepButton_Click(object sender, EventArgs e)
        {
            string stepNumber = null;
            string stepDescription = null;

            if (String.IsNullOrEmpty(this.stepNumberTextBox.Text))
            {
                this.errorStepsFieldLabel.Visible = true;
            }
            else
            {
                this.errorStepsFieldLabel.Visible = false;
                stepNumber = this.stepNumberTextBox.Text;
            }
            
            if (String.IsNullOrEmpty(this.stepDescriptionTextBox.Text))
            {
                this.errorStepsFieldLabel.Visible = true;
            }
            else
            {
                this.errorStepsFieldLabel.Visible = false;
                stepDescription = this.stepDescriptionTextBox.Text;
            }
           


        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            string tag = null;
            
            if (String.IsNullOrEmpty(this.tagNameTextBox.Text))
            {
                this.errorTagFieldLabel.Visible = true;
            }
            else
            {
                this.errorTagFieldLabel.Visible = false;
                tag = this.tagNameTextBox.Text;
            }
        }
    }
}
