using System.Windows;
using System.Windows.Input;
using Technical.Commands;
using Technical.Messages;
using Technical.UserControls;

namespace Wpf.UserControls
{
    /// <summary>
    /// Logique d'interaction pour BusinessMessageUC.xaml
    /// </summary>
    public partial class BusinessMessageUC : BaseUserControl
    {
        #region DependencyProperties

        /// <summary>
        /// Message métier.
        /// </summary>
        public BusinessMessage BusinessMessage
        {
            get { return (BusinessMessage)GetValue(BusinessMessageProperty); }
            set { SetValueDp(BusinessMessageProperty, value); }
        }
        public static readonly DependencyProperty BusinessMessageProperty =
            DependencyProperty.Register("BusinessMessage", typeof(BusinessMessage), typeof(BusinessMessageUC), null);

        /// <summary>
        /// Flag indiquant si le message est visible.
        /// </summary>
        public bool IsBusinessMessageVisible
        {
            get { return (bool)GetValue(IsBusinessMessageVisibleProperty); }
            set { SetValueDp(IsBusinessMessageVisibleProperty, value); }
        }
        public static readonly DependencyProperty IsBusinessMessageVisibleProperty =
            DependencyProperty.Register("IsBusinessMessageVisible", typeof(bool), typeof(BusinessMessageUC), new PropertyMetadata(true));

        #endregion

        #region Commands

        /// <summary>
        /// Action de fermeture de la popup.
        /// </summary>
        public ICommand ClosePopupCommand { get; }

        #endregion

        #region Constructors

        public BusinessMessageUC()
            : base()
        {
            InitializeComponent();
            (Content as FrameworkElement).DataContext = this; // Permet le Binding d’un UserControl.

            // Initialisation des commandes.
            ClosePopupCommand = new RelayCommand(ExecuteClosePopupCommand, CanExecuteClosePopupCommand);
        }

        #endregion

        #region Commands implementation

        /// <summary>
        /// Peut-exécuter la commande <see cref="ClosePopupCommand"/> ?
        /// Cette action est toujours possible.
        /// </summary>
        private bool CanExecuteClosePopupCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// Exécution de la commande <see cref="ClosePopupCommand"/>.
        /// </summary>
        public void ExecuteClosePopupCommand(object obj)
        {
            IsBusinessMessageVisible = false;
        }

        #endregion
    }
}
