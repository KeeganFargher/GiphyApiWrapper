using System;
using System.Collections.Generic;
using System.Text;

namespace Giphy.Models.Parameters
{
    public class TranslateParamter
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
