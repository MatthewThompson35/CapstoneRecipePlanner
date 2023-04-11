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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipePlannerFinalDemoAdditions
{
    public partial class RecipeIngredientAdd : Form
    {
        private List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
        public RecipeIngredientAdd()
        {
            InitializeComponent();
            recipeIngredients = new List<RecipeIngredient>();
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

            if (String.IsNullOrEmpty(this.ingredientNameTextBox.Text) || this.measurementComboBox.SelectedItem == null)
            {
                this.errorIngredientsFieldsLabel.Visible = true;
            }
            else
            {
                this.errorIngredientsFieldsLabel.Visible = false;
                ingredientName = this.ingredientNameTextBox.Text;
                measurement = this.measurementComboBox.Text;
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

                    this.AddRowToIngredientGridView(recipeIngredient.IngredientName, recipeIngredient.Quantity.ToString(), recipeIngredient.Measurement);

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
    }
}
