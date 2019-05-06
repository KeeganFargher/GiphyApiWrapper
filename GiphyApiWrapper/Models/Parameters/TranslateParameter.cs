using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyApiWrapper.Models.Parameters
{
    public class TranslateParameter
    {
        private string _query;

        /// <summary>
        /// The term or phrase to search for
        /// </summary>
        public string Query { get => _query; set => _query = Uri.EscapeUriString(value); }

        /// <summary>
        /// (Optional) Value from 0 - 10 which makes results more or less weird/random/wtf
        /// </summary>
        public int Weirdness { get; set; } = 10;
    }
}
