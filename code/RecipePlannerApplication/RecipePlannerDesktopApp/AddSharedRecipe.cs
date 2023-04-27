using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    /// The class for sharing a meal to another user
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AddSharedRecipe : Form
    {
        private RecipeDetailsPage detailsPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddSharedRecipe"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        public AddSharedRecipe(RecipeDetailsPage page)
        {
            InitializeComponent();
            this.detailsPage = page;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.detailsPage.Show();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            this.errorLabel.Visible = false;
            var username = this.userTextBox.Text;
            var isValid = Database.ContainsUser(username).Count != 0;
            var recipe =
                new SharedRecipe(
                    RecipeDAL.getRecipeByName(
                        RecipeDAL.getRecipeNameById(this.detailsPage.getRecipeId(), Connection.ConnectionString),
                        Connection.ConnectionString), ActiveUser.username, username);
            if (RecipeDAL.ContainsSharedRecipe(recipe).Count > 0)
            {
                this.errorLabel.Text = "You have already shared this recipe with " + username;
                this.errorLabel.Visible = true;
            }

            if (isValid && RecipeDAL.ContainsSharedRecipe(recipe).Count == 0)
            {
                RecipeDAL.shareRecipe(username, this.detailsPage.getRecipeId(), Connection.ConnectionString);
                this.Hide();
                this.detailsPage.Show();
            }

            if(!isValid)
            {
                this.errorLabel.Text = "Username " + username + " does not exist";
                this.errorLabel.Visible = true;
            }
        }
    }
}
