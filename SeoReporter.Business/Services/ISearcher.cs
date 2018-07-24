using System.Threading.Tasks;

namespace SeoReporter.Business.Services
{
    public interface ISearcher
    {
        Task<string> GetContent(string criteria, int numberOfResults = 100);
    }
}
