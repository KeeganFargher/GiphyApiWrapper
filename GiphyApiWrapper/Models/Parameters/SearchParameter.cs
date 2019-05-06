using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyApiWrapper.Models.Parameters
{
    public class SearchParameter
    {
        private string _query;

        /// <summary>
        /// The term or phrase to search for
        /// </summary>
        public string Query { get => _query; set => _query = Uri.EscapeUriString(value); }

        /// <summary>
        /// (Optional) The number of results to return. Default 25.
        /// </summary>
        public int Limit { get; set; } = 25;

        /// <summary>
        /// (Optional) Offset results. Default is 0.
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Limit results to the rated symbol and below. Default is G.
        /// </summary>
        public Rating Rating { get; set; } = Rating.G;

        /// <summary>
        /// (Optional) Default language for regional content. Use a 2-letter ISO 639-1 language code.
        /// </summary>
        public string Language { get; set; } = "en";
    }
}
