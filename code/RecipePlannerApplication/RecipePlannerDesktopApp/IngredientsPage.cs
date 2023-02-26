using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using System.ComponentModel;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    /// Ingredients Page partial class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class IngredientsPage : Form
    {
        private DataGridViewRow selectedRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsPage"/> class.
        /// </summary>
        public IngredientsPage()
        {
            InitializeComponent();

            try
            {
                var bindingList = new BindingList<Ingredient>(IngredientDAL.getIngredients());
                this.ingredientsGridView.DataSource = bindingList;
                this.Refresh();
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
                this.ingredientsGridView.Enabled = false;
            }
            this.Refresh();

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage login = new LoginPage();
            login.Show();
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            this.displayAddIngredientsPage();

        }

        private void displayAddIngredientsPage()
        {
            this.Hide();
            AddIngredientsPage ingredientsPopup = new AddIngredientsPage(this);
            ingredientsPopup.Show();
        }

        private void removeIngredientButton_Click(object sender, EventArgs e)
        {
            this.removeSelectedIngredient();
        }

        private void removeSelectedIngredient()
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
                        if (item.name.Equals(name) && item.quantity == (quantity))
                        {
                            id = (int)item.id;
                        }
                    }

                    IngredientDAL.RemoveIngredient(id);
                    this.UpdateIngredientsGridView();
                }
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
            }
            
        }

        /// <summary>
        /// Updates the ingredients view.
        /// </summary>
        public void UpdateIngredientsGridView()
        {
            try
            {
                var list = IngredientDAL.getIngredients();
                var bindingList = new BindingList<Ingredient>(list);

                this.ingredientsGridView.DataSource = null;
                this.ingredientsGridView.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
            }
            
        }

        private void ingredientsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            this.selectedRow = this.ingredientsGridView.Rows[rowIndex];

            this.clickIngredientCell(columnIndex);
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
                    var list = IngredientDAL.getIngredients();
                    foreach (var item in list)
                    {
                        if (item.name.Equals(name) && item.quantity == (quantity))
                        {
                            id = (int)item.id;
                        }
                    }

                    if (columnIndex == 1)
                    {
                        IngredientDAL.decrementQuantity(id, quantity);
                        this.UpdateIngredientsGridView();
                    }

                    if (columnIndex == 3)
                    {
                        IngredientDAL.incrementQuantity(id, quantity);
                        this.UpdateIngredientsGridView();
                    }
                }
            } catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
                this.ingredientsGridView.Enabled = false;
            }
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            Homepage homepage = new Homepage();
            homepage.Show();
        }
    }
}
