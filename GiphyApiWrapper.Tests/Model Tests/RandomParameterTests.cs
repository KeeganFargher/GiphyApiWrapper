using GiphyApiWrapper.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GiphyApiWrapper.Tests.Model_Tests
{
    public class RandomParameterTests
    {
        [Fact]
        public void Tag_WhenSet_EscapesUriString()
        {
            var paramter = new RandomParameter
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
        public void Language_DefaultValue_IsNull()
        {
            var parameter = new RandomParameter();

            string expected = null;
            var actual = parameter.Tag;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rating_DefaultValue_IsG()
        {
            var parameter = new RandomParameter();

            var expected = Rating.G;
            var actual = parameter.Rating;

            Assert.IsType<Rating>(actual);
            Assert.Equal(expected, actual);
        }
    }
}
