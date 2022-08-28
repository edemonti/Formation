using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiDocumentation.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        #region Properties

        /// <summary>
        /// Flag indiquant si l’appareil est occupé.
        /// </summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        /// <summary>
        /// Flag indiquant si la page est en cours de rafraîchissement.
        /// </summary>
        [ObservableProperty]
        private bool isRefreshing;

        /// <summary>
        /// Flag indiquant si l’appareil n’est pas occupé.
        /// </summary>
        public bool IsNotBusy => !IsBusy;

        /// <summary>
        /// Titre de la page.
        /// </summary>
        [ObservableProperty]
        private string title;

        #endregion

        #region Methods

        [RelayCommand]
        private async Task GotoPageAsync(string command)
        {
            await Shell.Current.GoToAsync(command);
        }

        #endregion
    }
}
