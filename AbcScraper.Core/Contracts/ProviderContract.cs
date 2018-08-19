using System;
using System.Net;

namespace AbcScraper.Core.Contracts
{
    internal abstract class ProviderContract
    {
        internal const string KEYWORD = "keyword";
        internal const string NUMBERS = "numbers";

        internal abstract string DownloadUrlData(string keyWord, int pageNumbers, string lookupurl);
    }
}
