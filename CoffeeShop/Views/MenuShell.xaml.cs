namespace CoffeeShop.Views;

public partial class MenuShell : Shell
{
    public MenuShell()
    {
        InitializeComponent();
        Routing.RegisterRoute($"//{nameof(HomePage)}", typeof(HomePage));
        Routing.RegisterRoute($"//{nameof(HomePage)}/{nameof(OrderPage)}", typeof(OrderPage));
        Routing.RegisterRoute($"//{nameof(HomePage)}/{nameof(CartPage)}", typeof(CartPage));
        Routing.RegisterRoute($"//{nameof(HomePage)}/{nameof(CartPage)}/{nameof(OrderSummaryPage)}", typeof(OrderSummaryPage));
    }

#if ANDROID
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
#endif
}