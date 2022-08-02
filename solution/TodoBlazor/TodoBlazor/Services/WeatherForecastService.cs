using TodoBlazor.Models;

namespace TodoBlazor.Services
{
    /// <summary>
    /// Service de gestion des <see cref="TodoModel"/>.
    /// </summary>
    public class WeatherForecastService
    {
        #region Private fields

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public Task<WeatherForecastModel[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }

        #endregion
    }
}