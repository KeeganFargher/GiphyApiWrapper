using GiphyApiWrapper.Models;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Tests.Mock_Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using GiphyApiWrapper;
using GiphyApiWrapper.Models.Parameters.Stickers;

namespace GiphyApiWrapper.Tests.Giphy_Tests.Stickers
{
    public class GiphyStickerTrendingTests
    {
        [Fact]
        public async Task ParameterIsNull_ThrowsNullReferenceException()
        {
            var giphy = new Giphy("test");

            StickerTrendingParameter search = null;

            _ = await Assert.ThrowsAsync<NullReferenceException>(() => giphy.StickerTrending(search));
        }

        [Fact]
        public async Task NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new StickerTrendingParameter();

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.StickerTrending(search));
        }

        [Fact]
        public async Task WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new StickerTrendingParameter();

            var actual = await giphy.StickerTrending(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }
    }
}
