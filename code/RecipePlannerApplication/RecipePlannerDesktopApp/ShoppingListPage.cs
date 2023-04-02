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
    public partial class ShoppingListPage : Form
    {
        private DataGridViewRow selectedRow;
        private int page = 1;
        private readonly int pageSize = 8;
        private readonly int totalPages;
        private List<Ingredient> pageOneIngredients;

        /// <summary>
        ///     Initializes a ShoppingListPage object.
        /// </summary>
        public ShoppingListPage()
        {
            this.InitializeComponent();
            this.ingredientsGridView.AutoGenerateColumns = false;


            try
            {
                var ingredients = ShoppingListDAL.getIngredients();
                this.totalPages = (int)Math.Ceiling((double)ingredients.Count / this.pageSize);
                this.pageOneIngredients = ingredients
                    .Skip((this.page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                var bindingList = new BindingList<Ingredient>(this.pageOneIngredients);
                this.ingredientsGridView.DataSource = bindingList;

                if (this.ingredientsGridView.Rows.Count == 0)
                {
                    this.purchaseShoppingListButton.Enabled = false;
                } else
                {
                    this.purchaseShoppingListButton.Enabled = true;
                }
                
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
            Hide();
            var login = new LoginPage();
            login.Show();
        }

        private void beginningButton_Click(object sender, EventArgs e)
        {
            this.page = 1;
            var ingredients = ShoppingListDAL.getIngredients();
            List<Ingredient> allIngredientsOnPage = ingredients
                .Skip((this.page - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();

            this.pageLabel.Text = this.page.ToString();
            var list = allIngredientsOnPage;
            var bindingList = new BindingList<Ingredient>(list);

            this.ingredientsGridView.DataSource = bindingList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.page != 1)
            {
                this.page--;
                var ingredients = ShoppingListDAL.getIngredients();
                List<Ingredient> allIngredientsOnPage = ingredients
                    .Skip((this.page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();

                this.pageLabel.Text = this.page.ToString();
                var list = allIngredientsOnPage;
                var bindingList = new BindingList<Ingredient>(list);

                this.ingredientsGridView.DataSource = bindingList;
            }

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (this.page != this.totalPages)
            {
                this.page++;
                var ingredients = ShoppingListDAL.getIngredients();
                List<Ingredient> allIngredientsOnPage = ingredients
                    .Skip((this.page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();

                this.pageLabel.Text = this.page.ToString();
                var list = allIngredientsOnPage;
                var bindingList = new BindingList<Ingredient>(list);

                this.ingredientsGridView.DataSource = bindingList;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.page = this.totalPages;
            var ingredients = ShoppingListDAL.getIngredients();
            List<Ingredient> allIngredientsOnPage = ingredients
                .Skip((this.page - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();

            this.pageLabel.Text = this.page.ToString();
            var list = allIngredientsOnPage;
            var bindingList = new BindingList<Ingredient>(list);

            this.ingredientsGridView.DataSource = bindingList;

        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {

        }

        private void removeIngredientButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.selectedRow != null)
                {
                    var id = 0;
                    var name = this.selectedRow.Cells[0].Value;
                    var quantity = (int)this.selectedRow.Cells[2].Value;
                    var list = IngredientDAL.getIngredients();
                    foreach (var item in list)
                    {
                        if (item.name.Equals(name) && item.quantity == quantity)
                        {
                            id = (int)item.id;
                        }
                    }

                    ShoppingListDAL.RemoveIngredient(id, Connection.ConnectionString);
                    this.UpdateIngredientsGridView();
                }
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
            }
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

        private void purchaseShoppingListButton_Click(object sender, EventArgs e)
        {
            this.submitShoppingList();

            var ingredientsPage = new IngredientsPage();
            this.Hide();
            ingredientsPage.Show();
        }

        private void submitShoppingList()
        {
            int updatedQuantity = 0;
            foreach (var shoppingIngredient in ShoppingListDAL.getIngredients())
            {
                bool shoppingIngredientExists = false;
                foreach (var ingredient in IngredientDAL.getIngredients())
                {
                    if (ingredient.id == shoppingIngredient.id)
                    {
                        updatedQuantity = (int)(ingredient.quantity + shoppingIngredient.quantity);
                        IngredientDAL.updateQuantity((int)ingredient.id, updatedQuantity);
                        shoppingIngredientExists = true;
                    }
                }
                if (!shoppingIngredientExists)
                {
                    IngredientDAL.addIngredient(shoppingIngredient.name, (int)shoppingIngredient.quantity, shoppingIngredient.measurement, Connection.ConnectionString);
                }
                ShoppingListDAL.RemoveIngredient((int)shoppingIngredient.id, Connection.ConnectionString);
            }
        }

        private void clickIngredientCell(int columnIndex)
        {
            try
            {
                if (this.selectedRow != null)
                {
                    var id = 0;
                    var name = this.selectedRow.Cells[0].Value;
                    var quantity = (int)this.selectedRow.Cells[2].Value;
                    var list = ShoppingListDAL.getIngredients();
                    foreach (var item in list)
                    {
                        if (item.name.Equals(name) && item.quantity == quantity)
                        {
                            id = (int)item.id;
                        }
                    }

                    if (columnIndex == 3)
                    {
                        ShoppingListDAL.incrementQuantity(id, quantity);
                        this.UpdateIngredientsGridView();
                    }

                    if (columnIndex == 1)
                    {
                        ShoppingListDAL.decrementQuantity(id, quantity);
                        this.UpdateIngredientsGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
                this.ingredientsGridView.Enabled = false;
            }
        }

        /// <summary>
        ///     Updates the ingredients view with the page one ingredients.
        /// </summary>
        public void UpdateIngredientsGridView()
        {
            try
            {
                var ingredients = ShoppingListDAL.getIngredients();
                this.pageOneIngredients = ingredients
                    .Skip((this.page - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                var list = this.pageOneIngredients;
                var bindingList = new BindingList<Ingredient>(list);

                this.ingredientsGridView.DataSource = null;
                this.ingredientsGridView.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;
            if (rowIndex >= 0)
            {
                this.selectedRow = this.ingredientsGridView.Rows[rowIndex];
                this.clickIngredientCell(columnIndex);
            }
        }
    }
}
