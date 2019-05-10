using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyApiWrapper.Models.Parameters.Stickers
{
    public class StickerTrendingParameter
    {
        /// <summary>
        /// (Optional) The number of results to return. Default 25.
        /// </summary>
        public int Limit { get; set; } = 25;

        /// <summary>
        /// Limit results to the rated symbol and below. Default is G.
        /// </summary>
        public Rating Rating { get; set; } = Rating.G;
    }
}
