using GiphyApiWrapper.Models;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Tests.Mock_Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiphyApiWrapper.Tests.Giphy_Tests
{
    public class GiphyRandomTests
    {
        [Fact]
        public async Task Search_ParameterIsNull_ThrowsNullReferenceException()
        {
            var giphy = new Giphy("test");

            RandomParameter search = null;

            _ = await Assert.ThrowsAsync<NullReferenceException>(() => giphy.Random(search));
        }

        [Fact]
        public async Task Search_NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new RandomParameter();

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.Random(search));
        }

        [Fact]
        public async Task Search_WhenCalled_ReturnsGiphySingle()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new RandomParameter();

            var actual = await giphy.Random(search);

            Assert.NotNull(actual);
            Assert.IsType<GiphySingle>(actual);
        }
    }
}
