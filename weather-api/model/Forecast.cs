using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekoodi.Weather.API
{
    public class Forecast
    {
        [JsonProperty("dt")]
        public string TimeStamp { get; set; }

        [JsonProperty("main")]
        public MainData MainData { get; set; }

        [JsonProperty("weather")]
        public List<WeatherDescription> Descriptions { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("snow")]
        public Snow Snow { get; set; }

        [JsonProperty("dt_txt")]
        public string TimeTxt { get; set; }
    }
}
