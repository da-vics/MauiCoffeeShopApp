using CoffeeShop.DataHandler;
using CoffeeShop.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CoffeeShop.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        public ObservableCollection<ItemModel> Products { get; set; }

        public IRelayCommand ItemSelectCommand { get; set; }
        public IRelayCommand GoToCartCommand { get; set; }

        private DemoDataHandler dataHandler = new DemoDataHandler();
        public HomeViewModel()
        {
            Products = new ObservableCollection<ItemModel>(dataHandler.GetProducts());
            ItemSelectCommand = new RelayCommand<ItemModel>(async model => await itemSelect(model));
            GoToCartCommand = new RelayCommand(async () => await goToCart());
        }

        private async Task goToCart()
        {
            await Shell.Current.GoToAsync("/CartPage");
        }//

        private async Task itemSelect(ItemModel model)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("model", model);
            await Shell.Current.GoToAsync("/OrderPage", data);
        }

    }
}
