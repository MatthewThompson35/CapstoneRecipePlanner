using Org.BouncyCastle.Crypto.Tls;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
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
    public partial class RecipePage : Form
    {
        public List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
        public RecipePage()
        {
            InitializeComponent();

            //recipeIngredients = new List<RecipeIngredient>();

            
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }

        private void tagDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tagDataGridView.Columns["tagRemove"].Index && e.RowIndex >= 0)
            {
                tagDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void stepsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == stepsDataGridView.Columns["stepsRemove"].Index && e.RowIndex >= 0)
            {
                stepsDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void recipeIngredientsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == recipeIngredientsDataGridView.Columns["ingredientsRemove"].Index && e.RowIndex >= 0)
            {
                recipeIngredientsDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }

        public void AddRowToIngredientGridView(string ingredientName, string quantity, string measurement)
        {
            this.recipeIngredientsDataGridView.Rows.Add(ingredientName, quantity, measurement);
        }

        private void addRecipe()
        {
            string recipeName = this.recipeNameTextBox.Text;
            string recipeDescription = this.recipeDescriptionTextBox.Text;

            Recipe recipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

            if (recipe == null)
            {

            }
        }

        private void addRecipeRequirementsButton_Click(object sender, EventArgs e)
        {
            var recipeRequirement = new RecipeRequirementsPage();

            this.Hide();

            recipeRequirement.Show();
        }
    }
}
