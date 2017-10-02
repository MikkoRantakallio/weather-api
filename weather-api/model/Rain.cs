using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ekoodi.Weather.API
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double RainVolume3h { get; set; }
    }
}
