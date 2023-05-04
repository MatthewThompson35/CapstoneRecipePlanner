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
    /// <summary>
    /// The class for the shopping list page
    ///
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
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
                var ingredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);
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
            var ingredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);
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
                var ingredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);
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
                var ingredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);
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
            var ingredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);
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
            Hide();

            var addIngredient = new AddIngredientsPage(this);

            addIngredient.Show();

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
            foreach (var shoppingIngredient in ShoppingListDAL.getIngredients(Connection.ConnectionString))
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
                    var list = ShoppingListDAL.getIngredients(Connection.ConnectionString);
                    foreach (var item in list)
                    {
                        if (item.name.Equals(name) && item.quantity == quantity)
                        {
                            id = (int)item.id;
                        }
                    }

                    if (columnIndex == 3)
                    {
                        ShoppingListDAL.incrementQuantity(id, quantity, Connection.ConnectionString);
                        this.UpdateIngredientsGridView();
                    }

                    if (columnIndex == 1)
                    {
                        ShoppingListDAL.decrementQuantity(id, quantity, Connection.ConnectionString);
                        quantity--;
                        if (quantity == 0)
                        {
                            ShoppingListDAL.RemoveIngredient(id, Connection.ConnectionString);
                        }
                        this.UpdateIngredientsGridView();
                    }

                    if (columnIndex == 5)
                    {
                        ShoppingListDAL.RemoveIngredient(id, Connection.ConnectionString);
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
        ///     Updates the shopping list view with the page one shopping list ingredients.
        /// </summary>
        public void UpdateIngredientsGridView()
        {
            try
            {
                var ingredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);
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

        private void ingredientsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;
            if (rowIndex >= 0)
            {
                this.selectedRow = this.ingredientsGridView.Rows[rowIndex];
                this.clickIngredientCell(columnIndex);
            }
        }

        private void ingredientsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;
            if (rowIndex >= 0)
            {
                this.selectedRow = this.ingredientsGridView.Rows[rowIndex];
            }
        }

        private void addIngredientsForRemainingMealsButton_Click(object sender, EventArgs e)
        {
            
            if (this.addAllIngredientsCheckbox.Checked == true)
            {
                this.addAllIngredients();
            }
            else
            {
                this.addNeededIngredients();
            }

            var shoppingList = new ShoppingListPage();

            this.Hide();
            shoppingList.Show();
        }

        private void addAllIngredients()
        {
            try
            {
                List<Ingredient> totalIngredients = new List<Ingredient>();
                List<int> remainingMeals = PlannedMealDal.getRemainingMeals(Connection.ConnectionString);
                List<Ingredient> pantry = IngredientDAL.getIngredients();
                List<Ingredient> shoppingIngredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);

                foreach (var shoppingIngredient in shoppingIngredients)
                {
                    Ingredient pantryItem = pantry.Find(i => i.name == shoppingIngredient.name);

                    if (pantryItem != null)
                    {
                        pantryItem.quantity += shoppingIngredient.quantity;
                    }
                    else
                    {
                        pantry.Add(shoppingIngredient);
                    }
                }

                foreach (var recipeId in remainingMeals)
                {
                    var recipeIngredients = RecipeDAL.getIngredientsForRecipe(recipeId, Connection.ConnectionString);

                    foreach (var recipeIngredient in recipeIngredients)
                    {
                        Ingredient existingIngredient = totalIngredients.Find(i => i.name == recipeIngredient.IngredientName && i.measurement == recipeIngredient.Measurement);

                        if (existingIngredient != null)
                        {
                            existingIngredient.quantity += (int)recipeIngredient.Quantity;
                        }
                        else
                        {
                            int ingredientId = IngredientDAL.getIngredientId(recipeIngredient.IngredientName);
                            Ingredient newIngredient = new Ingredient(ActiveUser.username, recipeIngredient.IngredientName, recipeIngredient.Quantity, ingredientId, recipeIngredient.Measurement);

                            totalIngredients.Add(newIngredient);
                        }
                    }
                }

                foreach (var ingredient in totalIngredients)
                {
                    Ingredient shoppingListItem = shoppingIngredients.Find(i => i.name == ingredient.name);

                    if (shoppingListItem != null)
                    {
                        int quantity = (int)shoppingListItem.quantity + (int)ingredient.quantity;

                        ShoppingListDAL.updateQuantity((int)ingredient.id, quantity, Connection.ConnectionString);
                    }
                    else
                    {
                        ShoppingListDAL.addIngredient(ingredient.name, (int)ingredient.quantity, ingredient.measurement, Connection.ConnectionString);
                    }
                }
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
            }
            
        }

        private void addNeededIngredients()
        {
            try
            {
                string user = ActiveUser.username;
                List<Ingredient> totalIngredients = new List<Ingredient>();
                List<int> remainingMeals =
                    PlannedMealDal.getRemainingMeals(Connection.ConnectionString);
                List<Ingredient> pantry = IngredientDAL.getIngredients();
                List<Ingredient> shoppingIngredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);

                foreach (Ingredient shoppingItem in shoppingIngredients)
                {
                    Ingredient pantryItem = pantry.Find(i => i.name == shoppingItem.name);

                    if (pantryItem != null)
                    {
                        pantryItem.quantity += shoppingItem.quantity;
                    }
                    else
                    {
                        pantry.Add(shoppingItem);
                    }
                }

                foreach (var recipeId in remainingMeals)
                {
                    var recipeIngredients = RecipeDAL.getIngredientsForRecipe(recipeId, Connection.ConnectionString);

                    foreach (RecipeIngredient recipeIngredient in recipeIngredients)
                    {
                        Ingredient existingIngredient = totalIngredients.Find(i =>
                            i.name == recipeIngredient.IngredientName && i.measurement == recipeIngredient.Measurement);

                        if (existingIngredient != null)
                        {
                            existingIngredient.quantity += (int)recipeIngredient.Quantity;

                        }
                        else
                        {
                            int ingredientId = IngredientDAL.getIngredientId(recipeIngredient.IngredientName);
                            Ingredient newIngredient = new Ingredient(user, recipeIngredient.IngredientName, recipeIngredient.Quantity, ingredientId,
                                recipeIngredient.Measurement);
                            totalIngredients.Add(newIngredient);
                        }
                    }
                }


                foreach (var ingredient in totalIngredients)
                {
                    Ingredient pantryItem = pantry.Find(i => i.name == ingredient.name);

                    if (pantryItem != null)
                    {
                        if (ingredient.quantity > pantryItem.quantity)
                        {
                            int quantity = (int)ingredient.quantity - (int)pantryItem.quantity;
                            Ingredient shoppingListItem = shoppingIngredients.Find(i => i.name == ingredient.name);

                            if (shoppingListItem != null)
                            {
                                ShoppingListDAL.updateQuantity((int)ingredient.id, quantity, Connection.ConnectionString);
                            }
                            else
                            {
                                ShoppingListDAL.addIngredient(ingredient.name, quantity, ingredient.measurement, Connection.ConnectionString);
                            }

                        }
                    }
                    else
                    {
                        ShoppingListDAL.addIngredient(ingredient.name, (int)ingredient.quantity, ingredient.measurement, Connection.ConnectionString);
                    }
                }
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
            }
            
        }
    }
}
