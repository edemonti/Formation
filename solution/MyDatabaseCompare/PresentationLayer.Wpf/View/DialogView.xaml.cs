using System.Windows;
using PresentationLayer.Wpf.Technical;
using PresentationLayer.Wpf.ViewModel;

namespace PresentationLayer.Wpf.View
{
    /// <summary>
    /// Logique d'interaction pour DialogView.xaml
    /// </summary>
    public partial class DialogView : Window
    {
        public DialogView(NavigationParameter parameter)
        {
            InitializeComponent();
            this.DataContext = new DialogViewModel(parameter);
        }
    }
}
