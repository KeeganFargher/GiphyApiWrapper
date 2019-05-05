using System;
using System.Collections.Generic;
using System.Text;

namespace Giphy.Models.Parameters
{
    public class TrendingParameter
    {
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
    }
}
