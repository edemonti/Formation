using System.Windows.Input;
using Models.Impl;
using PresentationLayer.Wpf.Technical;
using PresentationLayer.Wpf.View;

namespace PresentationLayer.Wpf.ViewModel
{
    /// <summary>
    /// Classe de base des ViewModel.
    /// </summary>
    public class BaseViewModel : BaseModel
    {
        #region Private fields

        #endregion

        #region Properties

        #endregion

        #region Commands

        /// <summary>
        /// Commande permettant d’ouvrir une autre vue dans une popup.
        /// </summary>
        public ICommand OpenViewDialogCommand { get; set; }

        #endregion

        #region Constructor

        public BaseViewModel()
        {
            // Initialisation des commandes.
            OpenViewDialogCommand = new RelayCommand<NavigationParameter>(OpenViewDialog);
        }

        #endregion

        #region Commands implementation

        /// <summary>
        /// Ouvre une autre vue dans une popup.
        /// </summary>
        /// <param name="viewModelName">Nom du viewmodel associé à la vue à ouvrir.</param>
        public void OpenViewDialog(NavigationParameter parameter)
        {
            //DialogResult result = DialogService.OpenDialog();

            DialogView win = new DialogView(parameter);
            win.ShowDialog();
            //return DialogResult.Undefined;
        }

        //public enum DialogResult
        //{
        //    Undefined,
        //    Yes,
        //    No
        //}
        #endregion
    }
}