using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AbcScraper.Core.Extensions
{
    internal static class StringExtension
    {
        public static string GetUrlPositions(this string data, string lookupUrl, string regPattern)
        {
            var regex = new Regex(regPattern);
            List<string> finalResult = new List<string>();
            int count = 0;
            MatchCollection collection = regex.Matches(data);
            var urlNames = collection.Cast<Match>().Select(url => url.Value).ToList();
            foreach (var url in urlNames)
            {
                count++;
                if (url.Contains(lookupUrl))
                {
                    finalResult.Add(count.ToString());
                }
            }
            return string.Join("", finalResult);
        }
    }
}
