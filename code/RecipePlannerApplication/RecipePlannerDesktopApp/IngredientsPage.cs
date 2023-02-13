using MySql.Data.MySqlClient;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using System.ComponentModel;

namespace RecipePlannerDesktopApplication
{
    public partial class IngredientsPage : Form
    {
        private DataGridViewRow selectedRow;
        public IngredientsPage()
        {
            InitializeComponent();

            var bindingList = new BindingList<Ingredient>(IngredientDAL.getIngredients());
            this.ingredientsGridView.DataSource = bindingList;
            this.Refresh();

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage login= new LoginPage();
            login.Show();
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            this.displayAddIngredientsPopup();
            
        }

        private void displayAddIngredientsPopup()
        {

            AddIngredientsPopup ingredientsPopup = new AddIngredientsPopup(this);
            ingredientsPopup.Show();
        }

        private void removeIngredientButton_Click(object sender, EventArgs e)
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

        public void UpdateIngredientsGridView()
        {
            var list = IngredientDAL.getIngredients();
            var bindingList = new BindingList<Ingredient>(list);

            this.ingredientsGridView.DataSource = null;
            this.ingredientsGridView.DataSource = bindingList;
        }

        private void ingredientsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            this.selectedRow = this.ingredientsGridView.Rows[rowIndex];
        }
    }
}
