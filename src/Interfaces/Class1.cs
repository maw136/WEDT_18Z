using System;

namespace Interfaces
{
    public class Token
    {
        public string Word { get; set; }
        /// <summary>
        /// Count/1000000
        /// </summary>
        public int Frequency { get; set; }
    }

    public enum Lanugage
    {
        English,
        Polish,
        //......
    }

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

    public class LanguagesMap
    {

    }


    public interface IParser
    {

    }
}
