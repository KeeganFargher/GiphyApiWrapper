using Newtonsoft.Json;
using System;

namespace GiphyApiWrapper.Models
{
    public class DownsizedSmall
    {
        [JsonProperty("width")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Width { get; set; }

        [JsonProperty("height")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Height { get; set; }

        [JsonProperty("mp4")]
        public Uri Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Mp4Size { get; set; }
    }
}
