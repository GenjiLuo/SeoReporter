using Xunit;
using SeoReporter.Business.Helpers;

namespace SeoReporter.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("Test", "Test")]
        [InlineData("MyTest#$@#$#@$", "MyTest")]
        [InlineData("   MyTest ", "MyTest")]
        [InlineData("Some Url With a Space", "Some+Url+With+a+Space")]
        public void GetQueryStringFriendlyParameters_ShouldReturnCorrectResult(string input, string expectedResult)
        {
            var result = input.GetQueryStringFriendlyParameters();

            Assert.Equal(expectedResult, result);
        }
    }
}
