using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ekoodi.Weather.API
{
    class Program
    {
//        static HttpClient client = new HttpClient();
        static Weather weather = new Weather();

        static CurrentWeather localWeather;
        static Forecast5days forecast;

        static void Main()
        {
            bool exit = false;
/*            string url = "http://api.openweathermap.org/data/2.5/";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            */
            do
            {
                Console.Write("Give a city: (X=Exit): ");
                string cityInput = Console.ReadLine();

                if (cityInput.ToUpper() == "X")
                    exit = true;

                if (!exit && cityInput.Length>0)
                {
                    // Get current weather
                    GetWeatherAsync(client.BaseAddress + "weather?q=" + cityInput).Wait();

                    Console.WriteLine("");
                    Console.WriteLine("Local weather in {0}:", localWeather.LocationName);
                    Console.WriteLine("Temperature:\t{0} celcius", Math.Round(localWeather.MainData.Temperature-272.15));
                    Console.WriteLine("Wind speed:\t{0} m/s", Math.Round(localWeather.Wind.Speed));

                    foreach (WeatherDescription descr in localWeather.Descriptions)
                    {
                        Console.WriteLine("ID:\t\t{0}", descr.Id);
                        Console.WriteLine("Description:\t{0}", descr.GroupWeatherCondition);
                    }

                    // Get forecast for five days
                    GetForecastAsync(client.BaseAddress + "forecast?q=" + cityInput).Wait();

                    Console.WriteLine("");
                    Console.WriteLine("5 days / 3h forecast for {0}:", forecast.City.CityName);

                    foreach( Forecast fc in forecast.ForecastList)
                    {
                        Console.WriteLine(fc.TimeTxt);
                        Console.WriteLine("Temperature:\t{0} celcius", Math.Round( fc.MainData.Temperature - 272.15));
                        Console.WriteLine("Wind speed:\t{0} m/s from direction: {1}", Math.Round(fc.Wind.Speed), Math.Round(fc.Wind.Degree));

                        foreach (WeatherDescription wd in fc.Descriptions)
                        {
                            Console.WriteLine("Description:\t{0}", wd.GroupWeatherCondition);
                        }
                        Console.WriteLine("");
                    }
                }
            } while (!exit);

        }

        static async Task<CurrentWeather> GetWeatherAsync(string path)
        {
            path += "&APPID=52087b841a0e19eae02720bc08ef0b5b";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                localWeather = JsonConvert.DeserializeObject<CurrentWeather>(data);
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
            }
            return forecast;
        }
    }
}