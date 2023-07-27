using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherApp.MVVM.Models
{
    public class WeatherModel
    {
        [JsonProperty("coord")]
        public Coord coord { get; set; }
        [JsonProperty("weather")]
        private IList<Weather> weatherList;
        [JsonProperty("main")]
        private Main main;
        [JsonProperty("visibility")]
        private int visibility;
        [JsonProperty("wind")]
        private Wind wind;
        [JsonProperty("rain")]
        private Rain rain;
        [JsonProperty("clouds")]
        private Clouds clouds;
        [JsonProperty("dt")]
        private long dt;
        private Sys sys;
        private long timezone;
        private int id;
        private int cod;
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public Weather WeatherInfo
        {
            get { return weatherList[0]; }
        }

        public IList<Weather> WeatherList
        {
            get { return weatherList; }
            set { weatherList = value; }
        }

        public Main Main
        {
            get { return main; }
            set { main = value; }
        }

        public int Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        public Wind WindInfo
        {
            get { return wind; }
            set { wind  = value; }
        }

        public Rain RainInfo
        {
            get { return rain; }
            set { rain = value; }
        }

        public Clouds CloudsInfo
        {
            get { return clouds; }
            set { clouds = value; }
        }

        public long Time
        {
            get { return dt + timezone; }
            set { dt = value; }
        }

        public long TimeZone
        {
            get { return timezone; }
            set { timezone = value; }
        }

        public Sys SysInfo
        {
            get { return sys; }
            set { sys = value; }
        }
    }

    public class Coord
    {
        [JsonProperty("lon")]
        public double lon { get; set; }
        [JsonProperty("lat")]
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

    public class Rain
    {
        [JsonProperty("1h")]
        public double h1 { get; set; }        
        [JsonProperty("3h")]
        public double h3 { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public double sunrise { get; set; }
        public double sunset { get; set; }
    }
}
