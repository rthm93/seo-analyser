using HtmlAgilityPack;
using SeoAnalyser.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities
{
    public class MetaAnalyser : IMetaAnalyser
    {
        /// <summary>
        /// Get words from title, description meta tag and keywords meta tag.
        /// </summary>
        /// <param name="html">Raw HTML text.</param>
        /// <returns>Returns keywords from meta tags.</returns>
        public Task<List<string>> GetMetaData(string html)
        {
            var result = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            IEnumerable<HtmlNode> metaTags = (doc.DocumentNode.SelectNodes("//meta") as IEnumerable<HtmlNode> ?? new HtmlNode[] { });
            metaTags = metaTags.Concat(doc.DocumentNode.SelectNodes("//title") as IEnumerable<HtmlNode> ?? new HtmlNode[] { });

            foreach (var metaTag in metaTags)
            {
                if (metaTag.Name.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    result.AddRange(metaTag.InnerText.Split(WordAnalyser.WordSeparators));
                }
                else if (metaTag.Name.Equals("meta", StringComparison.OrdinalIgnoreCase) && (metaTag.Attributes["name"]?.Value ?? "").Equals("keywords"))
                {
                    result.AddRange((metaTag.Attributes["content"]?.Value ?? "").Split(new char[] { ',' }));
                }
                else if (metaTag.Name.Equals("meta", StringComparison.OrdinalIgnoreCase) && (metaTag.Attributes["name"]?.Value ?? "").Equals("description"))
                {
                    result.AddRange((metaTag.Attributes["content"]?.Value ?? "").Split(WordAnalyser.WordSeparators));
                }
            }

            return Task.FromResult(WordAnalyser.PreprocessStrings(result));
        }
    }
}