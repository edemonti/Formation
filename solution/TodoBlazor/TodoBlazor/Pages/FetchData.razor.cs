using Microsoft.AspNetCore.Components;
using TodoBlazor.Models;
using TodoBlazor.Services;

namespace TodoBlazor.Pages
{
    public partial class FetchData
    {
        #region Private fields

        /// <summary>
        /// Liste des <see cref="WeatherForecastModel"/>.
        /// </summary>
        private WeatherForecastModel[] weatherForecast;

        #endregion

        #region Properties

        /// <summary>
        /// Voir <see cref="WeatherForecastService"/>.
        /// </summary>
        [Inject]
        private WeatherForecastService service { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initialisation des données de la page.
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            weatherForecast = await service.GetForecastAsync(DateTime.Now);
        }

        #endregion
    }
}
