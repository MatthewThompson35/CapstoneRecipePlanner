using RecipePlannerDesktopApplication;
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

namespace RecipePlannerFinalDemoAdditions
{
    public partial class RecipeStepAdd : Form
    {
        private List<RecipeStep> recipeSteps;
        public RecipeStepAdd()
        {
            InitializeComponent();
            recipeSteps = new List<RecipeStep>();
        }

        public List<RecipeStep> GetRecipeSteps()
        {
            return this.recipeSteps;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string stepNumber = null;
            string stepDescription = null;
            int number;

            if (String.IsNullOrEmpty(this.stepNumberTextBox.Text) || String.IsNullOrEmpty(this.stepDescriptionTextBox.Text))
            {
                this.errorStepsFieldLabel.Visible = true;
            }
            else
            {
                this.errorStepsFieldLabel.Visible = false;
                stepNumber = this.stepNumberTextBox.Text;
                stepDescription = this.stepDescriptionTextBox.Text;

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

            if (this.errorStepsFieldLabel.Visible == true || this.errorStepNumberLabel.Visible == true)
            {
                return;
            }
            else
            {
                RecipeStep recipeStep = new RecipeStep(Convert.ToInt32(stepNumber), stepDescription);

                foreach (var step in this.recipeSteps)
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
                    this.AddRowToStepsGridView(recipeStep.stepNumber.ToString(), recipeStep.stepDescription);
                    this.stepsSuccessLabel.Visible = true;
                    this.clearStepsFields();
                }

            }
        }

        /// <summary>
        ///     Adds a row to the steps grid view based on the step number and step description.
        /// </summary>
        /// <param name="stepNumber">the step number</param>
        /// <param name="stepDescription">the step description</param>
        public void AddRowToStepsGridView(string stepNumber, string stepDescription)
        {
            this.stepsDataGridView.Rows.Add(stepNumber, stepDescription);
        }


        private void clearStepsFields()
        {
            this.stepNumberTextBox.Clear();
            this.stepDescriptionTextBox.Clear();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var recipeSummary = new RecipeSummary();

            this.Hide();

            recipeSummary.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }

        private void stepsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == stepsDataGridView.Columns["removeColumn"].Index && e.RowIndex >= 0)
            {
                stepsDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void stepNumberTextBox_Click(object sender, EventArgs e)
        {
            this.stepsSuccessLabel.Visible = false;
        }

        private void stepDescriptionTextBox_Click(object sender, EventArgs e)
        {
            this.stepsSuccessLabel.Visible = false;
        }
    }
}
