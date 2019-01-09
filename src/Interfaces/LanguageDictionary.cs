using System.Collections.Generic;

namespace Interfaces
{
    /// <summary>
    /// Słownik dla pojedynczego języka
    /// </summary>
    public class LanguageDictionary
{
        //
        ///
        public Language Langauge { get; set; }

        private Dictionary<string, int> _internal;
    }
}
