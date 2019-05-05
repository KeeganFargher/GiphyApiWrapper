using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giphy.Models
{
    public class RootObject
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
