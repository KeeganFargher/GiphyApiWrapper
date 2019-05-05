using Giphy.Models;
using Giphy.Models.Parameters;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Giphy.Tests
{
    public class GiphyTests
    {
        private HttpResponseMessage _responseMessageFailed;
        private HttpResponseMessage _responseMessageSuccess;

        #region [ Initalization ]

        public GiphyTests()
        {
            _responseMessageFailed = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            _responseMessageSuccess = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ObjectContent(new RootObject().GetType(), new RootObject(), new JsonMediaTypeFormatter())
            };
        }

        private IHttpHandler GetMockHttpHandlerObject(HttpResponseMessage responseMessage)
        {
            var _mockHttpHandler = new Mock<IHttpHandler>();
            _mockHttpHandler
                .Setup(_ => _.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(responseMessage));
            return _mockHttpHandler.Object;
        }

        #endregion

        #region [ Search ]

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
        public async Task Search_NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = GetMockHttpHandlerObject(_responseMessageFailed);
            var giphy = new Giphy(mockHttpHandler);
            var search = new SearchParameter { Query = "test" };

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.Search(search));
        }

        [Fact]
        public async Task Search_WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = GetMockHttpHandlerObject(_responseMessageSuccess);
            var giphy = new Giphy(mockHttpHandler);
            var search = new SearchParameter { Query = "test" };

            var actual = await giphy.Search(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }

        #endregion

        #region [ Trending ]

        [Fact]
        public async Task Trending_NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = GetMockHttpHandlerObject(_responseMessageFailed);
            var giphy = new Giphy(mockHttpHandler);
            var search = new TrendingParamter();

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.Trending(search));
        }

        [Fact]
        public async Task Trending_WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = GetMockHttpHandlerObject(_responseMessageSuccess);
            var giphy = new Giphy(mockHttpHandler);
            var search = new TrendingParamter();

            var actual = await giphy.Trending(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }

        #endregion

        #region [ Translate ]

        [Fact]
        public async Task Translate_QueryNotSpecified_ThrowsFormatException()
        {
            var giphy = new Giphy("test");

            //  The query variable was not set in the paramter model
            //  which is required to run a query on giphy's api
            var search = new TranslateParamter();

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.Translate(search));
        }


        [Theory]
        [InlineData(-5)]
        [InlineData(11)]
        [InlineData(-1)]
        public async Task Translate_WeirdnessOutOfRange_ThrowsFormatException(int value)
        {
            var giphy = new Giphy("test");

            var search = new TranslateParamter
            {
                Query = "test",
                Weirdness = value
            };

            _ = await Assert.ThrowsAsync<FormatException>(() => giphy.Translate(search));
        }

        [Fact]
        public async Task Translate_NotSuccessStatusCode_ThrowsHttpRequestException()
        {
            var mockHttpHandler = GetMockHttpHandlerObject(_responseMessageFailed);
            var giphy = new Giphy(mockHttpHandler);
            var search = new TranslateParamter { Query = "test" };

            _ = await Assert.ThrowsAsync<HttpRequestException>(() => giphy.Translate(search));
        }

        [Fact]
        public async Task Translate_WhenCalled_ReturnsRootObject()
        {
            var mockHttpHandler = GetMockHttpHandlerObject(_responseMessageSuccess);
            var giphy = new Giphy(mockHttpHandler);
            var search = new TranslateParamter { Query = "test" };

            var actual = await giphy.Translate(search);

            Assert.NotNull(actual);
            Assert.IsType<RootObject>(actual);
        }

        #endregion

    }
}
