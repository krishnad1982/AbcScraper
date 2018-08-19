using AbcScraper.Core;

namespace AbcScraper.Configuration
{
    public class ScraperSettings
    {
        public Provider Provider
        {
            get;
            set;
        }
        public string[] SearchKeyWords
        {
            get;
            set;
        }
        public int PageNumbers
        {
            get;
            set;
        }
    }
}
