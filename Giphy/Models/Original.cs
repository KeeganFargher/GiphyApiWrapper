using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giphy.Models
{
    public class Original
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Width { get; set; }

        [JsonProperty("height")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Height { get; set; }

        [JsonProperty("size")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Size { get; set; }

        [JsonProperty("frames")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Frames { get; set; }

        [JsonProperty("mp4")]
        public Uri Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Mp4Size { get; set; }

        [JsonProperty("webp")]
        public Uri Webp { get; set; }

        [JsonProperty("webp_size")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long WebpSize { get; set; }
    }
}
