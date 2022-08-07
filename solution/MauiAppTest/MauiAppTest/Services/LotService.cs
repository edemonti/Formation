using MauiAppTest.Models;
using System.Net.Http.Json;

namespace MauiAppTest.Services;

/// <summary>
/// Service de gestion des lots.
/// </summary>
public class LotService
{

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    private HttpClient httpClient;
    
    /// <summary>
    /// Liste des lots.
    /// </summary>
    private List<Lot> lots;

    #endregion

    #region Methods

    public LotService()
    {
        this.httpClient = new HttpClient();
    }

    /// <summary>
    /// Récupération de la liste des lots.
    /// </summary>
    public async Task<List<Lot>> GetLots()
    {
        if (lots?.Count > 0)
            return lots;

        // Online
        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            lots = await response.Content.ReadFromJsonAsync<List<Lot>>();
        }

        // Offline
        /*using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);*/

        return lots;
    }

    #endregion

}