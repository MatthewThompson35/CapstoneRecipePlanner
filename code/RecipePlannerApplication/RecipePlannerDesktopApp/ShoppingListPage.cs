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
    public partial class ShoppingListPage : Form
    {
        private DataGridViewRow selectedRow;
        private int page = 1;
        private readonly int pageSize = 8;
        private readonly int totalPages;
        private List<Ingredient> pageOneIngredients;

        public ShoppingListPage()
        {
            this.InitializeComponent();

            try
            {
                var ingredients = IngredientDAL.GetIngredientsFromShoppingList();
                this.totalPages = (int)Math.Ceiling((double)ingredients.Count / this.pageSize);
                this.pageOneIngredients = ingredients
                    .Skip((this.page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                var bindingList = new BindingList<Ingredient>(this.pageOneIngredients);
                this.ingredientsGridView.DataSource = bindingList;
                
                Refresh();
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
                this.ingredientsGridView.Enabled = false;
            }

            Refresh();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {

        }

        private void beginningButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {

        }

        private void removeIngredientButton_Click(object sender, EventArgs e)
        {

        }

        private void plannerMenuButton_Click(object sender, EventArgs e)
        {
            this.plannerContextMenuStrip.Show(this.plannerMenuButton, 0, this.plannerMenuButton.Height);

        }

        private void showRecipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();

            var recipesPage = new Homepage();

            recipesPage.Show();
        }

        private void showPantryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();

            var ingredientPage = new IngredientsPage();

            ingredientPage.Show();

        }
    }
}
