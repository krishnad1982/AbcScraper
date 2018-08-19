using System.Collections.Generic;

namespace AbcScraper.Configuration
{
    public class AbcSettings
    {
        public string LookUpUrl
        {
            get;
            set;
        }
        public List<ScraperSettings> ScraperSettings
        {
            get;
            set;
        }
    }
}
