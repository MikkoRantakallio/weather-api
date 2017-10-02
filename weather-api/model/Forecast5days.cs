using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ekoodi.Weather.API
{
    public class Forecast5days
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("cnt")]
        public int cnt { get; set; }

        [JsonProperty("list")]
        public List<Forecast> ForecastList { get; set; }
    }
}
