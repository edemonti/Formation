using System.Windows.Controls;
using PresentationLayer.Wpf.ViewModel;

namespace PresentationLayer.Wpf.View
{
    /// <summary>
    /// Logique d'interaction pour ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionView : UserControl
    {
        public ConnectionView()
        {
            InitializeComponent();
            this.DataContext = new ConnectionViewModel(null);
        }
    }
}