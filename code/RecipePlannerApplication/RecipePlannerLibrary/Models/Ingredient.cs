

namespace RecipePlannerLibrary.Models
{
    public class Ingredient
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public int? quantity { get; set; }

        public Ingredient(int id, string name, int quantity)
        {
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
