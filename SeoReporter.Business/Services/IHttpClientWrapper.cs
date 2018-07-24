using System.Net.Http;
using System.Threading.Tasks;

namespace SeoReporter.Business.Services
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}