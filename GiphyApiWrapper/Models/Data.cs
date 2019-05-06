using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyApiWrapper.Models
{
    public class Data
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("bitly_gif_url")]
        public Uri BitlyGifUrl { get; set; }

        [JsonProperty("bitly_url")]
        public Uri BitlyUrl { get; set; }

        [JsonProperty("embed_url")]
        public Uri EmbedUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("source")]
        public Uri Source { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("content_url")]
        public string ContentUrl { get; set; }

        [JsonProperty("source_tld")]
        public string SourceTld { get; set; }

        [JsonProperty("source_post_url")]
        public Uri SourcePostUrl { get; set; }

        [JsonProperty("is_sticker")]
        public long IsSticker { get; set; }

        //[JsonProperty("import_datetime")]
        //public DateTime ImportDatetime { get; set; }

        //[JsonProperty("trending_datetime")]
        //public DateTime TrendingDatetime { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("analytics")]
        public Analytics Analytics { get; set; }
    }
}
