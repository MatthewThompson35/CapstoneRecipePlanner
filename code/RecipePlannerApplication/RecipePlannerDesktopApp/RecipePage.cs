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
        
        /// <summary>
        ///     Initializes a new Recipe Page.
        /// </summary>
        public RecipePage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Initializes a Recipe Page based on the specified recipe requirements page.
        /// </summary>
        /// <param name="page">the recipe requirements page</param>
        public RecipePage(RecipeRequirementsPage page) :this()
        {
            page = new RecipeRequirementsPage();

            this.recipeIngredientsDataGridView.DataSource = page.GetRecipeIngredients();
            this.stepsDataGridView.DataSource = page.GetRecipeSteps();
            this.tagDataGridView.DataSource = page.GetTags();
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

        /// <summary>
        ///     Adds a row to the ingredients grid view based on the ingredient name, quantity, measurement.
        /// </summary>
        /// <param name="ingredientName">the ingredient name</param>
        /// <param name="quantity">the quantity</param>
        /// <param name="measurement">the measurement</param>
        public void AddRowToIngredientGridView(string ingredientName, string quantity, string measurement)
        {
            this.recipeIngredientsDataGridView.Rows.Add(ingredientName, quantity, measurement);
        }

        /// <summary>
        ///     Adds a row to the tag grid view based on the tag name.
        /// </summary>
        /// <param name="tagName">the tag name</param>
        public void AddRowToTagGridView(string tagName)
        {
            this.tagDataGridView.Rows.Add(tagName);
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
            var recipeRequirement = new RecipeRequirementsPage(this);

            this.Hide();

            recipeRequirement.Show();
        }
    }
}
