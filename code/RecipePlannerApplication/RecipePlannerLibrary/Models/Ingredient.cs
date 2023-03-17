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
        /// Gets or sets the name of the Ingredient.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? name { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the Ingredient.
        /// </summary>
        /// <value>
        /// The quantity of the Ingredient.
        /// </value>
        public int? quantity { get; set; }

        /// <summary>
        /// Gets or sets the id of the Ingredient.
        /// </summary>
        /// <value>
        /// The id of the Ingredient.
        /// </value>
        public int? id { get; set; }

        /// <summary>
        /// Gets or sets the measurement of the Ingredient.
        /// </summary>
        /// <value>The measurement of the Ingredient.</value>
        public string? measurement { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="name">The name of the Ingredient.</param>
        /// <param name="quantity">The quantity of the Ingredient.</param>
        /// <param name="id">The id of the Ingredient.</param>
        /// <precondition> none </precondition>
        /// <postcondition>this.username = username && this.id = id && this.name = name && this.quantity = quantity && this.measurement = measurement</postcondition>
        public Ingredient(string username, string name, int quantity, int id, string measurement)
        {
            this.username = username;
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.measurement = measurement;
        }

        /// <summary>
        /// Represents a string representation of the Ingredient object
        /// </summary>
        /// <returns>
        /// A string representation that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return name + " - Quantity: " + quantity.ToString();
        }
    }
}
