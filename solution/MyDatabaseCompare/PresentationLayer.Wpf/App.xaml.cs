using System.Windows;
using PresentationLayer.Wpf.Technical;

namespace PresentationLayer.Wpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Bootstrapper.InitializeContainer();
        }
    }
}
