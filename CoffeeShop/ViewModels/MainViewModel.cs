using CoffeeShop.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeShop.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public IRelayCommand StartCommand { get; set; }

        public MainViewModel()
        {
            StartCommand = new RelayCommand(() => start());
        }

        private void start()
        {

            Application.Current.MainPage = new MenuShell();
        }
    }
}
