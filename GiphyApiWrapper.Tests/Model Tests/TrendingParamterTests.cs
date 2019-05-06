using GiphyApiWrapper.Models.Parameters;
using System;
using Xunit;

namespace GiphyApiWrapper.Tests.Model_Tests
{
    public class TrendingParamterTests
    {

        [Fact]
        public void Limit_DefaultValue_Is25()
        {
            var searchParamter = new TrendingParameter();

            var expected = 25;
            var actual = searchParamter.Limit;

            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Offset_DefaultValue_Is0()
        {
            var searchParamter = new TrendingParameter();

            var expected = 0;
            var actual = searchParamter.Offset;

            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rating_DefaultValue_IsG()
        {
            var searchParamter = new TrendingParameter();

            var expected = Rating.G;
            var actual = searchParamter.Rating;

            Assert.IsType<Rating>(actual);
            Assert.Equal(expected, actual);
        }
    }
}
