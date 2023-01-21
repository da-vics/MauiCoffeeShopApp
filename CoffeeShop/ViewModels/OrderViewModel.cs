using CoffeeShop.Models;
using CoffeeShop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeShop.ViewModels
{
    [QueryProperty(nameof(Item), "model")]
    public class OrderViewModel : ObservableObject
    {
        private ItemModel _item;
        public ItemModel Item { get => _item; set { SetProperty(ref _item, value); } }

        private int _quantity = 0;
        public int Quantity { get => _quantity; set { SetProperty(ref _quantity, value); } }

        private double _totalCost = 0;
        public double TotalCost { get => _totalCost; set { SetProperty(ref _totalCost, value); } }

        public IRelayCommand ChangeQCommand { get; set; }
        public IRelayCommand AddToCartCommand { get; set; }

        public OrderViewModel()
        {
            ChangeQCommand = new RelayCommand<string>(op => changeQ(op));
            AddToCartCommand = new RelayCommand(async () => await addToCart());
        }

        private async Task addToCart()
        {
            if (Quantity == 0)
            {
                App.alertService.ShowAlert("Error", "No items to add to cart");
                return;
            }

            CartService.AddToCart(new PurchaseModel { Item = Item, Quntity = Quantity });
            await Shell.Current.GoToAsync("..");
        }

        private void changeQ(string option)
        {
            if (option == "-")
            {
                if (Quantity > 0)
                    Quantity--;
            }
            else if (option == "+")
            {
                if (Quantity < 100)
                    Quantity++;
            }

            TotalCost = Item.Price * (Quantity);
        }//
    }
}
