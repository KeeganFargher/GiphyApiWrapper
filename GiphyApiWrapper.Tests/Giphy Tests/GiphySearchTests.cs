using GiphyApiWrapper.Models;
using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Tests.Mock_Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using GiphyApiWrapper;

namespace GiphyApiWrapper.Tests
{
    public class GiphySearchTests
    {
        [Fact]
        public async Task Search_QueryNotSpecified_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            //  The query variable was not set in the paramter model
            //  which is required to run a query on giphy's api
            var search = new SearchParameter();

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.Search(search));
        }

        [Fact]
        public async Task Search_ParameterIsNull_ThrowsNullReferenceException()
        {
            var giphy = new Giphy("test");

            SearchParameter search = null;

            _ = await Assert.ThrowsAsync<NullReferenceException>(() => giphy.Search(search));
        }

        [Fact]
        public async Task Search_NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new SearchParameter { Query = "test" };

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.Search(search));
        }

        [Fact]
        public async Task Search_WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new SearchParameter { Query = "test" };

            var actual = await giphy.Search(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }
    }
}
