using RecipePlannerLibrary.Database;
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
    public partial class Homepage : Form
    {

        public Homepage()
        {
            InitializeComponent();
            this.viewAllRecipes();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage login = new LoginPage();
            login.Show();
        }

        private void viewIngredientsButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            IngredientsPage ingredientsPage = new IngredientsPage();

            ingredientsPage.Show();
        }

        private void viewAllRecipes()
        {

            foreach (var recipe in RecipeDAL.getRecipes())
            {
                this.recipeListView.Items.Add(recipe.Name);
            }
            //RecipeDAL.getRecipes().ForEach(recipe => { recipe.})
        }
    }
}
