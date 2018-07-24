using System.Threading.Tasks;
using SeoReporter.Business.Helpers;

namespace SeoReporter.Business.Services
{
    public class GoogleSearcher : ISearcher
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public GoogleSearcher(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<string> GetContent(string criteria, int numberOfResults = 100)
        {
            var googleUrl = $"https://www.google.com.au/search?num={numberOfResults}&q={criteria.GetQueryStringFriendlyParameters()}";
            var response = await _httpClientWrapper.GetAsync(googleUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
