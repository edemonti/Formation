using MauiDocumentation.Views;

namespace MauiDocumentation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DeploiementPage), typeof(DeploiementPage));
            
            Routing.RegisterRoute(nameof(DonneesServicesCloudPage), typeof(DonneesServicesCloudPage));
            
            Routing.RegisterRoute(nameof(FondamentauxPage), typeof(FondamentauxPage));
            
            Routing.RegisterRoute(nameof(IntegrationPlatformePage), typeof(IntegrationPlatformePage));
            
            Routing.RegisterRoute(nameof(InterfaceUtilisateurPage), typeof(InterfaceUtilisateurPage));
            Routing.RegisterRoute(nameof(AfficherFenetreContextuellePage), typeof(AfficherFenetreContextuellePage));
            
            Routing.RegisterRoute(nameof(ResolutionProblemePage), typeof(ResolutionProblemePage));
            
            Routing.RegisterRoute(nameof(XamlPage), typeof(XamlPage));
        }
    }
}