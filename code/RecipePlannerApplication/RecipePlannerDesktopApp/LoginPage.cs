using RecipePlannerLibrary;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace RecipePlannerDesktopApplication
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.emptyFieldErrorLabel.Visible = false;
            if (this.usernameTextBox.Text.Equals("") || this.passwordTextBox.Text.Equals(""))
            {
                this.emptyFieldErrorLabel.Text = "Please fill out all fields";
                this.emptyFieldErrorLabel.Visible = true;
            }
            else
            {
                Login attempt = new Login();
                attempt.Username = this.usernameTextBox.Text;
                attempt.Password = this.passwordTextBox.Text;
                int result = Database.LoginCheck(attempt);
                var message = "";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                if (result == 1)
                {
                    this.Hide();
                    IngredientsPage ingredients = new IngredientsPage();
                    ingredients.Show();
                }
                else
                {
                    message = "Failed login";
                    var box = MessageBox.Show(message, "", buttons);
                    if (box == System.Windows.Forms.DialogResult.Yes)
                    {

                    }
                }
            }
            
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Register();
            form.ShowDialog();
        }
    }
}
