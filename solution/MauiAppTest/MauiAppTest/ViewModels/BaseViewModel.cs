using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppTest.ViewModels;

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

}
