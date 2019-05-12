using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyApiWrapper.Models
{
    public class GiphySingle
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
