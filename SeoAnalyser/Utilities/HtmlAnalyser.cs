using HtmlAgilityPack;
using SeoAnalyser.Models;
using SeoAnalyser.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SeoAnalyser.Utilities
{
    public class HtmlAnalyser : ISeoAnalyser
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly ILinkAnalyser linkAnalyser;
        private readonly IMetaAnalyser metaAnalyser;
        private readonly IWordAnalyser wordAnalyser;

        public HtmlAnalyser(ILinkAnalyser linkAnalyser, IMetaAnalyser metaAnalyser, IWordAnalyser wordAnalyser)
        {
            this.linkAnalyser = linkAnalyser;
            this.metaAnalyser = metaAnalyser;
            this.wordAnalyser = wordAnalyser;
        }

        public async Task<AnalysisResult> Analyse(AnalyseRequest request)
        {
            var result = new AnalysisResult(request);
            var response = await httpClient.GetAsync(request.Input);

            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                var splittedString = await wordAnalyser.SplitWords(doc.DocumentNode.SelectNodes("//body")?.FirstOrDefault()?.InnerText ?? "", request.IsRemoveStopWords);
                result.WordsAndCount = await wordAnalyser.CalculateOccurrences(splittedString, splittedString.Distinct().ToList());

                if (request.IsCalculateKeywordsInMetaTags)
                {
                    var wordsInMetaTags = await metaAnalyser.GetMetaData(html);
                    result.WordsInMetaTagsAndCount = await wordAnalyser.CalculateOccurrences(splittedString, wordsInMetaTags);
                }

                if (request.IsCalculateNumberOfExternalLinks)
                {
                    result.ExternalLinks = await linkAnalyser.GetExternalLinks(html);
                }
            }

            return result;
        }
    }
}