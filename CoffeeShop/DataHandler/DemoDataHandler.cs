using CoffeeShop.Models;

namespace CoffeeShop.DataHandler
{
    public class DemoDataHandler
    {

        //Demo Project
        public List<ItemModel> GetProducts()
        {
            var products = new List<ItemModel>();
            products.Add(new ItemModel { Description = "Dietary considerations: vegetarian", Name = "Black Coffee", Price = 5.0, ImagePath = "blackcoffee.png", ProductID = 1 });
            products.Add(new ItemModel { Description = "Dietary considerations: vegetarian", Name = "Cold Coffee", Price = 10.0, ImagePath = "coldcoffee.png", ProductID = 2 });
            products.Add(new ItemModel { Description = "Dietary considerations: vegetarian", Name = "Espresso", Price = 20.0, ImagePath = "espresso.png", ProductID = 3 });
            products.Add(new ItemModel { Description = "Dietary considerations: vegetarian", Name = "Latte", Price = 3.5, ImagePath = "latte.png", ProductID = 4 });

            products.Add(new ItemModel { Description = "Dietary considerations: vegetarian", Name = "Burger", Price = 20.0, ImagePath = "burger.png", ProductID = 5 });
            products.Add(new ItemModel { Description = "Dietary considerations: vegetarian", Name = "Fries", Price = 15.0, ImagePath = "fries.png", ProductID = 6 });
            products.Add(new ItemModel { Description = "Dietary considerations: vegetarian", Name = "Coffee & Croissant", Price = 20.0, ImagePath = "coffee_croissant.png", ProductID = 7 });
            products.Add(new ItemModel { Description = "Dietary considerations: vegetarian", Name = "Waffles", Price = 12.0, ImagePath = "waffles.png", ProductID = 8 });

            return products;
        }//
    }
}
