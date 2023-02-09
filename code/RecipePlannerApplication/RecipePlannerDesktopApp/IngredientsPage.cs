using MySql.Data.MySqlClient;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RecipePlannerDesktopApplication
{
    public partial class IngredientsPage : Form
    {
        public IngredientsPage()
        {
            InitializeComponent();

            var bindingList = new BindingList<Ingredient>(IngredientsPage.GetIngredients);
            var source = new BindingSource(bindingList, null);
            this.ingredientsGridView.DataSource = source;

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage login= new LoginPage();
            login.Show();
        }

        private static IList<Ingredient> GetIngredients()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            List<Ingredient> ingredients = new List<Ingredient>();
            string query = @"Select * from ingredient;";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int quantity = reader.GetInt32(2);
                
                Ingredient ingredient = new Ingredient(id, name, quantity);

                ingredients.Add(ingredient);
            }
            return ingredients;

        }
    }
}
