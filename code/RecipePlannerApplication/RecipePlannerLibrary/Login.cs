namespace RecipePlannerLibrary
{
    /// <summary>
    /// Login class
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the error message for incorrect login credentials.
        /// </summary>
        /// <value>
        /// The error message for incorrect login credentials.
        /// </value>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Creates a new instance of a Login object 
        /// </summary>
        public Login()
        {
            this.Username = "";
            this.Password = "";
            this.ErrorMessage = "";
        }
    }
}
