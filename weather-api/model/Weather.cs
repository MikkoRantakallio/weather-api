using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;

namespace Ekoodi.Weather.API
{
    public class Weather
    {
        static HttpClient client = new HttpClient();

        [JsonProperty("3h")]
        public double RainVolume3h { get; set; }

        public Weather()
        {
            string url = "http://api.openweathermap.org/data/2.5/";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
        }
    }
}
