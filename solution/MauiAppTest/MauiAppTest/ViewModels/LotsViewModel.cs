using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using MauiAppTest.Models;
using MauiAppTest.Services;
using MauiAppTest.Views;

namespace MauiAppTest.ViewModels;

/// <summary>
/// Liste des lots.
/// ViewModel associé à la vue <see cref="Views.LotsPage"/>.
/// </summary>
public partial class LotsViewModel : BaseViewModel
{
    #region Properties

    /// <summary>
    /// Liste des lots.
    /// </summary>
    public ObservableCollection<Lot> Lots { get; } = new();

    /// <summary>
    /// Voir <see cref="LotService"/>.
    /// </summary>
    private readonly LotService lotService;

    /// <summary>
    /// Interface utilisée pour tester l’accès à internet.
    /// </summary>
    private readonly IConnectivity connectivity;

    /// <summary>
    /// Interface utilisée pour la géolocalisation.
    /// </summary>
    private readonly IGeolocation geolocation;

    #endregion

    #region Methods

    /// <summary>
    /// Constructeur de la classe.
    /// </summary>
    public LotsViewModel(LotService lotService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Liste des lots";
        this.lotService = lotService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
    }

    /// <summary>
    /// Récupération de la liste des lots.
    /// </summary>
    [RelayCommand]
    private async Task GetLotsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Pas d’internet.", "Vérifier que vous aillez bien accès à internet et ré-essayez.", "OK");
                return;
            }

            IsBusy = true;

            var lots = await lotService.GetLots();

            if (Lots.Count != 0)
                Lots.Clear();

            foreach (var lot in lots)
                Lots.Add(lot);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Impossible de récupérer les lots : {ex.Message}");
            await Shell.Current.DisplayAlert("Erreur", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    /// <summary>
    /// Accès au détail du lot sélectionné.
    /// </summary>
    [RelayCommand]
    private async Task GoToDetailsAsync(Lot lot)
    {
        if (lot == null)
            return;

        await Shell.Current.GoToAsync(nameof(LotDetailPage), true, new Dictionary<string, object>
        {
            {"Lot", lot }
        });
    }

    /// <summary>
    /// Récupération du lot le plus proche.
    /// </summary>
    [RelayCommand]
    private async Task GetClosestLotAsync()
    {
        if (IsBusy || Lots.Count == 0)
            return;

        try
        {
            // Récupération de la dernière localisation, ou de la localisation actuelle.
            var location = await geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }

            // Récupération du lot le plus proche.
            var first = Lots.OrderBy(m => location.CalculateDistance(new Location(m.Latitude, m.Longitude), DistanceUnits.Kilometers)).FirstOrDefault();
            await Shell.Current.DisplayAlert("", $"{first.Name} {first.Location}", "OK");

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Impossible de récupérer la localisation : {ex.Message}");
            await Shell.Current.DisplayAlert("Erreur", ex.Message, "OK");
        }
    }

    #endregion

}
