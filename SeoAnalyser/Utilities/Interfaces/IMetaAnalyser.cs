using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities.Interfaces
{
    public interface IMetaAnalyser
    {
        /// <summary>
        /// Get words from title, description meta tag and keywords meta tag.
        /// </summary>
        /// <param name="html">Raw HTML text.</param>
        /// <returns>Returns keywords from meta tags.</returns>
        Task<List<string>> GetMetaData(string html);
    }
}