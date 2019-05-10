using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyApiWrapper.Models.Parameters.Stickers
{
    public class StickerRandomParameter
    {
        private string _tag;

        /// <summary>
        /// Filters results by specified tag.
        /// </summary>
        public string Tag { get => _tag; set => _tag = Uri.EscapeUriString(value); }

        /// <summary>
        /// Limit results to the rated symbol and below. Default is G.
        /// </summary>
        public Rating Rating { get; set; } = Rating.G;
    }
}
