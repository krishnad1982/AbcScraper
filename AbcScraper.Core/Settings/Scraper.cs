using System;
namespace AbcScraper.Core.Settings
{
    public static class Scraper
    {
        public static class RegexPattern
        {
            public const string GOOGLE_URL = "www.google.com";
            public const string GOOGLE_URL_FILTER = "https://www.google.com/search?q=keyword&num=numbers";
            public const string GOOGLE_URL_PATTERN = @"(?<=<h3 class=\""r\""><a href=\""\/url\?q=)(.*?)(?=&amp;)";
        }
    }
}
