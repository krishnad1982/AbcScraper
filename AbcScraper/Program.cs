using AbcScraper.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AbcScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<App>().Run();
        }
    }
}
