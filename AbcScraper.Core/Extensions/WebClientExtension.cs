using System;
using System.Net;
using AbcScraper.Core.Contracts;
using AbcScraper.Core.Services;

namespace AbcScraper.Core.Extensions
{
    internal static class WebClientExtension
    {
        internal static ProviderContract FetchProvider(this WebClient client, Provider provider)
        {
            switch (provider)
            {
                case Provider.Google:
                    return new GoogleService(client);
                default:
                    throw new ArgumentException(nameof(provider));
            }
        }
    }
}
