namespace SeoReporter.Business.Services
{
    public interface ISearchResultFinder
    {
        string FindPositions(string content, string url);
    }
}
