using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeoReporter.Application;
using SeoReporter.Business.Services;

namespace SeoReporter
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            BootstrapConfiguration();
        }

        private static void BootstrapConfiguration()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var app = serviceProvider.GetService<IApplication>();
            while (true)
            {
                app.Run().GetAwaiter().GetResult();
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISearcher, GoogleSearcher>();
            serviceCollection.AddTransient<IApplication, Application.Application>();
            serviceCollection.AddTransient<IMatchFinder, SearchResultFinder>();

            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IHttpClientWrapper>(new HttpClientWrapper());
        }
    }
}
