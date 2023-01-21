namespace CoffeeShop.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int ProductID { get; set; } // unquie identifier
        public string ImagePath { get; set; }
    }
}
