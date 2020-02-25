using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities.Interfaces
{
    public interface IMetaAnalyser
    {
        Task<List<string>> GetMetaData(string html);
    }
}