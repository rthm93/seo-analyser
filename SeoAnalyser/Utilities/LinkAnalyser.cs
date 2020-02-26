using HtmlAgilityPack;
using SeoAnalyser.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities
{
    public class LinkAnalyser : ILinkAnalyser
    {
        /// <summary>
        /// Get external links from raw html.
        /// </summary>
        /// <param name="html">Raw html.</param>
        /// <returns>Return html links.</returns>
        public Task<List<string>> GetExternalLinks(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var anchorTags = doc.DocumentNode.SelectNodes("//a");
            return Task.FromResult(anchorTags?.Select(n => n.Attributes["href"]?.Value).Where(text => !string.IsNullOrEmpty(text) && text.Trim().ToLower().StartsWith("http")).ToList() ?? new List<string>());
        }
    }
}