using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.MVVM.Models;
using WeatherApp.MVVM.Services;

namespace WeatherApp.MVVM.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private bool isFetchingWeather = false;
        public bool IsFetchingWeather
        {
            get { return  isFetchingWeather; }
            set
            {
                isFetchingWeather = value;
                OnPropertyChanged(nameof(IsFetchingWeather));
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }


        private string newCity;
        public string NewCity
        {
            get { return newCity; } 
            set
            {
                if (newCity != value)
                {
                    newCity = value;
                    OnPropertyChanged();
                }
            }
        }

        private WeatherModel weather;
        public WeatherModel Weather
        {
            get { return weather; }
            set
            {
                if(weather != value)
                {
                    weather = value;
                    OnPropertyChanged(nameof(Weather));
                }
            }
        }

        public ICommand SetCityCommand { get; private set; }
        
        public WeatherViewModel()
        {
            City = Properties.Settings.Default.City;
            if (string.IsNullOrEmpty(City))
            {
                City = "New York";
            }
            SetCityCommand = new RelayCommand(async (param) => await SetNewCity(), (param) => !IsFetchingWeather);
        }

        private async Task SetNewCity()
        {
           if (!string.IsNullOrEmpty(NewCity))
            {
                City = NewCity;
                Properties.Settings.Default.City = City;
                Properties.Settings.Default.Save();
                Weather = await WeatherService.GetWeatherAsync(City);
                NewCity = string.Empty;
            }
        }

        
        public async Task GetWeatherAsync()
        {
            Weather = await WeatherService.GetWeatherAsync(City);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
