using GiphyApiWrapper.Models.Parameters;
using GiphyApiWrapper.Models.Parameters.Stickers;
using System;
using Xunit;

namespace GiphyApiWrapper.Tests.Model_Tests.Stickers
{
    public class StickerTrendingParameterTests
    {
        [Fact]
        public void Limit_DefaultValue_Is25()
        {
            var paramter = new StickerTrendingParameter();

            var expected = 25;
            var actual = paramter.Limit;

            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rating_DefaultValue_IsG()
        {
            var paramter = new StickerTrendingParameter();

            var expected = Rating.G;
            var actual = paramter.Rating;

            Assert.IsType<Rating>(actual);
            Assert.Equal(expected, actual);
        }
    }
}
