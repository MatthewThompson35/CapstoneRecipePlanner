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
            string measure = this.measurementComboBox.Text;
            int number;

            if (name == null || name.Equals("") || quantityString == null || quantityString.Equals("") || measure.Equals("") )
            {
                this.errorTextLabel.Visible = true;
            }
            else if (!int.TryParse(quantityString, out number))
            {
                this.errorQuantityTextLabel.Visible = true;
            }
            else if (IngredientDAL.getIngredients(name).Count > 0)
            {
                this.errorTextLabel.Text = @"This ingredient " + "'" + name + "'" + @" already exists.";
                this.errorTextLabel.Visible = true;
                this.errorQuantityTextLabel.Visible = false;
            }
            else
            {

                int quantity = Convert.ToInt32(quantityString);

                Ingredient ingredient = new Ingredient(ActiveUser.username, name, quantity, 0, measure);

                this.addIngredient(ingredient);

                this.Close();
                this.ingredientsPage.Show();
                
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.ingredientsPage.Show();
        }

        private void addIngredient(Ingredient ingredient)
        {
            using (MySqlConnection sqlConn = new MySqlConnection(Connection.ConnectionString))
            {
                sqlConn.Open();

                string query = "insert into ingredient values(@username, @ingredientName, @quantity, @ingredientID, @Measurement)";
                using var command = new MySqlCommand(query, sqlConn);

                command.Parameters.AddWithValue("@username", ingredient.username);
                command.Parameters.AddWithValue("@ingredientID", ingredient.id);
                command.Parameters.AddWithValue("@ingredientName", ingredient.name);
                command.Parameters.AddWithValue("@quantity", ingredient.quantity);
                command.Parameters.AddWithValue("@Measurement", ingredient.measurement);

                command.ExecuteNonQuery();
            }

            this.ingredientsPage.UpdateIngredientsGridView();
        }
    }
}
