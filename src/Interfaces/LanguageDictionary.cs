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

        public LanguageDictionary() {
            this.Internal = new Dictionary<string, int>();
        }

        public Language Langauge { get; set; }

        public Dictionary<string, int> Internal { get; set; }
    }
}
