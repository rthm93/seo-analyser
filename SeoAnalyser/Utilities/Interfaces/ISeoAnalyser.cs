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
        Task<AnalysisResult> Analyse(AnalyseRequest request);
    }
}