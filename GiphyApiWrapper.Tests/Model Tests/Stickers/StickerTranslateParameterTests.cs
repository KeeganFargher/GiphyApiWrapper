using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;
using System;
using Xunit;

namespace GiphyApiWrapper.Tests.Model_Tests.Stickers
{
    public class StickerTranslateParameterTests
    {
        [Fact]
        public void Query_WhenSet_EscapesUriString()
        {
            var parameter = new StickerTranslateParameter
            {
                Query = "This is a unit test!"
            };

            var expected = "This%20is%20a%20unit%20test!";
            var actual = parameter.Query;

            Assert.NotNull(actual);
            Assert.IsType<string>(actual);
            Assert.Equal(expected, actual);
        }
    }
}
