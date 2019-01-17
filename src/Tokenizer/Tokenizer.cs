using Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tokenizer
{
    public class Tokenizer : ITokenizer
    {
        private static readonly Regex _tokenizingRegex = new Regex("\\w+");

        public IEnumerable<string> Tokenize(string content)
        {
            var matches = _tokenizingRegex.Matches(content);
            foreach (Match match in matches)
            {
                yield return match.Value;
            }
        }
    }
}
