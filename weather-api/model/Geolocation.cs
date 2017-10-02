using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekoodi.Weather.API
{
    public class Geolocation
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
