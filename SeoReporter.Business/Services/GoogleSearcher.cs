using System;
using System.Net.Http;
using System.Threading.Tasks;
using SeoReporter.Business.Helpers;

namespace SeoReporter.Business.Services
{
    public class GoogleSearcher : ISearcher
    {
        private HttpClient _httpClient;
        public GoogleSearcher(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<string> FindRankings(string criteria, string url, int numberOfResults = 100)
        {
            var googleUrl = $"https://www.google.com.au/search?num={numberOfResults}&q={criteria.GetQueryStringFriendlyParameters()}";
            var response = await _httpClient.GetAsync(googleUrl);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            
            return "";

        }
    }
}
