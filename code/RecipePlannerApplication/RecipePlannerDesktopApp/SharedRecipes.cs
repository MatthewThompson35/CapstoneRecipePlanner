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
using RecipePlannerLibrary;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    /// The class for the shared Recipes
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SharedRecipes : Form
    {
        private Recipe selectedRecipe;
        private int page = 1;
        private readonly int pageSize = 8;
        private readonly int totalPages;
        private List<SharedRecipe> pageOneRecipes;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharedRecipes"/> class.
        /// </summary>
        public SharedRecipes()
        {
            InitializeComponent();
            this.ingredientsGridView.AutoGenerateColumns = false;


            try
            {
                var recipes = RecipeDAL.getSharedRecipes(Connection.ConnectionString);
                this.totalPages = (int)Math.Ceiling((double)recipes.Count / this.pageSize);
                this.pageOneRecipes = recipes
                    .Skip((this.page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                var bindingList = new BindingList<SharedRecipe>(this.pageOneRecipes);
                this.ingredientsGridView.DataSource = bindingList;

                Refresh();
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
                this.ingredientsGridView.Enabled = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.page = this.totalPages;
            var recipes = RecipeDAL.getSharedRecipes(Connection.ConnectionString);
            List<SharedRecipe> allIngredientsOnPage = recipes
                .Skip((this.page - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();

            this.pageLabel.Text = this.page.ToString();
            var list = allIngredientsOnPage;
            var bindingList = new BindingList<SharedRecipe>(list);

            this.ingredientsGridView.DataSource = bindingList;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (this.page != this.totalPages)
            {
                this.page++;
                var recipes = RecipeDAL.getSharedRecipes(Connection.ConnectionString);
                List<SharedRecipe> allIngredientsOnPage = recipes
                    .Skip((this.page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();

                this.pageLabel.Text = this.page.ToString();
                var list = allIngredientsOnPage;
                var bindingList = new BindingList<SharedRecipe>(list);

                this.ingredientsGridView.DataSource = bindingList;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.page != 1)
            {
                this.page--;
                var recipes = RecipeDAL.getSharedRecipes(Connection.ConnectionString);
                List<SharedRecipe> allIngredientsOnPage = recipes
                    .Skip((this.page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();

                this.pageLabel.Text = this.page.ToString();
                var list = allIngredientsOnPage;
                var bindingList = new BindingList<SharedRecipe>(list);

                this.ingredientsGridView.DataSource = bindingList;

            }
        }

        private void beginningButton_Click(object sender, EventArgs e)
        {
            this.page = 1;
            var recipes = RecipeDAL.getSharedRecipes(Connection.ConnectionString);
            List<SharedRecipe> allIngredientsOnPage = recipes
                .Skip((this.page - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();

            this.pageLabel.Text = this.page.ToString();
            var list = allIngredientsOnPage;
            var bindingList = new BindingList<SharedRecipe>(list);

            this.ingredientsGridView.DataSource = bindingList;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            var page = new LoginPage();
            this.Hide();
            page.Show();
        }

        private void ingredientsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;
            if (rowIndex >= 0 && columnIndex == 0)
            {
                DataGridViewRow row = this.ingredientsGridView.Rows[rowIndex];
                string name = row.Cells[0].Value.ToString();
                this.selectedRecipe = RecipeDAL.getRecipeByName(name, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }

        }

        /// <summary>
        /// Gets the recipe.
        /// </summary>
        /// <returns>The selected recipe</returns>
        public Recipe getRecipe()
        {
            return this.selectedRecipe;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }
    }
}
