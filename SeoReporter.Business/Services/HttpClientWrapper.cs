using System.Net.Http;
using System.Threading.Tasks;

namespace SeoReporter.Business.Services
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client = new HttpClient();
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }
    }
}