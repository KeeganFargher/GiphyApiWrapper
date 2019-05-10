using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;
using System;
using Xunit;

namespace GiphyApiWrapper.Tests.Model_Tests.Stickers
{
    public class StickerRandomParameterTests
    {
        [Fact]
        public void Tag_WhenSet_EscapesUriString()
        {
            var paramter = new StickerRandomParameter
            {
                Tag = "This is a unit test!"
            };

            var expected = "This%20is%20a%20unit%20test!";
            var actual = paramter.Tag;

            Assert.NotNull(actual);
            Assert.IsType<string>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rating_DefaultValue_IsG()
        {
            var parameter = new StickerRandomParameter();

            var expected = Rating.G;
            var actual = parameter.Rating;

            Assert.IsType<Rating>(actual);
            Assert.Equal(expected, actual);
        }
    }
}
