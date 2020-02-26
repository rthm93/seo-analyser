using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities.Interfaces
{
    public interface ILinkAnalyser
    {
        /// <summary>
        /// Get external links from raw html.
        /// </summary>
        /// <param name="html">Raw html.</param>
        /// <returns>Return html links.</returns>
        Task<List<string>> GetExternalLinks(string html);
    }
}