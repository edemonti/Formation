using MauiDocumentation.ViewModels;
using MauiDocumentation.Views;

namespace MauiDocumentation
{
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
                });


            // ViewModels.
            builder.Services.AddSingleton<DeploiementViewModel>();
            
            builder.Services.AddSingleton<DonneesServicesCloudViewModel>();
            
            builder.Services.AddSingleton<FondamentauxViewModel>();
            
            builder.Services.AddSingleton<IntegrationPlatformeViewModel>();
            
            builder.Services.AddSingleton<InterfaceUtilisateurViewModel>();
            builder.Services.AddSingleton<AfficherFenetreContextuelleViewModel>();

            builder.Services.AddSingleton<ResolutionProblemeViewModel>();
            
            builder.Services.AddSingleton<XamlViewModel>();


            // Pages.
            builder.Services.AddSingleton<DeploiementPage>();
            
            builder.Services.AddSingleton<DonneesServicesCloudPage>();
            
            builder.Services.AddSingleton<FondamentauxPage>();
            
            builder.Services.AddSingleton<IntegrationPlatformePage>();
            
            builder.Services.AddSingleton<InterfaceUtilisateurPage>();
            builder.Services.AddSingleton<AfficherFenetreContextuellePage>();

            builder.Services.AddSingleton<ResolutionProblemePage>();
            
            builder.Services.AddSingleton<XamlPage>();

            return builder.Build();
        }
    }
}