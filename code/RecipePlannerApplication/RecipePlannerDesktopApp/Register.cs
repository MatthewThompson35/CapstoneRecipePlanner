using RecipePlannerLibrary.Database;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    /// Register partial class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Register : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Register"/> class.
        /// </summary>
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.passwordErrorLabel.Visible = false;
            this.registerCheck();
        }

        private void registerCheck()
        {
            if (this.IsTextEmpty())
            {
                this.passwordErrorLabel.Text = "Please fill out all fields";
                this.passwordErrorLabel.Visible = true;
            }
            else
            {
                var username = this.usernameTextBox.Text;
                List<string> list = Database.ContainsUser(username);
                if (list.Count() > 0)
                {
                    this.passwordErrorLabel.Text = "Username is a duplicate";
                    this.passwordErrorLabel.Visible = true;
                }
                else if (this.passwordConfirmTextBox.Text.Equals(this.passwordTextBox.Text))
                {
                    this.createNewUser(username, out var password);
                }
                else
                {
                    this.passwordErrorLabel.Text = "Passwords do not match";
                    this.passwordErrorLabel.Visible = true;
                }
            }
        }

        private void createNewUser(string username, out string password)
        {
            password = this.passwordTextBox.Text;
            Database.CreateUser(username, password);
            this.Hide();
            Form form = new LoginPage();
            form.ShowDialog();
        }

        private bool IsTextEmpty()
        {
            return this.usernameTextBox.Text.Equals("") || this.passwordTextBox.Text.Equals("") || this.passwordConfirmTextBox.Text.Equals("");
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new LoginPage();
            form.ShowDialog();
        }
    }


}
