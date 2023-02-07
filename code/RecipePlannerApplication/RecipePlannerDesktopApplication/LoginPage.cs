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
            Database.PopulateDB();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login attempt = new Login();
            attempt.Username = this.usernameTextBox.Text;
            attempt.Password = this.passwordTextBox.Text;
            int result = Database.LoginCheck(attempt);
            var message = "";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            if (result == 1)
            {
                message = "Succesful login";
                var box = MessageBox.Show(message, "", buttons);
                if (box == System.Windows.Forms.DialogResult.Yes)
                {
                 
                }
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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var username = this.usernameTextBox.Text;
            var password = this.passwordTextBox.Text;
            Database.CreateUser(username, password);
        }
    }
}
