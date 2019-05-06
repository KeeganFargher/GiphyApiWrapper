using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GiphyApiWrapper.Models;
using GiphyApiWrapper.Models.Parameters;

namespace GiphyApiWrapper
{
    public class Giphy
    {
        private IHttpHandler _httpHandler;

        private static readonly string BaseUrl = "https://api.giphy.com/v1";

        private readonly string _apiKey;

        private readonly string _searchUrl = $"{ BaseUrl }/gifs/search";

        private readonly string _trendingUrl = $"{ BaseUrl }/gifs/trending";

        private readonly string _randomIdUrl = $"{ BaseUrl }/randomid";

        private readonly string _translateUrl = $"{ BaseUrl }/v1/gifs/translate";

        private readonly string _stickersSearch = $"{ BaseUrl }/v1/stickers/search";

        /// <summary>
        /// Instantiates a new Giphy Api object.
        /// </summary>
        /// <param name="apiKey">Your Giphy api key</param>
        public Giphy(string apiKey)
        {
            _apiKey = apiKey;
            _httpHandler = new HttpClientHandler();

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new FormatException("Giphy API key cannot be null or empty.");
            }
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
        /// <param name="paramter">Specifies search queries</param>
        /// <returns>Root object</returns>
        public async Task<RootObject> Search(SearchParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            if (string.IsNullOrEmpty(parameter.Query))
            {
                throw new FormatException("Query paramter cannot be null or empty.");
            }

            //  Finish exception checks

            string url = $@"{ _searchUrl }?api_key={ _apiKey }&q={ parameter.Query }&limit={ parameter.Limit }&offset={ parameter.Offset }&lang={ parameter.Language }&rating={ parameter.Rating.ToString() }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            };

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Trending endpoint for Giphy API
        /// </summary>
        /// <param name="paramter">Specifies search queries</param>
        /// <returns>Root object</returns>
        public async Task<RootObject> Trending(TrendingParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            //  Finish exception checks

            string url = $@"{ _trendingUrl }?api_key={ _apiKey }&limit={ parameter.Limit }&offset={ parameter.Offset }&rating={ parameter.Rating.ToString() }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            };

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Translate endpoint for Giphy API
        /// </summary>
        /// <param name="paramter">Specifies search queries/param>
        /// <returns>Root object</returns>
        public async Task<RootObject> Translate(TranslateParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            if (string.IsNullOrEmpty(parameter.Query))
            {
                throw new FormatException("Query paramter cannot be null or empty.");
            }

            if (parameter.Weirdness < 0 || parameter.Weirdness > 10)
            {
                throw new FormatException("Weirdness paramter must be a value between 0 - 10");
            }

            //  Finish exception checks

            string url = $@"{ _translateUrl }?api_key={ _apiKey }&s={ parameter.Query }&weirdness={ parameter.Weirdness }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            };

            return await response.Content.ReadAsAsync<RootObject>();
        }
    }
}
