using System.Collections.Generic;

namespace Interfaces
{
    public interface ITokenizer
    {
        IEnumerable<string> Tokenize(string content);
    }
}
