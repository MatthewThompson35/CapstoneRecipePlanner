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

        public RecipeStepAdd(List<RecipeStep> stepDatas) :this()
        {
            recipeSteps = stepDatas;
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
                bool isDuplicate = false;
                if (this.recipeSteps != null)
                {
                    foreach (DataGridViewRow row in this.stepsDataGridView.Rows)
                    {
                        string existingStepNumber = row.Cells["stepNumberColumn"].Value.ToString();
                        
                        if (recipeStep.stepNumber.Equals(Convert.ToInt32(existingStepNumber)))
                        {
                            this.errorStepsFieldLabel.Text = "This step already exists.";
                            this.errorStepsFieldLabel.Visible = true;
                            isDuplicate = true;
                            break;
                        }
                    }
                }

                if (isDuplicate == true)
                {
                    return;
                }
                else
                {
                    this.errorStepsFieldLabel.Visible = false;
                    
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
            foreach (DataGridViewRow row in this.stepsDataGridView.Rows)
            {
                string stepNumberData;
                string stepDescriptionData;

                stepNumberData = row.Cells["stepNumberColumn"].Value.ToString();
                stepDescriptionData = row.Cells["stepDescriptionColumn"].Value.ToString();

                RecipeStep recipeStep = new RecipeStep(Convert.ToInt32(stepNumberData), stepDescriptionData);

                if (recipeSteps.Any(rs => rs.Equals(recipeStep)))
                {
                    continue;
                }
                else
                {
                    recipeSteps.Add(recipeStep);
                }
            }
            var recipeSummary = new RecipeSummary();

            recipeSummary.SetStepData(recipeSteps);
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
                DataGridViewRow row = stepsDataGridView.Rows[e.RowIndex];

                string stepNumberData;
                string stepDescriptionData;

                stepNumberData = row.Cells["stepNumberColumn"].Value.ToString();
                stepDescriptionData = row.Cells["stepDescriptionColumn"].Value.ToString();

                RecipeStep recipeStep = new RecipeStep(Convert.ToInt32(stepNumberData), stepDescriptionData);

                recipeSteps.Remove(recipeStep);

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

        private void RecipeStepAdd_Load(object sender, EventArgs e)
        {
            if (recipeSteps != null)
            {
                foreach (var recipeStep in this.recipeSteps)
                {
                    int rowIndex = this.stepsDataGridView.Rows.Add();

                    stepsDataGridView.Rows[rowIndex].Cells["stepNumberColumn"].Value = recipeStep.stepNumber;
                    stepsDataGridView.Rows[rowIndex].Cells["stepDescriptionColumn"].Value = recipeStep.stepDescription;
                }
            }
        }
    }
}
