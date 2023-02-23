using MySql.Data.MySqlClient;
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
    public partial class Homepage : Form
    {
        public Recipe currentRecipe { get; set; }
        public List<Recipe> recipes { get; set; }

        public Homepage()
        {
            InitializeComponent();
            this.recipes = new List<Recipe>();
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
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            string query = @"Select * from recipe;";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            using var sda = new MySqlDataAdapter(query, connection);
            while (reader.Read())
            {
                int recipeID = reader.GetInt32(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);

                Recipe recipe = new Recipe(recipeID, name, description);

                recipes.Add(recipe);
            }
            connection.Close();
            DataTable dt = new DataTable();

            sda.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["name"].ToString());
                item.SubItems.Add(row["recipeID"].ToString());
                this.recipeListView.Items.Add(item);
            }
            this.recipeListView.View = View.List;
        }

        private void recipeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.recipeListView.SelectedItems.Count > 0)
            {
                //this.currentRecipe = (Recipe) this.recipeListView.SelectedItems[0].Tag;
                //int recipeId = Convert.ToInt32(this.recipeListView.SelectedItems[0].SubItems[1].Text);
                //string name = this.recipeListView.SelectedItems[0].Text;
                //string description = this.recipeListView.SelectedItems[0].SubItems[2].Text;

                //Recipe recipe = new Recipe(recipeId, name, description);

                //string message = "Name: " + this.recipeListView.SelectedItems[0].Text + Environment.NewLine;
                //message += "ID: " + this.recipeListView.SelectedItems[0].SubItems[1].Text;
                //MessageBox.Show(message);

                this.Hide();

                RecipeDetailsPage detailsPage = new RecipeDetailsPage();
                detailsPage.Show();
                
            }
        }
    }
}
