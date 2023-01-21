using CoffeeShop.Models;

namespace CoffeeShop.Services
{
    public class CartService
    {
        public static List<PurchaseModel> Cart { get; set; } = new List<PurchaseModel>();

        //Demo
        public static void AddToCart(PurchaseModel purchaseModel)
        {
            var currentModel = Cart.FirstOrDefault(obj => obj.Item.ProductID == purchaseModel.Item.ProductID);
            if (currentModel != null)
            {
                var index = Cart.IndexOf(currentModel);
                currentModel.Quntity += purchaseModel.Quntity;
                Cart[index] = currentModel;
            }
            else
                Cart.Add(purchaseModel);
        }
    }
}
