using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.MVVM.Converters
{
    public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string weatherCode)
            {
                switch (weatherCode)
                {
                    case "01d": // Clear sky (day)
                        return "Images/weather-fine-4-128.png";
                    case "01n": // Clear sky (night)
                        return "Images/weather-night-3-128.png";
                    case "02d": // Few clouds (day)
                        return "Images/weather-cloudy-19-128.png";
                    case "02n": // Few clouds (night)
                        return "Images/weather-cloudy-night-1-128.png";
                    case "03d": // Scattered clouds (day)
                    case "03n": // Scattered clouds (night)
                        return "Images/weather-cloudy-20-128.png";
                    case "04d": // Broken clouds (day)
                    case "04n": // Broken clouds (night)
                        return "Images/weather-cloudy-20-128.png";
                    case "09d": // Shower rain (day)
                    case "09n": // Shower rain (night)
                    case "10d": // Rain (day)
                    case "10n": // Rain (night)
                        return "Images/weather-light-rain-5-128.png";
                    case "11d": // Thunderstorm (day)
                    case "11n": // Thunderstorm (night)
                        return "Images/weather-thunderstorm-5-128.png";
                    case "13d": // Snow (day)
                    case "13n": // Snow (night)
                        return "Images/weather-moderate-snow-5-128.png";
                    case "50d": // Mist (day)
                    case "50n": // Mist (night)
                        return "Images/weather-haze-3-128.png";
                    default:
                        return "Images/unknown.png";
                }
            }

            return "Images/unknown.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
