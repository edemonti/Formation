namespace PresentationLayer.Wpf.Technical
{
    /// <summary>
    /// Déclaration des paramètres à utiliser pour la navigation entre écrans.
    /// </summary>
    public class NavigationParameter
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        public object ViewModel { get; set; }

        /// <summary>
        /// Paramètres à passer au viewmodel
        /// </summary>
        public object Parameters { get; set; }

        /// <summary>
        /// Titre de l’écran à ouvrir.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Hauteur de l’écran à ouvrir.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Largeur de l’écran à ouvrir.
        /// </summary>
        public int Width { get; set; }


        public NavigationParameter(object viewModel)
        {
            ViewModel = viewModel;
        }

        public NavigationParameter()
        {

        }
    }
}