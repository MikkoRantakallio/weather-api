using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ekoodi.Weather.API
{
    public class Clouds
    {
        [JsonProperty("all")]
        public double CloudinessPercentage { get; set; }
    }
}
