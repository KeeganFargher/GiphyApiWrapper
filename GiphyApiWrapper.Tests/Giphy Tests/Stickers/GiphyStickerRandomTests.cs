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
    public class GiphyStickerRandomTests
    {
        [Fact]
        public async Task ParameterIsNull_ThrowsNullReferenceException()
        {
            var giphy = new Giphy("test");

            StickerRandomParameter search = null;

            _ = await Assert.ThrowsAsync<NullReferenceException>(() => giphy.StickerRandom(search));
        }

        [Fact]
        public async Task NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new StickerRandomParameter();

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.StickerRandom(search));
        }

        [Fact]
        public async Task WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new StickerRandomParameter();

            var actual = await giphy.StickerRandom(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }
    }
}
