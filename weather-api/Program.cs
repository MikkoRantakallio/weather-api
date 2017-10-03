using System;
using System.Collections.Generic;

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

                if (!exit && cityInput.Length > 0)
                {

                    Console.WriteLine("");

                    string cityName = weather.GetLocationName(cityInput);

                    if (cityName == "Not found")
                    {
                        Console.WriteLine("Not found!");
                    }
                    else
                    {
                        Console.WriteLine("Local weather in {0}:", cityName);
                        Console.WriteLine("Temperature:\t{0} celcius", weather.GetTemperatureC(cityInput));
                        Console.WriteLine("Wind speed:\t{0} m/s", weather.GetWindSpeed(cityInput));

                        List<WeatherDescription> descrList = weather.GetDescrList();

                        if (descrList != null)
                        {
                            foreach (WeatherDescription descr in descrList)
                            {
                                Console.WriteLine("ID:\t\t{0}", descr.Id);
                                Console.WriteLine("Description:\t{0}", descr.GroupWeatherCondition);
                            }
                        }
                    }

                    // Get forecast for five days
                    Forecast5days forecast = weather.GetForecast(cityInput);
                    Console.WriteLine("");

                    if (forecast != null)
                    {
                        Console.WriteLine("5 days / 3h forecast for {0}:", forecast.City.CityName);
                        Console.WriteLine("Time\t\t\tTemp\tWind\t\tDescr", forecast.City.CityName);

                        foreach (Forecast fc in forecast.ForecastList)
                        {
                            Console.Write(fc.TimeTxt.Substring(0, fc.TimeTxt.Length-3) + "\t" + Math.Round(fc.MainData.Temperature - 272.15) + " C\t"
                                + Math.Round(fc.Wind.Speed) + " m/s " + Math.Round(fc.Wind.Degree) + " deg\t");

                            foreach (WeatherDescription wd in fc.Descriptions)
                            {
                                string desc = wd.GroupWeatherCondition;
                                desc = desc.Substring(0, 1).ToUpper() + desc.Substring(1);
                                Console.Write(desc);
                            }
                            Console.WriteLine("");
                        }
                    }
                }
            } while (!exit);
        }
    }
}