using System;
using System.Collections.Generic;
using Interfaces;

namespace Analizers
{
    public class Alg1Analizer : IAnalizer
    {
        private IEnumerable<LanguageDictionary> languageDictionaries { get; set; }
        private ITokenizer tokenizer { get; set; }

        public Alg1Analizer() {
            List<Tuple<string, Language>> pathsAndLanguages = new List<Tuple<string, Language>>();
            pathsAndLanguages.Add(Tuple.Create("../../words_base/english.txt", Language.English));
            pathsAndLanguages.Add(Tuple.Create("../../words_base/polish.txt", Language.Polish));
            pathsAndLanguages.Add(Tuple.Create("../../words_base/german.txt", Language.German));
            pathsAndLanguages.Add(Tuple.Create("../../words_base/spanish.txt", Language.Spanish));
            pathsAndLanguages.Add(Tuple.Create("../../words_base/portugese.txt", Language.Portuguese));
            pathsAndLanguages.Add(Tuple.Create("../../words_base/italian.txt", Language.Italian));
            pathsAndLanguages.Add(Tuple.Create("../../words_base/french.txt", Language.French));
            
            LanguageDictionaryFactory factory = new LanguageDictionaryFactory();
            this.languageDictionaries = factory.Create(pathsAndLanguages);
            // TODO assign tokenizer
        }

        public Alg1Analizer(IEnumerable<LanguageDictionary> languageDictionaries,
                            ITokenizer tokenizer) {
            this.languageDictionaries = languageDictionaries;
            this.tokenizer = tokenizer;
        }

        public Analysis Analize(string document) {
            // TODO get via page service
            // TODO IEnumerable<string> tokens = tokenizer.Tokenize(document);
            Analysis analysis = new Analysis();
            string[] tokens = {"do", "think", "a", "I", "am"};
            foreach (string token in tokens) {
                foreach (LanguageDictionary dict in languageDictionaries) {
                    if (dict.Internal.ContainsKey(token)) {
                        if (!analysis.analysisMap.ContainsKey(dict.Langauge)) {
                            analysis.analysisMap.Add(dict.Langauge, 0.0d);
                        }

                        analysis.analysisMap[dict.Langauge] += 1;
                    }
                }
            }
            return analysis;
        }
    }
}
