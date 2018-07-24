using Xunit;
using SeoReporter.Business.Helpers;

namespace SeoReporter.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("Test", "Test")]
        [InlineData("MyTest!@#$$%^&*()_+", "MyTest")]
        [InlineData("   MyTest ", "MyTest")]
        [InlineData("Some Url With a Space", "Some+Url+With+a+Space")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void GetQueryStringFriendlyParameters_ShouldReturnCorrectResult(string input, string expectedResult)
        {
            var result = input.GetQueryStringFriendlyParameters();

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("href=\"/url?q=https://www.someUrl.com/en?q=1\"", "https://www.someUrl.com/en?q=1")]
        [InlineData("href=\"/url?q=https://www.someUrl.com\"", "https://www.someUrl.com")]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("something not matching", "")]
        public void ExtractUrlFromHref_ShouldExtractResult(string input, string expectedResult)
        {
            var result = input.ExtractUrlFromHref();

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("this is a test with nothing stripped", "this is a test with nothing stripped")]
        [InlineData("a!b@c#d$e%f^", "abcdef")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void StripNonAlphanumeric_ShouldStripCorrectCharacters(string input, string expectedResult)
        {
            var result = input.StripNonAlphanumeric();

            Assert.Equal(expectedResult, result);
        }
    }
}
