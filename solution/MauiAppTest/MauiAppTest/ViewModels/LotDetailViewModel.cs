using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppTest.Models;

namespace MauiAppTest.ViewModels;

/// <summary>
/// Détail d’un lot.
/// ViewModel associé à la vue <see cref="Views.LotDetailPage"/>.
/// </summary>
[QueryProperty(nameof(Lot), "Lot")]
public partial class LotDetailViewModel : BaseViewModel
{

    #region Properties

    /// <summary>
    /// Lot sélectionné au niveau de la liste des lots.
    /// </summary>
    [ObservableProperty]
    private Lot lot;

    /// <summary>
    /// Interface permettant d’accéder à la carte.
    /// </summary>
    private IMap map;

    #endregion

    #region Methods

    /// <summary>
    /// Constructeur de la classe.
    /// </summary>
    public LotDetailViewModel(IMap map)
    {
        //Title = Lot.Name;
        this.map = map; 
    }

    /// <summary>
    /// Ouverture de la carte et zoom sur le lot.
    /// </summary>
    [RelayCommand]
    private async Task OpenMapAsync()
    {
        try
        {
            await map.OpenAsync(Lot.Latitude, Lot.Longitude, new MapLaunchOptions
            {
                Name = Lot.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Impossible d’ouvrir la carte : {ex.Message}");
            await Shell.Current.DisplayAlert("Erreur", "Impossible d’ouvrir la carte.", ex.Message, "OK");
        }
    }

    #endregion

}