using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    /// Login Page partial class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LoginPage : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.emptyFieldErrorLabel.Visible = false;
            this.loginCheck();
        }

        private void loginCheck()
        {
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

                if (result == 1)
                {
                    ActiveUser.username = this.usernameTextBox.Text;
                    this.Hide();

                    Homepage homepage = new Homepage();
                    homepage.Show();
                }
                else
                {
                    this.errorLoginLabel.Visible = true;
                    this.emptyFieldErrorLabel.Visible = false;
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
