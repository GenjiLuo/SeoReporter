using SeoReporter.Business.Services;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace SeoReporter.Application
{
    public class Application : IApplication
    {
        private readonly IConfiguration _config;

        private readonly ISearcher _searcher;

        public Application(ISearcher searcher, IConfiguration config)
        {
            _searcher = searcher;
            _config = config;
        }

        public async Task Run()
        {
            Console.Write("What is your search term? ");
            var searchCriteria = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(searchCriteria))
            {
                Console.Write("That is not a valid term, please try again: ");
                searchCriteria = Console.ReadLine();
            }

            Console.WriteLine($"You're searching for {searchCriteria} in {_config["companyDetails:url"]}");
            var a = await _searcher.FindRankings(searchCriteria, _config["companyDetails:url"]);
            System.Console.WriteLine(a);
        }
    }
}
