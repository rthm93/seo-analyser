using SeoAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities.Interfaces
{
    public interface ISeoAnalyser
    {
        /// <summary>
        /// Performs SEO analysis.
        /// </summary>
        /// <param name="request">Analyse request.</param>
        /// <returns>Returns analyse results.</returns>
        Task<AnalysisResult> Analyse(AnalyseRequest request);
    }
}