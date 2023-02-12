

namespace RecipePlannerLibrary.Models
{
    public class Ingredient
    {
        public string? username { get; set; }
        public string? name { get; set; }
        public int? quantity { get; set; }
        public int? id { get; set; }

        public Ingredient(string username, string name, int quantity, int id)
        {
            this.username = username;
            this.id = id;
            this.name = name;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return name + " - Quantity: " + quantity.ToString();
        }
    }
}
