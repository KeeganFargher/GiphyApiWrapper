using GiphyApiWrapper.Models;
using GiphyApiWrapper.Tests.Mock_Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiphyApiWrapper.Tests.Giphy_Tests
{
    public class GiphyGifByIdTests
    {
        [Fact]
        public async Task GifIdIsNull_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            string id = null;

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.GifById(id));
        }

        [Fact]
        public async Task GifIdIsEmpty_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            string id = "";

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.GifById(id));
        }

        [Fact]
        public async Task NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var id = "xT4uQulxzV39haRFjG";

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.GifById(id));
        }

        [Fact]
        public async Task WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var id = "xT4uQulxzV39haRFjG";

            var actual = await giphy.GifById(id);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }
    }
}
