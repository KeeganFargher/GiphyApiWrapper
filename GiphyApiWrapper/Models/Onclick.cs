using Newtonsoft.Json;
using System;

namespace GiphyApiWrapper.Models
{
    public class Onclick
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

}
