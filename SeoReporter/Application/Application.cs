using SeoReporter.Business.Services;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SeoReporter.Business.Helpers;

namespace SeoReporter.Application
{
    public class Application : IApplication
    {
        private readonly IConfiguration _config;
        private readonly ISearchResultFinder _matchFinder;

        private readonly ISearcher _searcher;

        public Application(ISearcher searcher, IConfiguration config, ISearchResultFinder matchFinder)
        {
            _searcher = searcher;
            _config = config;
            _matchFinder = matchFinder;
        }

        public async Task Run()
        {
            Console.Write("What is your search term? ");
            var searchCriteria = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(searchCriteria) || String.IsNullOrWhiteSpace(searchCriteria.StripNonAlphanumeric()))
            {
                Console.Write("That is not a valid term, please try again: ");
                searchCriteria = Console.ReadLine();
            }
            var content = await _searcher.GetContent(searchCriteria);

            if (String.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Unable to make google request. Please try again.");
            }
            else
            {
                var matchesResult = _matchFinder.FindPositions(content, _config["companyDetails:url"]);
                Console.WriteLine($"We found your site {_config["companyDetails:url"]} in the following positions (Zero means not found at all): {matchesResult}");
            }
        }
    }
}
