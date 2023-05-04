using RecipePlannerDesktopApplication;
using RecipePlannerLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RecipePlannerFinalDemoAdditions
{
    /// <summary>
    ///     The RecipeStepAdd partial class.
    /// </summary>
    public partial class RecipeStepAdd : Form
    {
        private List<RecipeStep> recipeSteps;
        private Recipe recipe;

        /// <summary>
        ///     Initializes the RecipeStepAdd page that sets the recipeSteps list
        ///
        ///     Precondition: none
        ///     Postcondition: getRecipeSteps().Count() == 0
        /// </summary>
        public RecipeStepAdd()
        {
            InitializeComponent();
            recipeSteps = new List<RecipeStep>();
        }

        /// <summary>
        ///     Initializes the RecipeStepAdd page with the specified stepDatas and the recipe
        ///
        ///     Precondition: stepDatas != null && recipe != null
        ///     Postcondition: getRecipeSteps() == stepDatas && getRecipe() == recipe
        /// </summary>
        /// <param name="stepDatas"></param>
        /// <param name="recipe"></param>
        public RecipeStepAdd(List<RecipeStep> stepDatas, Recipe recipe) : this()
        {
            recipeSteps = stepDatas;
            this.recipe = recipe;
        }

        /// <summary>
        ///     Gets the recipe steps
        /// </summary>
        /// <returns>the recipe steps</returns>
        public List<RecipeStep> GetRecipeSteps()
        {
            return this.recipeSteps;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int rowCount = this.stepsDataGridView.Rows.Count;
            int nextStepNumber = rowCount + 1;

            string stepDescription = null;

            if (String.IsNullOrEmpty(this.stepDescriptionTextBox.Text))
            {
                this.errorStepsFieldLabel.Visible = true;
                this.stepsSuccessLabel.Visible = false;
            }
            else
            {
                this.errorStepsFieldLabel.Visible = false;
                
                stepDescription = this.stepDescriptionTextBox.Text;

            }

            if (this.errorStepsFieldLabel.Visible == true)
            {
                return;
            }
            else
            {
                RecipeStep recipeStep = new RecipeStep(nextStepNumber, stepDescription);
                bool isDuplicate = false;
                int rowIndex = -1;
                if (this.recipeSteps != null)
                {
                    foreach (DataGridViewRow row in this.stepsDataGridView.Rows)
                    {
                        string existingStepNumber = row.Cells["stepNumberColumn"].Value.ToString();

                        if (recipeStep.stepNumber.Equals(Convert.ToInt32(existingStepNumber)))
                        {
                            isDuplicate = true;
                            rowIndex = row.Index;
                            break;
                        }
                        else if (recipeStep.stepNumber < Convert.ToInt32(existingStepNumber))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                }

                if (isDuplicate == true)
                {
                    this.errorStepsFieldLabel.Text = "This step already exists.";
                    this.errorStepsFieldLabel.Visible = true;
                    return;
                }
                else
                {
                    this.errorStepsFieldLabel.Visible = false;

                    if (rowIndex == -1 || rowIndex == rowCount)
                    {
                        this.AddRowToStepsGridView(recipeStep.stepNumber.ToString(), recipeStep.stepDescription);
                    }
                    else
                    {
                        this.stepsDataGridView.Rows.Insert(rowIndex, recipeStep.stepNumber.ToString(), recipeStep.stepDescription);
                    }

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
            
            var recipeSummary = new RecipeSummary(this.recipe);

            recipeSummary.SetStepData(recipeSteps);
            this.Hide();

            recipeSummary.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var recipeSummary = new RecipeSummary(this.recipe);
            recipeSummary.SetStepData(recipeSteps);
            
            this.Hide();
            recipeSummary.Show();
        }

        private void stepsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == stepsDataGridView.Columns["removeColumn"].Index && e.RowIndex >= 0)
            {
                this.handleRemoveCurrentRowAndUpdateExistingRows(e);
            }
            if (e.ColumnIndex == stepsDataGridView.Columns["upColumn"].Index && e.RowIndex > 0)
            {
                this.handleUpReorderingStep(e);
            }
            if (e.ColumnIndex == stepsDataGridView.Columns["downColumn"].Index && e.RowIndex < stepsDataGridView.Rows.Count - 1)
            {
                this.handleDownReorderingStep(e);
            }
        }

        private void handleDownReorderingStep(DataGridViewCellEventArgs e)
        {
            int currentIndex = e.RowIndex;
            int newIndex = e.RowIndex + 1;

            DataGridViewRow currentRow = stepsDataGridView.Rows[currentIndex];
            DataGridViewRow newRow = stepsDataGridView.Rows[newIndex];

            string currentStepDescription = currentRow.Cells["stepDescriptionColumn"].Value.ToString();
            string newStepDescription = newRow.Cells["stepDescriptionColumn"].Value.ToString();

            currentRow.Cells["stepDescriptionColumn"].Value = newStepDescription;
            newRow.Cells["stepDescriptionColumn"].Value = currentStepDescription;

            stepsDataGridView.CurrentCell = newRow.Cells[0];
        }

        private void handleUpReorderingStep(DataGridViewCellEventArgs e)
        {
            int currentIndex = e.RowIndex;
            int newIndex = e.RowIndex - 1;

            DataGridViewRow currentRow = stepsDataGridView.Rows[currentIndex];
            DataGridViewRow newRow = stepsDataGridView.Rows[newIndex];

            string currentStepDescription = currentRow.Cells["stepDescriptionColumn"].Value.ToString();
            string newStepDescription = newRow.Cells["stepDescriptionColumn"].Value.ToString();

            currentRow.Cells["stepDescriptionColumn"].Value = newStepDescription;
            newRow.Cells["stepDescriptionColumn"].Value = currentStepDescription;

            stepsDataGridView.CurrentCell = newRow.Cells[0];
        }

        private void handleRemoveCurrentRowAndUpdateExistingRows(DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = stepsDataGridView.Rows[e.RowIndex];

            string stepNumberData;
            string stepDescriptionData;

            stepNumberData = row.Cells["stepNumberColumn"].Value.ToString();
            stepDescriptionData = row.Cells["stepDescriptionColumn"].Value.ToString();

            RecipeStep recipeStep = new RecipeStep(Convert.ToInt32(stepNumberData), stepDescriptionData);

            recipeSteps.Remove(recipeStep);

            stepsDataGridView.Rows.RemoveAt(e.RowIndex);

            for (int i = e.RowIndex; i < stepsDataGridView.Rows.Count; i++)
            {
                DataGridViewRow updatedRow = stepsDataGridView.Rows[i];
                int updatedStepNumber = Convert.ToInt32(updatedRow.Cells["stepNumberColumn"].Value);

                if (updatedStepNumber > Convert.ToInt32(stepNumberData))
                {
                    updatedStepNumber--;
                    updatedRow.Cells["stepNumberColumn"].Value = updatedStepNumber.ToString();
                }
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

        private void stepsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < this.recipeSteps.Count)
            {
                string updatedValue = this.stepsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (e.ColumnIndex == 0)
                {
                    int stepNumber;

                    if (int.TryParse(updatedValue, out stepNumber))
                    {
                        this.recipeSteps[e.RowIndex].stepNumber = stepNumber;
                    }
                }

                else if (e.ColumnIndex == 1)
                {
                    string oldValue = this.recipeSteps[e.RowIndex].stepDescription;

                    if (updatedValue != oldValue)
                    {
                        this.recipeSteps[e.RowIndex].stepDescription = updatedValue;
                    }
                }

            }
        }
    }
}
