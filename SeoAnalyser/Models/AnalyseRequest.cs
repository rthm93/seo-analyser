using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeoAnalyser.Models
{
    public class AnalyseRequest
    {
        [Required]
        public string Input { get; set; }
        public bool IsRemoveStopWords { get; set; }
        public bool IsCalculateOccurrencesOfEachWords { get; set; }
        public bool IsCalculateKeywordsInMetaTags { get; set; }
        public bool IsCalculateNumberOfExternalLinks { get; set; }
    }
}