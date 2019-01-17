﻿using System.Collections.Generic;
using Interfaces;
using System;
using System.Linq;

namespace Analizers
{
    public class Alg2Analizer : IAnalizer
    {
        private IEnumerable<LanguageDictionary> languageDictionaries { get; set; }

        public Alg2Analizer(string basePath) {
            List<Tuple<string, Language>> pathsAndLanguages = new List<Tuple<string, Language>>();
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/english.txt", Language.English));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/polish.txt", Language.Polish));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/german.txt", Language.German));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/spanish.txt", Language.Spanish));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/portugese.txt", Language.Portuguese));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/italian.txt", Language.Italian));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/french.txt", Language.French));

            LanguageDictionaryFactory factory = new LanguageDictionaryFactory();
            this.languageDictionaries = factory.Create(pathsAndLanguages);
        }

        public Alg2Analizer(IEnumerable<LanguageDictionary> languageDictionaries) {
            this.languageDictionaries = languageDictionaries;
        }

        public Analysis Analize(string document) {
            ITokenizer tokenizer = new Tokenizer.Tokenizer(document);
            IEnumerable<string> tokens = tokenizer.Tokenize();

            Analysis analysis = new Analysis();
            foreach (string token in tokens) {
                foreach (LanguageDictionary dict in languageDictionaries) {
                    if (dict.Internal.ContainsKey(token)) {
                        if (!analysis.analysisMap.ContainsKey(dict.Langauge)) {
                            analysis.analysisMap.Add(dict.Langauge, 0.0d);
                        }
                        analysis.analysisMap[dict.Langauge] += dict.Internal[token];
                    }
                }
            }
            return analysis;
        }

        public Analysis Analize(string document, int tokenLimit) {
            ITokenizer tokenizer = new Tokenizer.Tokenizer(document);
            IEnumerable<string> tokens = tokenizer.Tokenize();

            Analysis analysis = new Analysis();
            foreach (string token in tokens) {
                foreach (LanguageDictionary dict in languageDictionaries) {
                    if (dict.Internal.ContainsKey(token)) {
                        if (!analysis.analysisMap.ContainsKey(dict.Langauge)) {
                            analysis.analysisMap.Add(dict.Langauge, 0.0d);
                        }
                        analysis.analysisMap[dict.Langauge] += dict.Internal[token];
                    }
                }

                if(tokenLimit-- == 0)  {
                    break;
                }
            }
            return analysis;
        }
    }
}
