using CommunityToolkit.Mvvm.Input;

namespace MauiDocumentation.ViewModels
{
    public partial class AfficherFenetreContextuelleViewModel : BaseViewModel
    {

        #region Properties

        #endregion

        #region Constructors

        public AfficherFenetreContextuelleViewModel()
        {
            Title = "Afficher des fenêtres contextuelles";
        }

        #endregion


        #region Methods

        [RelayCommand]
        private async Task ExecuteActionAsync(string command)
        {
            await Shell.Current.DisplayAlert("Alert", "You have been alerted", "OK");


            bool answer = await Shell.Current.DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
            await Shell.Current.DisplayAlert("Alert", "Answer: " + answer, "OK");

            await Shell.Current.DisplayAlert("Question?", "Would you like to play a game", "Yes", "No", FlowDirection.LeftToRight);
            await Shell.Current.DisplayAlert("Question?", "Would you like to play a game", "Yes", "No", FlowDirection.RightToLeft);

            string action = await Shell.Current.DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
            await Shell.Current.DisplayAlert("Alert", "Action: " + action, "OK");

        }

        #endregion


    }
}
