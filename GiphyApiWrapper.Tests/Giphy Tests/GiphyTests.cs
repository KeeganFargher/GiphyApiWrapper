using GiphyApiWrapper.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiphyApiWrapper.Tests.Giphy_Tests
{
    public class GiphyTests
    {
        [Fact]
        public void Giphy_ApiKeyNull_ThrowsFormatException()
        {
            Giphy giphy;

            _ = Assert.Throws<FormatException>(() => giphy = new Giphy(apiKey: null));
        }

        [Fact]
        public void Giphy_ApiKeyEmpty_ThrowsFormatException()
        {
            Giphy giphy;

            _ = Assert.Throws<FormatException>(() => giphy = new Giphy(apiKey: ""));
        }
    }
}
