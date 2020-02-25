using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities.Interfaces
{
    public interface ILinkAnalyser
    {
        Task<List<string>> GetExternalLinks(string html);
    }
}