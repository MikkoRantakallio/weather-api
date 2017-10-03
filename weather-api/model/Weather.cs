using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ekoodi.Weather.API
{
    public class Weather
    {
        static HttpClient client = new HttpClient();
        public static CurrentWeather localWeather = new CurrentWeather();
        static Forecast5days forecast = new Forecast5days();

        static bool found;

        public double GetTemperatureC(string city)
        {
            if (localWeather.LocationName == null || localWeather.LocationName.ToUpper() != city.ToUpper())
            {
                localWeather = GetWeather(city);
            }
            if (found)
            {
                double temp = Math.Round(localWeather.MainData.Temperature - 272.15);
                return temp;
            }
            else
            {
                return 0;
            }
        }

        public double GetWindSpeed(string city)
        {
            if (localWeather.LocationName == null || localWeather.LocationName.ToUpper() != city.ToUpper())
            {
                localWeather = GetWeather(city);
            }
            if (found)
            {
                double temp = Math.Round(localWeather.Wind.Speed);
                return temp;
            }
            else
            {
                return 0;
            }
        }

        public string GetLocationName(string city)
        {
            if (localWeather.LocationName == null || localWeather.LocationName.ToUpper() != city.ToUpper())
            {
                localWeather = GetWeather(city);
            }
            if (found)
            {
                string loca = localWeather.LocationName;
                return loca;
            }
            else
            {
                return "Not found";
            }
        }

        public List<WeatherDescription> GetDescrList()
        {
            if (found)
            {
                return localWeather.Descriptions;
            }
            else
            {
                return null;
            }
        }

        //===========================================================

        public Weather()
        {
            string url = "http://api.openweathermap.org/data/2.5/";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            found = true;
        }

        public CurrentWeather GetWeather( string city)
        {
            GetWeatherAsync(client.BaseAddress + "weather?q=" + city).Wait();
            return localWeather;
        }

        public Forecast5days GetForecast(string city)
        {
            GetForecastAsync(client.BaseAddress + "forecast?q=" + city).Wait();
            return forecast;
        }

        //==========================================================================

        static async Task<CurrentWeather> GetWeatherAsync(string path)
        {
            path += "&APPID=52087b841a0e19eae02720bc08ef0b5b";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                localWeather = JsonConvert.DeserializeObject<CurrentWeather>(data);
                found = true;
            }
            else
            {
                found = false;
            }
            return localWeather;
        }

        static async Task<Forecast5days> GetForecastAsync(string path)
        {
            path += "&APPID=52087b841a0e19eae02720bc08ef0b5b";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                forecast = JsonConvert.DeserializeObject<Forecast5days>(data);
                found = true;
                return forecast;
            }
            else
            {
                found = false;
                forecast = null;
                return forecast;
            }
        }
    }
}
