using CoffeeShop.Models;
using CoffeeShop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CoffeeShop.ViewModels
{

    [QueryProperty(nameof(User), "User")]
    public class OrderSummaryViewModel : ObservableObject
    {
        private UserModel _user;
        public UserModel User { get => _user; set { SetProperty(ref _user, value); } }

        private double _totalCost = 0.0;
        public double TotalCost { get => _totalCost; set { SetProperty(ref _totalCost, value); } }

        public ObservableCollection<PurchaseModel> Cart { get; set; }

        public IRelayCommand GoHomeCommand { get; set; }

        public OrderSummaryViewModel()
        {
            GoHomeCommand = new RelayCommand(async () => await goHome());
            Cart = new ObservableCollection<PurchaseModel>(CartService.Cart);
            getTotal();
            CartService.Cart.Clear();
        }

        private async Task goHome()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        private void getTotal()
        {
            foreach (var item in Cart)
                TotalCost += item.TotalPrice;
        }
    }
}
