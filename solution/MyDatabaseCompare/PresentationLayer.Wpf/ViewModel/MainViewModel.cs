using System.Windows;
using System.Windows.Input;
using PresentationLayer.Wpf.Ressources;
using PresentationLayer.Wpf.Technical;

namespace PresentationLayer.Wpf.ViewModel
{
    /// <summary>
    /// ViewModel de la fenêtre principale.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Private fields

        private object selectedViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Titre de la fenêtre.
        /// </summary>
        public string WindowTitle
        {
            get { return Others.Title; }
        }

        /// <summary>
        /// ViewModel sélectionné.
        /// </summary>
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { SetField(ref selectedViewModel, value); }
        }

        /// <summary>
        /// Paramètres de navigation pour ouvrir l’écran d’affichage de la liste des connexions.
        /// </summary>
        public NavigationParameter ConnectionListViewModelParameters
        {
            get { return new NavigationParameter(new ConnectionListViewModel()); }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Commande permettant d’ouvrir une autre vue.
        /// </summary>
        public ICommand OpenViewCommand { get; set; }

        /// <summary>
        /// Commande permettant la fermeture de la fenêtre.
        /// </summary>
        public ICommand ExitCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            // Initialisation des commandes.
            OpenViewCommand = new RelayCommand<NavigationParameter>(OpenView);
            ExitCommand = new RelayCommand<Window>(Exit);
        }

        #endregion

        #region Commands implementation

        /// <summary>
        /// Ouvre une autre vue.
        /// </summary>
        /// <param name="viewModelName">Nom du viewmodel associé à la vue à ouvrir.</param>
        private void OpenView(NavigationParameter parameter)
        {
            SelectedViewModel = parameter.ViewModel;
        }

        /// <summary>
        /// Ferme la fenêtre.
        /// </summary>
        /// <param name="win">Fenêtre à fermer.</param>
        public void Exit(Window win)
        {
            win.Close();
        }

        #endregion
    }
}