using System;

namespace Ekoodi.Weather.API
{
    class Program
    {
        static Weather weather = new Weather();

        static void Main()
        {
            bool exit = false;
            do
            {
                Console.Write("Give a city: (X=Exit): ");
                string cityInput = Console.ReadLine();

                if (cityInput.ToUpper() == "X")
                    exit = true;

                if (!exit && cityInput.Length>0)
                {
                    // Get current weather
                    CurrentWeather localWeather = weather.GetWeather(cityInput);

                    if (localWeather.Cod == "200")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Local weather in {0}:", localWeather.LocationName);
                        Console.WriteLine("Temperature:\t{0} celcius", Math.Round(localWeather.MainData.Temperature-272.15));
                        Console.WriteLine("Wind speed:\t{0} m/s", Math.Round(localWeather.Wind.Speed));

                        foreach (WeatherDescription descr in localWeather.Descriptions)
                        {
                            Console.WriteLine("ID:\t\t{0}", descr.Id);
                            Console.WriteLine("Description:\t{0}", descr.GroupWeatherCondition);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error in getting weather data!");
                    }

                    // Get forecast for five days
                    Forecast5days forecast = weather.GetForecast(cityInput);

                    if (forecast.Cod == "200")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("5 days / 3h forecast for {0}:", forecast.City.CityName);

                        foreach (Forecast fc in forecast.ForecastList)
                        {
                            Console.WriteLine(fc.TimeTxt);
                            Console.WriteLine("Temperature:\t{0} celcius", Math.Round(fc.MainData.Temperature - 272.15));
                            Console.WriteLine("Wind speed:\t{0} m/s from direction: {1}", Math.Round(fc.Wind.Speed), Math.Round(fc.Wind.Degree));

                            foreach (WeatherDescription wd in fc.Descriptions)
                            {
                                Console.WriteLine("Description:\t{0}", wd.GroupWeatherCondition);
                            }
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error in getting weather forecast!");
                    }
                }
            } while (!exit);
        }
    }
}