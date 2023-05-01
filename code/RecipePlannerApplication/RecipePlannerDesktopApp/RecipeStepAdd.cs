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
    public partial class RecipeStepAdd : Form
    {
        private List<RecipeStep> recipeSteps;
        private Recipe recipe;

        public RecipeStepAdd()
        {
            InitializeComponent();
            recipeSteps = new List<RecipeStep>();
        }

        public RecipeStepAdd(List<RecipeStep> stepDatas, Recipe recipe) : this()
        {
            recipeSteps = stepDatas;
            this.recipe = recipe;
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
                    this.errorStepNumberLabel.Text = "Step number is not a number";
                    this.errorStepNumberLabel.Visible = true;
                }
                else if (isNumeric && number <= 0)
                {
                    this.errorStepNumberLabel.Text = "Step number must be greater than 0";
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

            //this.stepsDataGridView.Sort(this.stepsDataGridView.Columns["stepNumberColumn"], ListSortDirection.Ascending);
            
        }

        private class StepNumberComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                int a, b;
                if (int.TryParse(x.ToString(), out a) && int.TryParse(y.ToString(), out b))
                {
                    if (a < 10 && b < 10)
                    {
                        // Both numbers are less than 10, compare them normally
                        return a.CompareTo(b);
                    }
                    else if (a >= 10 && b >= 10)
                    {
                        // Both numbers are greater than or equal to 10, compare them normally
                        return a.CompareTo(b);
                    }
                    else if (a < 10 && b >= 10)
                    {
                        // a is less than 10, so it comes before any number greater than or equal to 10
                        return -1;
                    }
                    else
                    {
                        // b is less than 10, so it comes before any number greater than or equal to 10
                        return 1;
                    }
                }
                return String.Compare(x.ToString(), y.ToString());
            }
        }

        private void SortByStepNumberAscending()
        {
            // Retrieve the data source and cast it to the appropriate type
            var dataSource = (List<RecipeStep>)stepsDataGridView.DataSource;

            // Sort the data source by the StepNumber property in ascending order
            dataSource = dataSource.OrderBy(x => x.stepNumber).ToList();

            // Set the sorted data source as the new data source for the DataGridView
            stepsDataGridView.DataSource = dataSource;

            // Refresh the DataGridView to display the sorted data
            stepsDataGridView.Refresh();
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
            //stepsDataGridView.Columns["stepNumberColumn"].ValueType = typeof(int);
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
