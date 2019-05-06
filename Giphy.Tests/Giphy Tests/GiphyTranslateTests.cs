using Giphy.Models;
using Giphy.Models.Parameters;
using Giphy.Tests.Mock_Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Giphy.Tests
{
    public class GiphyTranslateTests
    {
        [Fact]
        public async Task Translate_QueryNotSpecified_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            //  The query variable was not set in the paramter model
            //  which is required to run a query on giphy's api
            var search = new TranslateParameter();

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.Translate(search));
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(11)]
        [InlineData(-1)]
        public async Task Translate_WeirdnessOutOfRange_ThrowsFormatException(int value)
        {
            var giphy = new Giphy("test");

            var search = new TranslateParameter
            {
                Query = "test",
                Weirdness = value
            };

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.Translate(search));
        }

        [Fact]
        public async Task Translate_NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = HttpHandler.GetMockFailedHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new TranslateParameter { Query = "test" };

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.Translate(search));
        }

        [Fact]
        public async Task Translate_WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = HttpHandler.GetMockSuccessHttpHandlerObject();
            var giphy = new Giphy(mockHttpHandler);
            var search = new TranslateParameter { Query = "test" };

            var actual = await giphy.Translate(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }
    }
}
