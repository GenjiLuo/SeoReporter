namespace SeoReporter.Business.Services
{
    public interface IMatchFinder
    {
        string FindPositions(string content, string url);
    }
}
