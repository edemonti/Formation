using MauiAppTest.Services;
using MauiAppTest.ViewModels;
using MauiAppTest.Views;

namespace MauiAppTest;

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
				fonts.AddFont("materialdesignicons-webfont.ttf", "FontIcon");
            });

        // Interfaces
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);


        // Services.
        builder.Services.AddSingleton<LotService>();

        // ViewModels.
        builder.Services.AddSingleton<ConnexionViewModel>();
        builder.Services.AddSingleton<AccueilViewModel>();
        builder.Services.AddSingleton<LotsViewModel>();
        builder.Services.AddTransient<LotDetailViewModel>();

        // Pages.
        builder.Services.AddSingleton<ConnexionPage>();
        builder.Services.AddSingleton<AccueilPage>();
        builder.Services.AddSingleton<LotsPage>();
        builder.Services.AddTransient<LotDetailPage>();

        return builder.Build();
	}
}
