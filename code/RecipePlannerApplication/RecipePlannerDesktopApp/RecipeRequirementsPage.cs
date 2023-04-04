using RecipePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipePlannerDesktopApplication
{
    public partial class RecipeRequirementsPage : Form
    {
        private List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();

        public List<RecipeStep> recipeSteps { get; set; }
        public List<string> tags { get; set; }

        public RecipePage recipePage { get; }

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

        /// <summary>
        ///     Initializes the recipe requirements page based on the recipe page.
        /// </summary>
        /// <param name="recipePage">the recipe page.</param>
        public RecipeRequirementsPage(RecipePage recipePage) :this()
        {
            this.recipePage = recipePage;
        }

        /// <summary>
        ///     Gets the recipe ingredients
        /// </summary>
        /// <returns>the recipe ingredients</returns>
        public List<RecipeIngredient> GetRecipeIngredients()
        {
            return this.recipeIngredients;
        }

        /// <summary>
        ///     Gets the recipe steps.
        /// </summary>
        /// <returns>the recipe steps</returns>
        public List<RecipeStep> GetRecipeSteps()
        {
            return this.recipeSteps;
        }

        /// <summary>
        ///     Gets the tags.
        /// </summary>
        /// <returns>the tags</returns>
        public List<string> GetTags()
        {
            return this.tags;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            foreach (var ingredient in this.recipeIngredients)
            {
                recipePage.AddRowToIngredientGridView(ingredient.IngredientName, Convert.ToString(ingredient.Quantity), Convert.ToString(ingredient.Measurement));
            }

            foreach (var step in this.recipeSteps)
            {
                recipePage.AddRowToStepsGridView(Convert.ToString(step.stepNumber), step.stepDescription);
            }

            foreach (var tag in this.tags)
            {
                recipePage.AddRowToTagGridView(tag);
            }

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

            RecipeIngredient recipeIngredient = new RecipeIngredient(ingredientName, Convert.ToInt32(quantity), measurement);

            this.recipeIngredients.Add(recipeIngredient);

            this.ingredientSuccessLabel.Visible = true;

            this.clearIngredientsFields();
        }

        private void clearIngredientsFields()
        {
            this.ingredientNameTextBox.Clear();
            this.quantityTextBox.Clear();
            this.measurementTextBox.Clear();
        }

        private void clearStepsFields()
        {
            this.stepNumberTextBox.Clear();
            this.stepDescriptionTextBox.Clear();
        }

        private void clearTagNameField()
        {
            this.tagNameTextBox.Clear();
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

            RecipeStep recipeStep = new RecipeStep(Convert.ToInt32(stepNumber), stepDescription);

            recipeSteps.Add(recipeStep);

            this.stepsSuccessLabel.Visible = true;

            this.clearStepsFields();

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

            tags.Add(tag);

            this.tagSuccessLabel.Visible = true;

            this.clearTagNameField();
        }
    }
}
