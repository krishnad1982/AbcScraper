using System.IO;
using AbcScraper.Configuration;
using AbcScraper.Core.Contracts;
using AbcScraper.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AbcScraper.Extensions
{
    public static class ServiceRegistry
    {
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IScraperService, ScraperService>();
            serviceCollection.AddSingleton(new LoggerFactory().AddConsole());

            serviceCollection.AddLogging();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false).Build();
            serviceCollection.AddOptions();
            serviceCollection.Configure<AbcSettings>(configuration.GetSection("Configuration"));

            serviceCollection.AddTransient<App>();
        }
    }
}
