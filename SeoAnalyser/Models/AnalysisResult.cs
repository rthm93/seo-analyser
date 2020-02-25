using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoAnalyser.Models
{
    public class AnalysisResult : AnalyseRequest
    {
        public AnalysisResult(AnalyseRequest request)
        {
            Input = request.Input;
            IsRemoveStopWords = request.IsRemoveStopWords;
            IsCalculateKeywordsInMetaTags = request.IsCalculateKeywordsInMetaTags;
            IsCalculateNumberOfExternalLinks = request.IsCalculateNumberOfExternalLinks;
            IsCalculateOccurrencesOfEachWords = request.IsCalculateOccurrencesOfEachWords;
            ExternalLinks = new List<string>();
            WordsInMetaTagsAndCount = new Dictionary<string, int>();
            WordsAndCount = new Dictionary<string, int>();
        }

        public List<string> ExternalLinks { get; set; }
        public Dictionary<string, int> WordsInMetaTagsAndCount { get; set; }
        public Dictionary<string, int> WordsAndCount { get; set; }
    }
}