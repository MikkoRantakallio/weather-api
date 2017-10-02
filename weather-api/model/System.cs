using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ekoodi.Weather.API
{
    public class System
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
