using System.Collections.Generic;

namespace Interfaces
{
    public class Analysis
    {
        /// <summary>
        /// język -> częstotliwość ze względu na algorytm (szansa)
        /// </summary>

        public Dictionary<Language, double> analysisMap { get; set; }      

        public Language GetDiscoveredLanguage() {
            Language discoveredLanguage = Language.Unknown;
            double discoveredLanguageProb = 0;
            foreach (Language lang in analysisMap.Keys) {
                double value = 0.0d;
                if (analysisMap.TryGetValue(lang, out value) &&
                    value > discoveredLanguageProb) {
                        discoveredLanguageProb = value;
                        discoveredLanguage = lang;
                }
            }
            return discoveredLanguage;
        }
    }
}
