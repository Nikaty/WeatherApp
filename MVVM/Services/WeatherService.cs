using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherApp.MVVM.Models;

namespace WeatherApp.MVVM.Services
{
    public static class WeatherService
    {
        private const string ApiKey = "c98d002bc5cb27519cc10f0d99e21ed7";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public static async Task<WeatherModel> GetWeatherAsync(string city)
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string url = $"{BaseUrl}?q={city}&appid={ApiKey}";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        WeatherModel data = JsonConvert.DeserializeObject<WeatherModel>(json);
                        return data;
                    }
                    else
                    {
                        MessageBox.Show($"The response is {response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exeption", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
