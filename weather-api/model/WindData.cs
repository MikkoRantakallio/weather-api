using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekoodi.Weather.API
{
    public class WindData
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Degree { get; set; }
    }
}
