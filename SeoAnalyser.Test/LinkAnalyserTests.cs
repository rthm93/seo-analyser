using SeoAnalyser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeoAnalyser.Test
{
    public class LinkAnalyserTests
    {
        [Fact]
        public async Task GetExternalLinks_GetLinksFromHtml_Success()
        {
            const string googleUrl = "https://www.google.com";
            var html = $@"
<html>
</head>
<head>
<body>
<h1>Title</h1>
<div>
<a href=""{googleUrl}"">Google</a>
</body>
</html>
";
            var result = await new LinkAnalyser().GetExternalLinks(html);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(googleUrl, result.First());
        }
    }
}
