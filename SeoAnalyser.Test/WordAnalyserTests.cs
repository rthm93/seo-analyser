using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SeoAnalyser.Utilities;

namespace SeoAnalyser.Test
{
    public class WordAnalyserTests
    {
        [Fact]
        public async Task CalculateOccurrences_CalculateWordsCorrectly_Success()
        {
            var expectedResults = new Dictionary<string, int>
            {
                { "me", 2 },
                { "you", 1 },
                { "i", 2 },
            };

            var result = await new WordAnalyser().CalculateOccurrences(new List<string> {"me","me","you","i","i"}, new List<string> { "me", "you", "i" });

            foreach(var kv in result)
            {
                Assert.Equal(expectedResults[kv.Key], kv.Value);
            }
        }

        [Fact]
        public async Task SplitWords_SplitWordsWithoutRemovingStopWords_SplittedCorrectly()
        {
            var input = "This is something.";
            var result = await new WordAnalyser().SplitWords(input, false);
            var expectedResult = new string[] { "this", "is", "something" };

            Assert.Equal(expectedResult.Length, result.Count);
            Assert.Contains(result, s => expectedResult.Any(expected => s.Equals(expected)));
        }

        [Fact]
        public async Task SplitWords_SplitWordsWithStopWordsRemoved_SplittedCorrectly()
        {
            var input = "This is lovely text and text again.";
            var result = await new WordAnalyser().SplitWords(input, true);
            var expectedResult = new string[] { "lovely", "text", "text" };

            Assert.Equal(expectedResult.Length, result.Count);
            Assert.Contains(result, s => expectedResult.Any(expected => s.Equals(expected)));
        }
    }
}
