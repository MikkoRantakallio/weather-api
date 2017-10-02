using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ekoodi.Weather.API
{
    public class City
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string CityName { get; set; }

        [JsonProperty("country")]
        public string CountryCode { get; set; }

        [JsonProperty("coord")]
        public Geolocation Geolocation { get; set; }
    }
}
