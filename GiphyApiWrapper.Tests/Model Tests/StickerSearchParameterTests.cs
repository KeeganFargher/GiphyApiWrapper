using GiphyApiWrapper.Models.Parameters;
using System;
using Xunit;

namespace GiphyApiWrapper.Tests.Model_Tests
{
    public class StickerSearchParameterTests
    {
        [Fact]
        public void Query_WhenSet_EscapesUriString()
        {
            var searchParamter = new StickerSearchParameter
            {
                Query = "This is a unit test!"
            };

            var expected = "This%20is%20a%20unit%20test!";
            var actual = searchParamter.Query;

            Assert.NotNull(actual);
            Assert.IsType<string>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Limit_DefaultValue_Is25()
        {
            var searchParamter = new StickerSearchParameter();

            var expected = 25;
            var actual = searchParamter.Limit;

            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Offset_DefaultValue_Is0()
        {
            var searchParamter = new StickerSearchParameter();

            var expected = 0;
            var actual = searchParamter.Offset;

            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rating_DefaultValue_IsG()
        {
            var searchParamter = new StickerSearchParameter();

            var expected = Rating.G;
            var actual = searchParamter.Rating;

            Assert.IsType<Rating>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Language_DefaultValue_Isen()
        {
            var searchParamter = new StickerSearchParameter();

            var expected = "en";
            var actual = searchParamter.Language;

            Assert.NotNull(actual);
            Assert.IsType<string>(actual);
            Assert.Equal(expected, actual);
        }
    }
}
