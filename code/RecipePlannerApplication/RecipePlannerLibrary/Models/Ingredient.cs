

namespace RecipePlannerLibrary.Models
{
    /// <summary>
    /// Ingredient Class
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string? username { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? name { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int? quantity { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="name">The name.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="id">The identifier.</param>
        public Ingredient(string username, string name, int quantity, int id)
        {
            this.username = username;
            this.id = id;
            this.name = name;
            this.quantity = quantity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="name">The name.</param>
        /// <param name="quantity">The quantity.</param>
        public Ingredient(string username, string name, int quantity)
        {
            this.username = username;
            this.name = name;
            this.quantity = quantity;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return name + " - Quantity: " + quantity.ToString();
        }
    }
}
