using CoffeeShop.Services.Interface;
using CoffeeShop.Views;

namespace CoffeeShop;

public partial class App : Application
{
    public static IServiceProvider Services;
    public static IAlertService alertService;

    public App(IServiceProvider provider)
    {
        InitializeComponent();
        Services = provider;
        alertService = Services.GetService<IAlertService>();

        MainPage = new MainPage();
    }
}
