namespace CoffeeShop.Models
{
    public class PurchaseModel
    {
        public ItemModel Item { get; set; }
        public int Quntity { get; set; }

        public double TotalPrice { get => GetPrice(); }

        private double GetPrice() => Quntity * Item.Price;
    }
}
