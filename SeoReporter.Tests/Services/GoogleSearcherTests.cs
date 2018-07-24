using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SeoReporter.Business.Services;
using Xunit;
using Moq;

namespace SeoReporter.Tests.Services
{
    public class GoogleSearcherTests
    {
        [Fact]
        public async Task GetContent_ShouldReturnResultsDueToOKResponse()
        {
            var httpClientMock = new Mock<IHttpClientWrapper>();
            var expectedData = "testData";
            httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(expectedData)
                });
            var searcher = new GoogleSearcher(httpClientMock.Object);

            var result = await searcher.GetContent("test");

            httpClientMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
            Assert.Equal(expectedData, result);
        }

        [Fact]
        public async Task GetContent_ShouldReturnNullDueToNotSuccessfulResponse()
        {
            var httpClientMock = new Mock<IHttpClientWrapper>();
            var expectedData = "testData";
            httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(expectedData)
                });
            var searcher = new GoogleSearcher(httpClientMock.Object);

            var result = await searcher.GetContent("test");

            httpClientMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
            Assert.Null(result);
        }
    }
}
