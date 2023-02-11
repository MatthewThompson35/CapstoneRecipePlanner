using RecipePlannerLibrary.Database;

namespace RecipePlannerDesktopApplication
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.passwordErrorLabel.Visible = false;
            if (this.usernameTextBox.Text.Equals("") || this.passwordTextBox.Text.Equals("") || this.passwordConfirmTextBox.Text.Equals(""))
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
                    var password = this.passwordTextBox.Text;
                    Database.CreateUser(username, password);
                    this.Hide();
                    Form form = new LoginPage();
                    form.ShowDialog();
                }
                else
                {
                    this.passwordErrorLabel.Text = "Passwords do not match";
                    this.passwordErrorLabel.Visible = true;
                }
            }
           
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new LoginPage();
            form.ShowDialog();
        }
    }


}
