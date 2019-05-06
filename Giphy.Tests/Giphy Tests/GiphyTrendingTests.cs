using Giphy.Models;
using Giphy.Models.Parameters;
using Giphy.Tests.Mock_Data;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Giphy.Tests
{
    public class GiphyTrendingTests
    {

        [Fact]
        public async Task Trending_NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new TrendingParameter();

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.Trending(search));
        }

        [Fact]
        public async Task Trending_WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new TrendingParameter();

            var actual = await giphy.Trending(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }

    }
}
