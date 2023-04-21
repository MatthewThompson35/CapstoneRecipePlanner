using RecipePlannerDesktopApplication;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipePlannerFinalDemoAdditions
{
    public partial class RecipeIngredientAdd : Form
    {
        private List<RecipeIngredient> recipeIngredients;
        public RecipeIngredientAdd()
        {
            InitializeComponent();
            recipeIngredients = new List<RecipeIngredient>();
        }

        public RecipeIngredientAdd(List<RecipeIngredient> ingredientDatas) :this()
        {
            recipeIngredients = ingredientDatas;
        }
        /// <summary>
        ///     Gets the recipe ingredients
        /// </summary>
        /// <returns>the recipe ingredients</returns>
        public List<RecipeIngredient> GetRecipeIngredients()
        {
            return this.recipeIngredients;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string ingredientName = null;
            string quantity = null;
            string measurement = null;

            int number;

            if (String.IsNullOrEmpty(this.ingredientNameTextBox.Text) || String.IsNullOrEmpty(this.quantityTextBox.Text) || this.measurementComboBox.SelectedItem == null)
            {
                this.errorIngredientsFieldsLabel.Visible = true;
            }
            else
            {
                this.errorIngredientsFieldsLabel.Visible = false;
                ingredientName = this.ingredientNameTextBox.Text;
                measurement = this.measurementComboBox.Text;
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


            if (this.errorIngredientsFieldsLabel.Visible == true || this.errorQuantityLabel.Visible == true)
            {
                return;
            }
            else
            {
                RecipeIngredient recipeIngredient = new RecipeIngredient(ingredientName, Convert.ToInt32(quantity), measurement);
                bool isDuplicate = false;
                if (this.recipeIngredients != null)
                {
                    foreach (DataGridViewRow row in this.ingredientDataGridView.Rows)
                    {
                        string existingIngredient = row.Cells["ingredientNameColumn"].Value.ToString();
                        
                        if (recipeIngredient.IngredientName.Equals(existingIngredient))
                        {
                            this.errorIngredientsFieldsLabel.Text = "Ingredient already exists.";
                            this.errorIngredientsFieldsLabel.Visible = true;
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
                    this.errorIngredientsFieldsLabel.Visible = false;
                    

                    this.AddRowToIngredientGridView(recipeIngredient.IngredientName, recipeIngredient.Quantity.ToString(), recipeIngredient.Measurement);
                    this.ingredientSuccessLabel.Visible = true;

                    this.clearIngredientsFields();
                }
            }
        }

        private void clearIngredientsFields()
        {
            this.ingredientNameTextBox.Clear();
            this.quantityTextBox.Clear();
            this.measurementComboBox.SelectedItem = null;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.ingredientDataGridView.Rows)
            {
                string nameData;
                string quantityData;
                string measurementData;

                nameData = row.Cells["ingredientNameColumn"].Value.ToString();
                quantityData = row.Cells["quantityColumn"].Value.ToString();
                measurementData = row.Cells["measurementColumn"].Value.ToString();
                
                // Remember to do checks for if the table is modified, check if quantity is an int. If no, throw label error
                RecipeIngredient recipeIngredient = new RecipeIngredient(nameData, Convert.ToInt32(quantityData), measurementData);
                
                if (recipeIngredients.Any(ri => ri.Equals(recipeIngredient)))
                {
                    continue;
                }
                else
                {
                    recipeIngredients.Add(recipeIngredient);
                }
            }
            var recipeSummary = new RecipeSummary();

            recipeSummary.SetIngredientData(recipeIngredients);
            this.Hide();

            recipeSummary.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }

        /// <summary>
        ///     Adds a row to the ingredients grid view based on the ingredient name, quantity, measurement.
        /// </summary>
        /// <param name="ingredientName">the ingredient name</param>
        /// <param name="quantity">the quantity</param>
        /// <param name="measurement">the measurement</param>
        public void AddRowToIngredientGridView(string ingredientName, string quantity, string measurement)
        {
            this.ingredientDataGridView.Rows.Add(ingredientName, quantity, measurement);
        }

        private void ingredientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ingredientDataGridView.Columns["removeColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = ingredientDataGridView.Rows[e.RowIndex];

                string nameData;
                string quantityData;
                string measurementData;

                nameData = row.Cells["ingredientNameColumn"].Value.ToString();
                quantityData = row.Cells["quantityColumn"].Value.ToString();
                measurementData = row.Cells["measurementColumn"].Value.ToString();

                RecipeIngredient recipeIngredient = new RecipeIngredient(nameData, Convert.ToInt32(quantityData), measurementData);

                recipeIngredients.Remove(recipeIngredient);

                ingredientDataGridView.Rows.RemoveAt(e.RowIndex);
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

        private void measurementComboBox_Click(object sender, EventArgs e)
        {
            this.ingredientSuccessLabel.Visible = false;
        }

        private void RecipeIngredientAdd_Load(object sender, EventArgs e)
        {
            if (recipeIngredients != null)
            {
                foreach (var recipeIngredient in this.recipeIngredients)
                {
                    int rowIndex = this.ingredientDataGridView.Rows.Add();
                    ingredientDataGridView.Rows[rowIndex].Cells["ingredientNameColumn"].Value = recipeIngredient.IngredientName;
                    ingredientDataGridView.Rows[rowIndex].Cells["quantityColumn"].Value = recipeIngredient.Quantity;
                    ingredientDataGridView.Rows[rowIndex].Cells["measurementColumn"].Value = recipeIngredient.Measurement;
                }
            }
        }

        private void ingredientDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < this.recipeIngredients.Count)
            {
                string updatedValue = this.ingredientDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (e.ColumnIndex == 0)
                {
                    string oldIngName = this.recipeIngredients[e.RowIndex].IngredientName;

                    if (updatedValue != oldIngName)
                    {
                        this.recipeIngredients[e.RowIndex].IngredientName = updatedValue;
                    }
                }

                else if (e.ColumnIndex == 1)
                {
                    int quantity;

                    if (int.TryParse(updatedValue, out quantity))
                    {
                        this.recipeIngredients[e.RowIndex].Quantity = quantity;
                    }
                }

                else if (e.ColumnIndex == 2)
                {
                    string oldMeasurement = this.recipeIngredients[e.RowIndex].Measurement;

                    if (updatedValue != oldMeasurement)
                    {
                        this.recipeIngredients[e.RowIndex].Measurement = updatedValue;
                    }
                }
            }
        }
    }
}
