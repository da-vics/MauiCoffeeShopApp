using CoffeeShop.Services;
using CoffeeShop.Services.Interface;

namespace CoffeeShop;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Handlee-Regular.ttf", "HandleeFont");
            });

        builder.Services.AddSingleton<IAlertService, AlertService>();

        return builder.Build();
    }
}
