using System;
using System.Net;
using System.Text;
using AbcScraper.Core.Contracts;
using AbcScraper.Core.Extensions;
using AbcScraper.Core.Settings;

namespace AbcScraper.Core.Services
{
    internal class GoogleService : ProviderContract, IDisposable
    {
        readonly WebClient _client;
        internal GoogleService(WebClient client)
        {
            _client = client;
        }

        internal override string DownloadUrlData(string keyWord, int pageNumbers, string lookupurl)
        {
            try
            {
                var url = new StringBuilder(Scraper.RegexPattern.GOOGLE_URL_FILTER);
                string downloadUrl = url.Replace(KEYWORD, keyWord)
                                             .Replace(NUMBERS, pageNumbers.ToString()).ToString();
                _client.Headers.Set(HttpRequestHeader.Host, Scraper.RegexPattern.GOOGLE_URL);
                string urlData = _client.DownloadString(downloadUrl);
                return urlData.GetUrlPositions(lookupurl, Scraper.RegexPattern.GOOGLE_URL_PATTERN);
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
            }
        }

    }
}
