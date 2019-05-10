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
    public class GiphyGifsByIdTests
    {
        [Fact]
        public async Task GifIdsIsNull_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            List<string> data = null;

            _ = await Assert.ThrowsAsync<NullReferenceException>(() => giphy.GifsById(data));
        }

        [Fact]
        public async Task GifIdsIsEmpty_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            List<string> data = new List<string>();

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.GifsById(data));
        }

        [Fact]
        public async Task ItemInListContainsNullValue_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            List<string> data = new List<string> { "test1", null, "test3" };

            _ = await Assert.ThrowsAsync<NullReferenceException>(() => giphy.GifsById(data));
        }

        [Fact]
        public async Task NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            List<string> data = new List<string> { "test1", "test2" };

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.GifsById(data));
        }

        [Fact]
        public async Task WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            List<string> data = new List<string> { "test1", "test2" };

            var actual = await giphy.GifsById(data);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }
    }
}
