using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GiphyApiWrapper.Models;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;

namespace GiphyApiWrapper
{
    public class Giphy
    {
        private IHttpHandler _httpHandler;

        private static readonly string BaseUrl = "https://api.giphy.com/v1";

        private readonly string _apiKey;

        /* Giphy API endpoints */

        private readonly string _searchUrl = $"{ BaseUrl }/gifs/search";

        private readonly string _trendingUrl = $"{ BaseUrl }/gifs/trending";

        private readonly string _translateUrl = $"{ BaseUrl }/gifs/translate";

        private readonly string _randomUrl = $"{ BaseUrl }/gifs/random";

        private readonly string _getGifByIdUrl = $"{ BaseUrl }/gifs";

        private readonly string _getGifsByIdUrl = $"{ BaseUrl }/gifs";


        /* Giphy random ID */

        private readonly string _randomIdUrl = $"{ BaseUrl }/randomid";

        /* Giphy sticker endpoints */

        private readonly string _stickersSearchUrl = $"{ BaseUrl }/stickers/search";

        private readonly string _stickersTrendingUrl = $"{ BaseUrl }/stickers/trending";

        private readonly string _stickersTranslateUrl = $"{ BaseUrl }/stickers/translate";

        private readonly string _stickersRandomUrl = $"{ BaseUrl }/stickers/random";

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
        /// Search GIPHY's library of millions of GIFs for a word or phrase.
        /// </summary>
        /// <param name="parameter">Specifies search parameters</param>
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

            /* Finish exception checks */

            string url = $@"{ _searchUrl }?api_key={ _apiKey }&q={ parameter.Query }&limit={ parameter.Limit }&offset={ parameter.Offset }&lang={ parameter.Language }&rating={ parameter.Rating.ToString() }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Returns a list of the top trending GIFs on the internet, consistently updated throughout each day.
        /// </summary>
        /// <param name="parameter">Specifies search parameters</param>
        /// <returns>Root object</returns>
        public async Task<RootObject> Trending(TrendingParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            /* Finish exception checks */

            string url = $@"{ _trendingUrl }?api_key={ _apiKey }&limit={ parameter.Limit }&offset={ parameter.Offset }&rating={ parameter.Rating.ToString() }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// The translate API draws on search, but uses the GIPHY special sauce
        /// to handle translating from one vocabulary to another. In this case,
        /// words and phrases to GIFs.
        /// </summary>
        /// <param name="parameter">Specifies search parameters/param>
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

            /* Finish exception checks */

            string url = $@"{ _translateUrl }?api_key={ _apiKey }&s={ parameter.Query }&weirdness={ parameter.Weirdness }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Returns a random GIF within the category of a specified tag.
        /// If no tag is specified, the GIF returned will be completely random.
        /// </summary>
        /// <param name="parameter">Specifies search parameters/param>
        /// <returns>Root object</returns>
        public async Task<RootObject> Random(RandomParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            /* Finish exception checks */

            string url = $@"{ _randomUrl }?api_key={ _apiKey }";
            url += parameter.Tag != null ? $"&tag={ parameter.Tag }" : "";
            url += $"&rating={ parameter.Rating }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Returns GIF metadata when a user enters a GIF's unique ID
        /// </summary>
        /// <param name="gifId">The ID of the GIF/param>
        /// <returns>Root object</returns>
        public async Task<RootObject> GifById(string gifId)
        {
            if (string.IsNullOrEmpty(gifId))
            {
                throw new FormatException("Id paramter cannot be null or empty.");
            }

            /* Finish exception checks */

            string url = $@"{ _getGifByIdUrl }/gif_id={ gifId }?api_key={ _apiKey }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Returns GIF metadata when a user enters a GIF's unique ID
        /// </summary>
        /// <param name="gifIds">The list of GIF ids/param>
        /// <returns>Root object</returns>
        public async Task<RootObject> GifsById(List<string> gifIds)
        {
            if (gifIds is null)
            {
                throw new NullReferenceException("The list of GIFs cannot be null.");
            }

            if (gifIds?.Count == 0)
            {
                throw new FormatException("The list of GIFs cannot be empty.");
            }

            if (gifIds.Any(x => x == null))
            {
                throw new NullReferenceException("One or more of the items in your list contains a null value.");
            }

            /* Finish exception checks */

            //  The GIF ids need to be comma seperated and white space removed
            var ids = gifIds.Aggregate((a, b) => a + "," + b.Trim());

            string url = $@"{ _getGifsByIdUrl }?api_key={ _apiKey }&ids={ ids }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Replicates the functionality and requirements of the 
        /// classic GIPHY search, but returns animated stickers rather than GIFs.
        /// </summary>
        /// <param name="parameter">Specifies search parameters</param>
        /// <returns>Root object</returns>
        public async Task<RootObject> StickerSearch(StickerSearchParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            if (string.IsNullOrEmpty(parameter.Query))
            {
                throw new FormatException("Query paramter cannot be null or empty.");
            }

            /* Finish exception checks */

            string url = $@"{ _stickersSearchUrl }?api_key={ _apiKey }&q={ parameter.Query }&limit={ parameter.Limit }&offset={ parameter.Offset }&lang={ parameter.Language }&rating={ parameter.Rating.ToString() }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Fetch Stickers currently trending online.
        /// Hand curated by the GIPHY editorial team.
        /// Returns 25 results by default.
        /// </summary>
        /// <param name="parameter">Specifies search parameters</param>
        /// <returns>Root object</returns>
        public async Task<RootObject> StickerTrending(StickerTrendingParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            /* Finish exception checks */

            string url = $@"{ _stickersTrendingUrl }?api_key={ _apiKey }&limit={ parameter.Limit }&rating={ parameter.Rating.ToString() }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// The translate API draws on search, but uses the GIPHY special
        /// sauce to handle translating from one vocabulary to another.
        /// In this case, words and phrases to GIFs.
        /// </summary>
        /// <param name="parameter">Specifies search parameters</param>
        /// <returns>Root object</returns>
        public async Task<RootObject> StickerTranslate(StickerTranslateParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            if (string.IsNullOrEmpty(parameter.Query))
            {
                throw new FormatException("Query paramter cannot be null or empty.");
            }

            /* Finish exception checks */

            string url = $@"{ _stickersTranslateUrl }?api_key={ _apiKey }&s={ parameter.Query }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }

        /// <summary>
        /// Returns a random Sticker, limited by tag. 
        /// Excluding the tag parameter will return a 
        /// random Sticker from the GIPHY catalog.
        /// </summary>
        /// <param name="parameter">Specifies search parameters</param>
        /// <returns>Root object</returns>
        public async Task<RootObject> StickerRandom(StickerRandomParameter parameter)
        {
            if (parameter is null)
            {
                throw new NullReferenceException("Paramter cannot be null");
            }

            /* Finish exception checks */

            string url = $@"{ _stickersRandomUrl }?api_key={ _apiKey }";
            url += parameter.Tag != null ? $"&tag={ parameter.Tag }" : "";
            url += $"&rating={ parameter.Rating }";

            var response = await _httpHandler.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return await response.Content.ReadAsAsync<RootObject>();
        }
    }
}
