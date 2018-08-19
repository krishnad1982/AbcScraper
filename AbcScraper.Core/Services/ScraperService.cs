using System.Collections.Generic;
using System.Net;
using AbcScraper.Core.Contracts;
using AbcScraper.Core.Extensions;
using AbcScraper.Core.Models;

namespace AbcScraper.Core.Services
{
    public class ScraperService : IScraperService
    {
        public List<ScraperResult> GetUrlPosition(string[] keyWords, int pageNumbers, Provider provider, string lookupUrl)
        {
            var client = new WebClient();
            var finalResult = new List<ScraperResult>();
            foreach (var keyWord in keyWords)
            {
                string result = client.FetchProvider(provider).DownloadUrlData(keyWord, pageNumbers, lookupUrl);
                finalResult.Add(new ScraperResult
                {
                    Keyword = keyWord,
                    Positions = result
                });
            }
            return finalResult;
        }
    }
}
