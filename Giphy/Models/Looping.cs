using Newtonsoft.Json;
using System;

namespace Giphy.Models
{
    public class Looping
    {
        [JsonProperty("mp4")]
        public Uri Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Mp4Size { get; set; }
    }
}
