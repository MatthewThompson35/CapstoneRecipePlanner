using MySql.Data.MySqlClient;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using System.ComponentModel;

namespace RecipePlannerDesktopApplication
{
    public partial class IngredientsPage : Form
    {
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

            AddIngredientsPopup ingredientsPopup = new AddIngredientsPopup();
            ingredientsPopup.Show();
        }

        private void removeIngredientButton_Click(object sender, EventArgs e)
        {
            // TODO: implement remove ingredient button
        }
    }
}
