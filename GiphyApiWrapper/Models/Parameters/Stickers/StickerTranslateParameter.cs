using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyApiWrapper.Models.Parameters.Stickers
{
    public class StickerTranslateParameter
    {
        private string _query;

        /// <summary>
        /// The term or phrase to search for
        /// </summary>
        public string Query { get => _query; set => _query = Uri.EscapeUriString(value); }
    }
}
