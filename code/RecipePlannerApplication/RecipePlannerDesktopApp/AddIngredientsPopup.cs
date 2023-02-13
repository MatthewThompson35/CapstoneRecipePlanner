using MySql.Data.MySqlClient;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    /// Add ingredients page
    /// </summary>
    public partial class AddIngredientsPopup : Form
    {
        private IngredientsPage ingredientsPage;

        /// <summary>
        /// Constructor for add ingredients
        /// </summary>
        /// <param name="ingredientsPage"></param>
        public AddIngredientsPopup(IngredientsPage ingredientsPage)
        {
            InitializeComponent();
            this.ingredientsPage = ingredientsPage;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string name = this.ingredientNameTextBox.Text;
            string quantityString = this.quantityTextBox.Text;

            if (name == null || name.Equals("") || quantityString == null || quantityString.Equals(""))
            {
                DialogResult dialogResult = MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);
            }
            else if (IngredientDAL.getIngredients(name).Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Ingredient is already added", "Error", MessageBoxButtons.OK);
            }
            else
            {

                int quantity = Convert.ToInt32(quantityString);

                Ingredient ingredient = new Ingredient(ActiveUser.username, name, quantity);

                this.addIngredient(ingredient);

                DialogResult dialogResult =
                    MessageBox.Show("This ingredient has been added", "Success", MessageBoxButtons.OK);

                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addIngredient(Ingredient ingredient)
        {
            using (MySqlConnection sqlConn = new MySqlConnection(Connection.ConnectionString))
            {
                sqlConn.Open();

                string query = "insert into ingredient values(@username, @ingredientName, @quantity, @ingredientID)";
                using var command = new MySqlCommand(query, sqlConn);

                command.Parameters.AddWithValue("@username", ingredient.username);
                command.Parameters.AddWithValue("@ingredientID", ingredient.id);
                command.Parameters.AddWithValue("@ingredientName", ingredient.name);
                command.Parameters.AddWithValue("@quantity", ingredient.quantity);

                command.ExecuteNonQuery();
            }

            this.ingredientsPage.UpdateIngredientsGridView();
        }
    }
}
