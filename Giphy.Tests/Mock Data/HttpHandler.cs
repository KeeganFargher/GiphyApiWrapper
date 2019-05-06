using Giphy.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Giphy.Tests.Mock_Data
{
    public class HttpHandler
    {
        private static HttpResponseMessage _responseMessageFailed;
        private static HttpResponseMessage _responseMessageSuccess;

        public static IHttpHandler GetMockFailedHttpHandlerObject()
        {
            _responseMessageFailed = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            var _mockHttpHandler = new Mock<IHttpHandler>();
            _mockHttpHandler
                .Setup(_ => _.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(_responseMessageFailed));

            return _mockHttpHandler.Object;
        }

        public static IHttpHandler GetMockSuccessHttpHandlerObject()
        {
            _responseMessageSuccess = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ObjectContent(new RootObject().GetType(), new RootObject(), new JsonMediaTypeFormatter())
            };

            var _mockHttpHandler = new Mock<IHttpHandler>();
            _mockHttpHandler
                .Setup(_ => _.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(_responseMessageSuccess));

            return _mockHttpHandler.Object;
        }
    }
}
