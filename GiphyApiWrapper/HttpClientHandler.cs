using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GiphyApiWrapper
{
    public class HttpClientHandler : IHttpHandler
    {
        private readonly HttpClient _client;

        public HttpClientHandler()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage Get(string url) => GetAsync(url).Result;

        public HttpResponseMessage Post(string url, HttpContent content) => PostAsync(url, content).Result;

        public async Task<HttpResponseMessage> GetAsync(string url) => await _client.GetAsync(url);

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content) => await _client.PostAsync(url, content);
    }
}
