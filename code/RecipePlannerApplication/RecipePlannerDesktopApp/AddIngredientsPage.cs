using MySql.Data.MySqlClient;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    /// Add ingredients page partial class.
    /// </summary>
    public partial class AddIngredientsPage : Form
    {
        private IngredientsPage ingredientsPage;
        private ShoppingListPage shoppingListPage;

        /// <summary>
        /// Initializes the AddIngreedients page with the corresponding ingredients page.
        /// </summary>
        /// <param name="ingredientsPage"></param>
        public AddIngredientsPage(IngredientsPage ingredientsPage)
        {
            InitializeComponent();

            this.ingredientsPage = ingredientsPage;
            this.shoppingListPage = null;
            this.duplicateIngredientError.Visible = false;
        }

        /// <summary>
        /// Initializes the AddIngreedients page with the corresponding ingredients page.
        /// </summary>
        /// <param name="ingredientsPage"></param>
        public AddIngredientsPage(ShoppingListPage shoppingListPage)
        {
            InitializeComponent();

            this.shoppingListPage = shoppingListPage;
            this.ingredientsPage = null;
            this.duplicateIngredientError.Visible = false;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string name = this.ingredientNameTextBox.Text;
            string quantityString = this.quantityTextBox.Text;
            string measure = this.measurementComboBox.Text;
            int number = 0;

            this.submitCheck(name, quantityString, measure, number);

        }

        private void submitCheck(string name, string quantityString, string measure, int number)
        {
            try
            {
                if (isTextEmpty(name, quantityString, measure))
                {
                    this.errorTextLabel.Visible = true;
                }
                else if (!int.TryParse(quantityString, out number))
                {
                    this.errorQuantityTextLabel.Visible = true;
                }
                else
                {
                    int quantity = Convert.ToInt32(quantityString);

                    Ingredient ingredient = new Ingredient(ActiveUser.username, name, quantity, 0, measure);


                    if (this.ingredientsPage != null)
                    {
                        if(IngredientDAL.getIngredients(name).Count > 0)
                        {
                            this.duplicateIngredientError.Text = @"This ingredient " + "'" + name + "'" + @" already exists in pantry. Update quantity instead.";
                            this.duplicateIngredientError.Visible = true;
                            this.errorQuantityTextLabel.Visible = false;
                        }
                        else
                        {
                            this.addIngredient(ingredient);

                            this.Close();
                            this.ingredientsPage.Show();
                        }
                        
                    }
                    if (this.shoppingListPage != null)
                    {
                        if (ShoppingListDAL.getIngredients(name, Connection.ConnectionString).Count > 0)
                        {
                            this.duplicateIngredientError.Text = @"This ingredient " + "'" + name + "'" + @" already exists in shopping list. Update quantity.";
                            this.duplicateIngredientError.Visible = true;
                            this.errorQuantityTextLabel.Visible = false;
                        }
                        else
                        {
                            this.addIngredientShoppingList(ingredient);

                            this.Close();
                            this.shoppingListPage.Show();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                this.errorTextLabel.Text = "The connection to the server could not be made";
                this.errorTextLabel.Visible = true;
            }
            
        }

        private static bool isTextEmpty(string name, string quantityString, string measure)
        {
            return name == null || name.Equals("") || quantityString == null || quantityString.Equals("") || measure.Equals("");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var ing = new IngredientsPage();
            ing.Show();
        }

        private void addIngredient(Ingredient ingredient)
        {
            IngredientDAL.addIngredient(ingredient.name, (int)ingredient.quantity, ingredient.measurement, Connection.ConnectionString);

            this.ingredientsPage.UpdateIngredientsGridView();
        }

        private void addIngredientShoppingList(Ingredient ingredient)
        {
            ShoppingListDAL.addIngredient(ingredient.name, (int)ingredient.quantity, ingredient.measurement, Connection.ConnectionString);

            this.shoppingListPage.UpdateIngredientsGridView();
        }
    }
}
