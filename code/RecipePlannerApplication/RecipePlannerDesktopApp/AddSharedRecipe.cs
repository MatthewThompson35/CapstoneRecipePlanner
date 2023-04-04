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
            this.comboBox.DataSource = Database.getUsers();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.detailsPage.Show();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (this.comboBox.SelectedValue != null && !string.IsNullOrEmpty(this.comboBox.SelectedValue.ToString()))
            {
                SharedRecipe recipe =
                    new SharedRecipe(
                        RecipeDAL.getRecipeByName(RecipeDAL.getRecipeNameById(this.detailsPage.getRecipeId(), Connection.ConnectionString), Connection.ConnectionString), ActiveUser.username, this.comboBox.SelectedValue.ToString());
                if (RecipeDAL.ContainsSharedRecipe(recipe).Count > 0)
                {
                    this.errorLabel.Visible = true;
                }
                else
                {
                    this.errorLabel.Visible = false;
                    string selectedValue = this.comboBox.SelectedValue.ToString();
                    RecipeDAL.shareRecipe(selectedValue, this.detailsPage.getRecipeId(), Connection.ConnectionString);
                    this.Hide();
                    this.detailsPage.Show();
                }
            }
        }
    }
}
