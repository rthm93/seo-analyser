using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities.Interfaces
{
    public interface IWordAnalyser
    {
        Task<List<string>> SplitWords(string input, bool isRemoveStopWords);

        Task<Dictionary<string, int>> CalculateOccurrences(List<string> splittedInput, List<string> wordsToCount);
    }
}