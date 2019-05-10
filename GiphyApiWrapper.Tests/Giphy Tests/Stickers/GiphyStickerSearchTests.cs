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
    public class GiphyStickerSearchTests
    {
        [Fact]
        public async Task StickerSearch_QueryNotSpecified_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            //  The query variable was not set in the paramter model
            //  which is required to run a query on giphy's api
            var search = new StickerSearchParameter();

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.StickerSearch(search));
        }

        [Fact]
        public async Task StickerSearch_ParameterIsNull_ThrowsNullReferenceException()
        {
            var giphy = new Giphy("test");

            StickerSearchParameter search = null;

            _ = await Assert.ThrowsAsync<NullReferenceException>(() => giphy.StickerSearch(search));
        }

        [Fact]
        public async Task StickerSearch_NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new StickerSearchParameter { Query = "test" };

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.StickerSearch(search));
        }

        [Fact]
        public async Task StickerSearch_WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new StickerSearchParameter { Query = "test" };

            var actual = await giphy.StickerSearch(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }
    }
}
