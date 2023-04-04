using Org.BouncyCastle.Crypto.Tls;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipePlannerDesktopApplication
{
    public partial class RecipePage : Form
    {
        private RecipeRequirementsPage requirementsPage;
        /// <summary>
        ///     Initializes a new Recipe Page.
        /// </summary>
        public RecipePage()
        {
            InitializeComponent();

            this.errorLabel.Visible = false;
            this.requirementsPage = new RecipeRequirementsPage();
        }

        /// <summary>
        ///     Initializes a Recipe Page based on the specified recipe requirements page.
        /// </summary>
        /// <param name="page">the recipe requirements page</param>
        public RecipePage(RecipeRequirementsPage page) :this()
        {
            requirementsPage = page;

            this.recipeIngredientsDataGridView.DataSource = requirementsPage.GetRecipeIngredients();
            this.stepsDataGridView.DataSource = requirementsPage.GetRecipeSteps();
            this.tagDataGridView.DataSource = requirementsPage.GetTags();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.addRecipe();

            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
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
            string recipeName = null;
            string recipeDescription = null;
            if (String.IsNullOrEmpty(this.recipeNameTextBox.Text))
            {
                this.errorLabel.Visible = true;
            }
            else
            {
                this.errorLabel.Visible = false;
                recipeName = this.recipeNameTextBox.Text;
            }
            
            if (String.IsNullOrEmpty(this.recipeDescriptionTextBox.Text))
            {
                this.errorLabel.Visible = true;
            }
            else
            {
                this.errorLabel.Visible = false;
                recipeDescription = this.recipeDescriptionTextBox.Text;
            }
            
            Recipe recipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

            if (recipe.Name == null)
            {
                this.errorLabel.Visible = false;
                RecipeDAL.addRecipe(recipeName, recipeDescription, Connection.ConnectionString);

                foreach (DataGridViewRow row in this.tagDataGridView.Rows)
                {
                    if (row.Cells["tagColumn"].Value == null)
                    {
                        break;
                    }
                    else
                    {
                        string tag = row.Cells["tagColumn"].Value.ToString();
                        this.requirementsPage.GetTags().Add(tag);
                    }

                }

                foreach (string tag in this.requirementsPage.GetTags())
                {
                    RecipeDAL.addRecipeTag(RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId, tag, Connection.ConnectionString);
                }

                foreach (DataGridViewRow row in this.stepsDataGridView.Rows)
                {
                    if (row.Cells["step"].Value == null && row.Cells["stepDescription"].Value == null)
                    {
                        break;
                    }
                    else
                    {
                        string stepNumber = row.Cells["step"].Value.ToString();
                        string stepDescription = row.Cells["stepDescription"].Value.ToString();

                        RecipeStep recipeStep = new RecipeStep(Convert.ToInt32(stepNumber), stepDescription);
                        this.requirementsPage.GetRecipeSteps().Add(recipeStep);
                    }

                }

                foreach (var step in this.requirementsPage.GetRecipeSteps())
                {
                    RecipeDAL.addRecipeStep(RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId, step.stepNumber, step.stepDescription, Connection.ConnectionString);
                }

                foreach (DataGridViewRow row in this.recipeIngredientsDataGridView.Rows)
                {
                    if (row.Cells["ingredientName"].Value == null && row.Cells["quantity"].Value == null && row.Cells["measurement"].Value == null)
                    {
                        break;
                    }
                    else
                    {
                        string ingredientName = row.Cells["ingredientName"].Value.ToString();
                        string quantity = row.Cells["quantity"].Value.ToString();
                        string measurement = row.Cells["measurement"].Value.ToString();

                        RecipeIngredient recipeIngredient = new RecipeIngredient(ingredientName, Convert.ToInt32(quantity), measurement);

                        this.requirementsPage.GetRecipeIngredients().Add(recipeIngredient);
                    }
                }

                foreach (var ingredient in this.requirementsPage.GetRecipeIngredients())
                {
                    RecipeDAL.addRecipeIngredient(RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId, ingredient.IngredientName, IngredientDAL.getIngredientId(ingredient.IngredientName), ingredient.Quantity, ingredient.Measurement, Connection.ConnectionString);
                }
            }
            else
            {
                this.errorLabel.Text = "This recipe already exists.";
                this.errorLabel.Visible = true;
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
