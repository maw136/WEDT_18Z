using Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tokenizer
{
    public class Tokenizer : ITokenizer
    {
        private readonly string _content;
        private static readonly Regex _tokenizingRegex = new Regex("\\w+");

        public Tokenizer(string content)
        {
            _content = content;
        }

        public IEnumerable<string> Tokenize()
        {
            var matches = _tokenizingRegex.Matches(_content);
            foreach (Match match in matches)
            {
                yield return match.Value;
            }
        }
    }
}
