using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeoAnalyser.Utilities.Interfaces
{
    public interface IWordAnalyser
    {
        /// <summary>
        /// Split string into a list of words to be further analysed.
        /// </summary>
        /// <param name="input">String to be analysed.</param>
        /// <param name="isRemoveStopWords">Should stop-word be removed?</param>
        /// <returns>List of words ready to be analysed.</returns>
        Task<List<string>> SplitWords(string input, bool isRemoveStopWords);

        /// <summary>
        /// Calculate occurences of words in splitted input.
        /// </summary>
        /// <param name="splittedInput">Splitted input from <see cref="WordAnalyser.SplitWords(string, bool)"/>.</param>
        /// <param name="wordsToCount">Words to calculate occurences.</param>
        /// <returns>Return word occurrences count.</returns>
        Task<Dictionary<string, int>> CalculateOccurrences(List<string> splittedInput, List<string> wordsToCount);
    }
}