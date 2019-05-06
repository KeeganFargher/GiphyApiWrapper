using Giphy.Models.Parameters;
using System;
using Xunit;

namespace Giphy.Tests
{
    public class TranslateParamterTests
    {
        [Fact]
        public void Query_WhenSet_EscapesUriString()
        {
            var param = new TranslateParameter
            {
                Query = "This is a unit test!"
            };

            var expected = "This%20is%20a%20unit%20test!";
            var actual = param.Query;

            Assert.NotNull(actual);
            Assert.IsType<string>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Weirdness_DefaultValue_Is10()
        {
            var param = new TranslateParameter();

            var expected = 10;
            var actual = param.Weirdness;

            Assert.IsType<int>(actual);
            Assert.Equal(expected, actual);
        }
    }
}
