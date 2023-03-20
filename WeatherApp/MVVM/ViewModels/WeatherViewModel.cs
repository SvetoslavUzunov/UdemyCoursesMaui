using System.Text.Json;
using System.Windows.Input;
using PropertyChanged;
using WeatherApp.MVVM.Models;

namespace WeatherApp.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class WeatherViewModel
{
   private HttpClient httpClient;

   public WeatherViewModel()
   {
      httpClient = new HttpClient();
   }

   public WeatherData WeatherData { get; set; }

   public string PlaceName { get; set; }

   public DateTime Date { get; set; } = DateTime.Now;

   public ICommand SearchCommand
          => new Command(async (searchText) =>
            {
               PlaceName = searchText.ToString();
               var location = await GetCoordinatesAsync(searchText.ToString());
               await GetWeather(location);
            });

   private async Task<Location> GetCoordinatesAsync(string address)
   {
      IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(address);

      return locations?.FirstOrDefault();
   }

   private async Task GetWeather(Location location)
   {
      var url = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&hourly=temperature_2m&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";

      var response = await httpClient.GetAsync(url);

      if (response.IsSuccessStatusCode)
      {
         using var responseStream = await response.Content.ReadAsStreamAsync();
         var data = await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
         WeatherData = data;
      }
   }
}
