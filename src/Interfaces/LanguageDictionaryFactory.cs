using System.Collections.Generic;
using System.Linq;

namespace Interfaces
{
    public class LanguageDictionaryFactory
    {        
        public IEnumerable<LanguageDictionary> Create(IEnumerable<string> paths)
        {
            return Enumerable.Empty<LanguageDictionary>();
        }
    }
}
