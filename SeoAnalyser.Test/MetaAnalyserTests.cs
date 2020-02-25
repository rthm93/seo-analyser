using SeoAnalyser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeoAnalyser.Test
{
    public class MetaAnalyserTests
    {
        [Fact]
        public async Task GetMetaData_GetTitleFromHtml_Success()
        {
            var html = $@"
<html>
<head>
<title>Asdf Website</title>
</head>
<body>
<h1>Title</h1>
<div>
</body>
</html>
";
            var expected = new List<string> { "asdf", "website" };

            var result = await new MetaAnalyser().GetMetaData(html);

            AssertResults(expected, result);
        }

        [Fact]
        public async Task GetMetaData_GetWordsFromDescriptionMetaTag_Success()
        {
            var html = $@"
<html>
<head>
<meta name=""description"" content=""Free Web Site"" />
</head>
<body>
<h1>Title</h1>
<div>
</body>
</html>
";
            var expected = new List<string> { "free", "web" , "site" };

            var result = await new MetaAnalyser().GetMetaData(html);

            AssertResults(expected, result);
        }

        [Fact]
        public async Task GetMetaData_GetWordsFromKeywordsMetaTag_Success()
        {
            var html = $@"
<html>
<head>
<meta name=""keywords"" content=""HTML,CSS,XML,JavaScript"" />
</head>
<body>
<h1>Title</h1>
<div>
</body>
</html>
";
            var expected = new List<string> { "html", "css", "xml", "javascript" };

            var result = await new MetaAnalyser().GetMetaData(html);

            AssertResults(expected, result);
        }

        private void AssertResults(List<string> expected, List<string> result)
        {

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expected.Count, result.Count);
            Assert.Contains(result, r => expected.Any(e => e.Equals(r)));
        }
    }
}
