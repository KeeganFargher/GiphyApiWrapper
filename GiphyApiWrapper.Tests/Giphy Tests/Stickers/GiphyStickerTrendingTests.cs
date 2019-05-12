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
    public class GiphyStickerTranslateTests
    {
        [Fact]
        public async Task QueryNotSpecified_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            //  The query variable was not set in the paramter model
            //  which is required to run a query on giphy's api
            var search = new StickerTranslateParameter();

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.StickerTranslate(search));
        }

        [Fact]
        public async Task ParameterIsNull_ThrowsNullReferenceException()
        {
            var giphy = new Giphy("test");

            StickerTranslateParameter search = null;

            _ = await Assert.ThrowsAsync<NullReferenceException>(() => giphy.StickerTranslate(search));
        }

        [Fact]
        public async Task NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new StickerTranslateParameter { Query = "test" };

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.StickerTranslate(search));
        }

        [Fact]
        public async Task WhenCalled_ReturnsGiphySingle()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new StickerTranslateParameter { Query = "test" };

            var actual = await giphy.StickerTranslate(search);

            Assert.NotNull(actual);
            Assert.IsType<GiphySingle>(actual);
        }
    }
}
