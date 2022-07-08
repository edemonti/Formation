using PresentationLayer.Wpf.Technical;

namespace PresentationLayer.Wpf.ViewModel
{
    /// <summary>
    /// ViewModel permettant d’afficher une fenêtre de dialogue.
    /// </summary>
    public class DialogViewModel : BaseViewModel
    {
        #region Private fields

        private string dialogTitle;
        private int dialogHeight;
        private int dialogWidth;
        private object dialogContentViewModel;

        #endregion

        #region Properties


        /// <summary>
        /// Titre de la fenêtre de dialogue.
        /// </summary>
        public string DialogTitle
        {
            get { return dialogTitle; }
            set { SetField(ref dialogTitle, value); }
        }

        /// <summary>
        /// Hauteur de la fenêtre de dialogue.
        /// </summary>
        public int DialogHeight
        {
            get { return dialogHeight; }
            set { SetField(ref dialogHeight, value); }
        }

        /// <summary>
        /// Largeur de la fenêtre de dialogue.
        /// </summary>
        public int DialogWidth
        {
            get { return dialogWidth; }
            set { SetField(ref dialogWidth, value); }
        }

        /// <summary>
        /// ViewModel sélectionné à afficher dans la popup.
        /// </summary>
        public object DialogContentViewModel
        {
            get { return dialogContentViewModel; }
            set { SetField(ref dialogContentViewModel, value); }
        }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        /// <summary>
        /// Initialisation de l’écran.
        /// </summary>
        /// <param name="parameter"></param>
        public DialogViewModel(NavigationParameter parameter)
        {
            DialogContentViewModel = parameter.ViewModel;
            DialogTitle = parameter.Title;
            DialogHeight = parameter.Height;
            DialogWidth = parameter.Width;
        }

        #endregion

        #region DataLoading

        #endregion

        #region Commands implementation

        #endregion

    }

}