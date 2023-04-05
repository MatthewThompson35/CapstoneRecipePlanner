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

            int number;

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

                bool isNumeric = int.TryParse(quantity, out number);

                if (!isNumeric)
                {
                    this.errorQuantityLabel.Visible = true;
                }
                else
                {
                    this.errorQuantityLabel.Visible = false;
                }
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

            if (this.errorIngredientsFieldsLabel.Visible == true || this.errorQuantityLabel.Visible == true)
            {
                return;
            }
            else
            {
                RecipeIngredient recipeIngredient = new RecipeIngredient(ingredientName, Convert.ToInt32(quantity), measurement);

                foreach (var ingredient in this.recipeIngredients)
                {
                    if (recipeIngredient.IngredientName.Equals(ingredient.IngredientName) && recipeIngredient.Quantity == ingredient.Quantity && recipeIngredient.Measurement.Equals(ingredient.Measurement))
                    {
                        this.errorIngredientsFieldsLabel.Text = "Ingredient already exists.";
                        this.errorIngredientsFieldsLabel.Visible = true;
                    }
                }
                if (this.errorIngredientsFieldsLabel.Visible == true)
                {
                    return;
                }
                else
                {
                    this.recipeIngredients.Add(recipeIngredient);

                    this.ingredientSuccessLabel.Visible = true;

                    this.clearIngredientsFields();
                }

                
            }

            
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
            int number;

            if (String.IsNullOrEmpty(this.stepNumberTextBox.Text))
            {
                this.errorStepsFieldLabel.Visible = true;
            }
            else
            {
                this.errorStepsFieldLabel.Visible = false;
                stepNumber = this.stepNumberTextBox.Text;

                bool isNumeric = int.TryParse(stepNumber, out number);

                if (!isNumeric)
                {
                    this.errorStepNumberLabel.Visible = true;
                }
                else
                {
                    this.errorStepNumberLabel.Visible = false;
                }
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

            if (this.errorStepsFieldLabel.Visible == true || this.errorStepNumberLabel.Visible == true)
            {
                return;
            }
            else
            {
                RecipeStep recipeStep = new RecipeStep(Convert.ToInt32(stepNumber), stepDescription);

                foreach (var step in this.GetRecipeSteps())
                {
                    if (recipeStep.stepNumber.Equals(step.stepNumber))
                    {
                        this.errorStepNumberLabel.Text = "This number already exists";
                        this.errorStepNumberLabel.Visible = true;
                    }
                    else
                    {
                        this.errorStepNumberLabel.Visible = false;
                    }
                }

                if (this.errorStepNumberLabel.Visible == true)
                {
                    return;
                }
                else
                {
                    recipeSteps.Add(recipeStep);

                    this.stepsSuccessLabel.Visible = true;
                    this.clearStepsFields();
                }
                
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

            if (this.errorTagFieldLabel.Visible == true)
            {
                return;
            }
            else
            {
                foreach (var aTag in this.tags)
                {
                    if (tag.Equals(aTag))
                    {
                        this.errorTagFieldLabel.Text = "This tag already exists";
                        this.errorTagFieldLabel.Visible = true;
                    }
                    else
                    {
                        this.errorTagFieldLabel.Visible = false;
                    }
                }
                if (this.errorTagFieldLabel.Visible == true)
                {
                    return;
                }
                else
                {
                    tags.Add(tag);

                    this.tagSuccessLabel.Visible = true;

                    this.clearTagNameField();
                }
            }
            
        }

        private void textBoxesIngredients_Changed(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() {
                this.ingredientNameTextBox, this.quantityTextBox, this.measurementTextBox };

            foreach (var textBox in textBoxes)
            {
                if (!String.IsNullOrEmpty(textBox.Text))
                {
                    this.ingredientSuccessLabel.Visible = false;
                }
            }
        }

        private void ingredientNameTextBox_Click(object sender, EventArgs e)
        {
            this.ingredientSuccessLabel.Visible = false;
        }

        private void quantityTextBox_Click(object sender, EventArgs e)
        {
            this.ingredientSuccessLabel.Visible = false;
        }

        private void measurementTextBox_Click(object sender, EventArgs e)
        {
            this.ingredientSuccessLabel.Visible = false;
        }

        private void stepNumberTextBox_Click(object sender, EventArgs e)
        {
            this.stepsSuccessLabel.Visible = false;
        }

        private void stepDescriptionTextBox_Click(object sender, EventArgs e)
        {
            this.stepsSuccessLabel.Visible = false;
        }

        private void tagNameTextBox_Click(object sender, EventArgs e)
        {
            this.tagSuccessLabel.Visible = false;
        }
    }
}
