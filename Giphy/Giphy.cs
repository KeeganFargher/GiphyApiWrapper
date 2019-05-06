using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Giphy.Models;
using Giphy.Models.Parameters;

namespace Giphy
{
    public class Giphy
    {
        private IHttpHandler _httpHandler;

        private static readonly string BaseUrl = "https://api.giphy.com/v1";

        private readonly string _apiKey;

        private readonly string _searchUrl = $"{ BaseUrl }/gifs/search";

        private readonly string _trendingUrl = $"{ BaseUrl }/gifs/trending";

        private readonly string _randomIdUrl = $"{ BaseUrl }/randomid";

        private readonly string _stickersSearch = $"{ BaseUrl }/v1/stickers/search";

        /// <summary>
        /// Instantiates a new Giphy Api object.
        /// </summary>
        /// <param name="apiKey">Your Giphy api key</param>
        public Giphy(string apiKey)
        {
            _apiKey = apiKey;
            _httpHandler = new HttpClientHandler();
        }

        /// <summary>
        /// Used for testing
        /// </summary>
        public Giphy(IHttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        /// <summary>
        /// Search endpoint for Giphy API
        /// </summary>
        /// <param name="paramter">Search paramter</param>
        /// <returns>Root object</returns>
        public async Task<RootObject> Search(SearchParameter paramter)
        {
            if (string.IsNullOrEmpty(paramter.Query))
            {
                throw new FormatException("Query paramter cannot be null or empty.");
            }

            string url = $@"{ _searchUrl }?api_key={ _apiKey }&q={ paramter.Query }&limit={ paramter.Limit }&offset={ paramter.Offset }&lang={ paramter.Language }&rating={ paramter.Rating.ToString() }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            };

            return await response.Content.ReadAsAsync<RootObject>();
        }

        public async Task<RootObject> Trending(TrendingParameter paramter)
        {
            string url = $@"{ _trendingUrl }?api_key={ _apiKey }&limit={ paramter.Limit }&offset={ paramter.Offset }&rating={ paramter.Rating.ToString() }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            };

            return await response.Content.ReadAsAsync<RootObject>();
        }

        public async Task<RootObject> Translate(TranslateParameter paramter)
        {
            if (string.IsNullOrEmpty(paramter.Query))
            {
                throw new FormatException("Query paramter cannot be null or empty.");
            }

            if (paramter.Weirdness < 0 || paramter.Weirdness > 10)
            {
                throw new FormatException("Weirdness paramter must be a value between 0 - 10");
            }

            string url = $@"{ _randomIdUrl }?api_key={ _apiKey }&s={ paramter.Query }&weirdness={ paramter.Weirdness }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            };

            return await response.Content.ReadAsAsync<RootObject>();
        }
    }
}
