using System.Collections.Generic;
using AbcScraper.Core.Models;

namespace AbcScraper.Core.Contracts
{
    public interface IScraperService
    {
        List<ScraperResult> GetUrlPosition(string[] keyWords, int pageNumbers, Provider provider, string lookupUrl);
    }
}
