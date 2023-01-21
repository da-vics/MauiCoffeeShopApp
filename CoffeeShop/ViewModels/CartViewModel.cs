using CoffeeShop.Models;
using CoffeeShop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CoffeeShop.ViewModels
{
    public class CartViewModel : ObservableObject
    {
        public ObservableCollection<PurchaseModel> Cart { get; set; }

        private double _totalCost = 0.0;
        public double TotalCost { get => _totalCost; set { SetProperty(ref _totalCost, value); } }

        public IRelayCommand CheckOutCommand { get; set; }
        public IRelayCommand RemoveItemCommand { get; set; }

        private bool _itemsVisibility;
        public bool ItemsVisibility { get => _itemsVisibility; set { SetProperty(ref _itemsVisibility, value); } }

        public CartViewModel()
        {
            CheckOutCommand = new RelayCommand(async () => await checkout());
            RemoveItemCommand = new RelayCommand<PurchaseModel>(model => removeItem(model));
            Cart = new ObservableCollection<PurchaseModel>(CartService.Cart);
            getTotal();
            setVisisbility();
        }

        private void setVisisbility()
        {

            if (Cart.Count == 0)
                ItemsVisibility = false;
            else
                ItemsVisibility = true;
        }

        private async Task checkout()
        {
            var name = await App.alertService.DisplayPromt("Details", "Enter your name");
            var phoneNumber = await App.alertService.DisplayPromt("Details", "Enter your phone Number");
            var user = new UserModel { UserName = name, PhoneNumber = phoneNumber };

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("User", user);

            await Shell.Current.GoToAsync("/OrderSummaryPage", data);
        }//

        private void removeItem(PurchaseModel item)
        {
            Cart.Remove(item);
            CartService.Cart.Remove(item);
            getTotal();
            setVisisbility();
        }//

        private void getTotal()
        {
            foreach (var item in Cart)
                TotalCost += item.TotalPrice;
        }
    }
}
