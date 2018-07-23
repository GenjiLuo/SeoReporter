using System.Threading.Tasks;

namespace SeoReporter.Business.Services
{
    public interface ISearcher
    {
        Task<string> FindRankings(string criteria, string url, int numberOfResults = 100);
    }
}
