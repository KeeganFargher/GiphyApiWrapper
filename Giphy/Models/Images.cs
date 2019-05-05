using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Giphy.Models
{
    public class Images
    {
        [JsonProperty("fixed_height_still")]
        public Still FixedHeightStill { get; set; }

        [JsonProperty("original_still")]
        public Still OriginalStill { get; set; }

        [JsonProperty("fixed_width")]
        public Fixed FixedWidth { get; set; }

        [JsonProperty("fixed_height_small_still")]
        public Still FixedHeightSmallStill { get; set; }

        [JsonProperty("fixed_height_downsampled")]
        public FixedDownsampled FixedHeightDownsampled { get; set; }

        [JsonProperty("preview")]
        public DownsizedSmall Preview { get; set; }

        [JsonProperty("fixed_height_small")]
        public Fixed FixedHeightSmall { get; set; }

        [JsonProperty("downsized_still")]
        public Downsized DownsizedStill { get; set; }

        [JsonProperty("downsized")]
        public Downsized Downsized { get; set; }

        [JsonProperty("downsized_large")]
        public Downsized DownsizedLarge { get; set; }

        [JsonProperty("fixed_width_small_still")]
        public Still FixedWidthSmallStill { get; set; }

        [JsonProperty("preview_webp")]
        public PreviewWebp PreviewWebp { get; set; }

        [JsonProperty("fixed_width_still")]
        public Still FixedWidthStill { get; set; }

        [JsonProperty("fixed_width_small")]
        public Fixed FixedWidthSmall { get; set; }

        [JsonProperty("downsized_small")]
        public DownsizedSmall DownsizedSmall { get; set; }

        [JsonProperty("fixed_width_downsampled")]
        public FixedDownsampled FixedWidthDownsampled { get; set; }

        [JsonProperty("downsized_medium")]
        public Downsized DownsizedMedium { get; set; }

        [JsonProperty("original")]
        public Original Original { get; set; }

        [JsonProperty("fixed_height")]
        public Fixed FixedHeight { get; set; }

        [JsonProperty("looping")]
        public Looping Looping { get; set; }

        [JsonProperty("original_mp4")]
        public DownsizedSmall OriginalMp4 { get; set; }

        [JsonProperty("preview_gif")]
        public Downsized PreviewGif { get; set; }
    }
}
