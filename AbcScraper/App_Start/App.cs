using System;
using System.Collections.Generic;
using AbcScraper.Configuration;
using AbcScraper.Core.Contracts;
using AbcScraper.Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AbcScraper
{
    public class App
    {
        readonly IScraperService _scraperService;
        readonly ILogger<App> _logger;
        readonly AbcSettings _config;
        public App(IScraperService scraperService, IOptions<AbcSettings> config, ILogger<App> logger)
        {
            _config = config?.Value;
            _scraperService = scraperService;
            _logger = logger;
        }

        public string LookUpUrl => _config.LookUpUrl;

        public void Run()
        {
            if (!string.IsNullOrEmpty(IsValid(_config)))
            {
                return;
            }
            try
            {
                Dictionary<string, List<ScraperResult>> result = new Dictionary<string, List<ScraperResult>>();
                foreach (var scraper in _config.ScraperSettings)
                {
                    result.TryAdd(scraper.Provider.ToString(), _scraperService.GetUrlPosition(scraper.SearchKeyWords,
                                                    scraper.PageNumbers, scraper.Provider, LookUpUrl));
                }

                foreach (KeyValuePair<string, List<ScraperResult>> entry in result)
                {
                    Console.WriteLine($"Result for provider: {entry.Key}");

                    foreach (var scrapeResult in entry.Value)
                    {
                        var Positions = string.IsNullOrEmpty(scrapeResult.Positions) ? "0" : scrapeResult.Positions;
                        Console.WriteLine($"Total number of positions: {Positions} for the keyword: {scrapeResult.Keyword}");
                    }
                    Console.WriteLine($".............End Provider: {entry.Key}....................");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
            }
        }

        public string IsValid(AbcSettings config)
        {
            if (string.IsNullOrEmpty(config.LookUpUrl))
            {
                return "Please provide lookup url";
            }
            if (config.ScraperSettings.Count == 0)
            {
                return "Please configure provider settings";
            }
            return string.Empty;
        }
    }
}
