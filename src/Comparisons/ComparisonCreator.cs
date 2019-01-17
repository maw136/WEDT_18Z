﻿using System.IO;
using System.Text;
using Interfaces;
using Analizers;
using System.Collections.Generic;
using System;

namespace Comparisons
{
    public class ComparisonCreator
    {
        private IEnumerable<LanguageDictionary> languageDictionaries;
        private Dictionary<Language, string> pathsToArticles;
        private List<Tuple<string, Language>> pathsToDictionaries;
        private ITokenizer tokenizer;

        public ComparisonCreator() {
            pathsToDictionaries = new List<Tuple<string, Language>>();
            pathsToDictionaries.Add(Tuple.Create("../../words_base/english.txt", Language.English));
            pathsToDictionaries.Add(Tuple.Create("../../words_base/polish.txt", Language.Polish));
            pathsToDictionaries.Add(Tuple.Create("../../words_base/german.txt", Language.German));
            pathsToDictionaries.Add(Tuple.Create("../../words_base/spanish.txt", Language.Spanish));
            pathsToDictionaries.Add(Tuple.Create("../../words_base/portugese.txt", Language.Portuguese));
            pathsToDictionaries.Add(Tuple.Create("../../words_base/italian.txt", Language.Italian));
            pathsToDictionaries.Add(Tuple.Create("../../words_base/french.txt", Language.French));
            
            LanguageDictionaryFactory factory = new LanguageDictionaryFactory();
            this.languageDictionaries = factory.Create(pathsToDictionaries);
        
            this.pathsToArticles = new Dictionary<Language, string>();
            pathsToArticles.Add(Language.English, "../../articles/english.txt");
            pathsToArticles.Add(Language.German, "../../articles/german.txt");
            pathsToArticles.Add(Language.Polish, "../../articles/polish.txt");
            pathsToArticles.Add(Language.French, "../../articles/french.txt");
            pathsToArticles.Add(Language.Spanish, "../../articles/spanish.txt");
            pathsToArticles.Add(Language.Portuguese, "../../articles/portugese.txt");
            pathsToArticles.Add(Language.Italian, "../../articles/italian.txt");
        }

        // Porównuje algorytmy 1 i 2 w zależności od liczby tokenów w artykule dla podanego języka
        public void CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language analyzedLanguage) {
            string path = pathsToArticles[analyzedLanguage];
            int numberOfArticlesToAnalyze = 10;

            // Dla jakiej długości artykułów (liczba tokenów) chcemy wykonać analizę
            List<int> numberOfTokensToAnalyze = new List<int>();
            for (int i = 100; i <= 1000; i += 100) {
                numberOfTokensToAnalyze.Add(i);
            }

            // Długość artykułu (liczba tokenów) - liczba poprawnych wykryć języka
            Dictionary<int, int> alg1SuccessfulDetection = new Dictionary<int, int>();
            Dictionary<int, int> alg2SuccessfulDetection = new Dictionary<int, int>();

            Alg1Analizer alg1 = new Alg1Analizer(languageDictionaries, tokenizer);
            Alg2Analizer alg2 = new Alg2Analizer(languageDictionaries, tokenizer);
            
            // Analizujemy dla różnych długości artykułów
            foreach (int tokensNumber in numberOfTokensToAnalyze) {
                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;

                Console.WriteLine("Path: {0} exists: {1}", path, System.IO.File.Exists(path));
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string url in lines) {
                    // TODO PageService getFromUrl
                    // TODO foreach article shorten to i tokens
                    // string[] tokens = {"do", "think", "I", "fix"};
                    
                    // Algorytm 1
                    Analysis analysis = alg1.Analize(""); // TODO pass article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysis));
                    if (analysis.GetDiscoveredLanguage().Equals(Language.English)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Algorytm 2
                    Analysis analysis2 = alg2.Analize(null); // TODO pass article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysi));
                    if (analysis2.GetDiscoveredLanguage().Equals(Language.English)) {
                        alg2SuccessfulDetectionCount++;
                    }
                    // Console.WriteLine("Analysis: " + analysis2.GetDiscoveredLanguage());
                }
                alg1SuccessfulDetection.Add(tokensNumber, alg1SuccessfulDetectionCount);
                alg2SuccessfulDetection.Add(tokensNumber, alg2SuccessfulDetectionCount);
            }

            string csvPath = "../../comparisons/article_length_comparison_" + analyzedLanguage.ToString() + ".csv";
            if (!File.Exists(csvPath)) {
                File.Create(csvPath).Close();
            }
            using (TextWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8)) {
                writer.WriteLine("Porównanie algorytmów 1 i 2 dla różnych długości artykułów (liczby tokenów) " +
                    " dla języka: {0}", analyzedLanguage);
                writer.WriteLine(";Alg. 1; Alg. 2");
                foreach (int i in numberOfTokensToAnalyze) {
                    writer.WriteLine(i + ";" + alg1SuccessfulDetection[i] + ";" + alg2SuccessfulDetection[i]);
                }
            }
        }

        // Porównuje algorytmy 1 i 2 dla podanego języka w zależności od liczby słów w słowniku
        public void CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language analyzedLanguage) {
            string path = pathsToArticles[analyzedLanguage];
            int numberOfArticlesToAnalyze = 10;       

            // Dla jakiej liczby wyrazów w słowniku chcemy wykonać analizę
            List<int> dictionariesSizeToAnalyze = new List<int>();
            for (int i = 100; i <= 3000; i += 100) {
                dictionariesSizeToAnalyze.Add(i);
            }

            // Wielkość słownika - liczba poprawnych wykryć języka
            Dictionary<int, int> alg1SuccessfulDetection = new Dictionary<int, int>();
            Dictionary<int, int> alg2SuccessfulDetection = new Dictionary<int, int>();

            LanguageDictionaryFactory factory = new LanguageDictionaryFactory();
            foreach (int dictionarySize in dictionariesSizeToAnalyze) {
                IEnumerable<LanguageDictionary> dictionaries = factory.Create(pathsToDictionaries, dictionarySize);
                Alg1Analizer alg1 = new Alg1Analizer(dictionaries, tokenizer);
                Alg2Analizer alg2 = new Alg2Analizer(dictionaries, tokenizer);
                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;

                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string url in lines) {
                    // TODO PageService getFromUrl
                    // TODO foreach article shorten to i tokens
                    // string[] tokens = {"do", "think", "I", "fix"};
                    
                    // Algorytm 1
                    Analysis analysis = alg1.Analize(""); // TODO pass article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysis));
                    if (analysis.GetDiscoveredLanguage().Equals(Language.English)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Algorytm 2
                    Analysis analysis2 = alg2.Analize(null); // TODO pass article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysi));
                    if (analysis2.GetDiscoveredLanguage().Equals(Language.English)) {
                        alg2SuccessfulDetectionCount++;
                    }
                }
                alg1SuccessfulDetection.Add(dictionarySize, alg1SuccessfulDetectionCount);
                alg2SuccessfulDetection.Add(dictionarySize, alg2SuccessfulDetectionCount);
            }

            string csvPath = "../../comparisons/dictionary_length_comparison_" + analyzedLanguage.ToString() + ".csv";
            if (!File.Exists(path)) {
                File.Create(path).Close();   
            }
            using (TextWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8)) {
                writer.WriteLine("Porównanie algorytmów 1 i 2 dla różnych długości słownika dla języka: " +
                    analyzedLanguage.ToString() + "");
                writer.WriteLine(";Alg. 1; Alg. 2");
                foreach (int dictionarySize in dictionariesSizeToAnalyze) {
                    writer.WriteLine(dictionarySize + ";" + alg1SuccessfulDetection[dictionarySize] + ";" + 
                        alg2SuccessfulDetection[dictionarySize]);
                }
            }             
        }

        // Porównanie efektywności algorytmów 1 i 2 dla wszystkich języków
        public void CreateComparisonOfAlgorithmEffectivenessForAllLanguages() {
            Dictionary<Language, int> alg1SuccessfulDetection = new Dictionary<Language, int>();
            Dictionary<Language, int> alg2SuccessfulDetection = new Dictionary<Language, int>();
            Alg1Analizer alg1 = new Alg1Analizer(languageDictionaries, tokenizer);
            Alg2Analizer alg2 = new Alg2Analizer(languageDictionaries, tokenizer);

            foreach (Language language in pathsToArticles.Keys) {
                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;
                int numberOfArticlesToAnalyze = 10;

                string path = pathsToArticles[language];
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string url in lines) {
                    // TODO foreach line (URL) detect language

                    // Algorytm 1
                    Analysis analysis = alg1.Analize(null); // TODO pass tokenizer and article
                    if (analysis.GetDiscoveredLanguage().Equals(language)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Algorytm 2
                    Analysis analysis2 = alg2.Analize(null); // TODO pass tokenizer and article
                    Console.WriteLine("Alg. 2: discovered lang {0}", analysis2.GetDiscoveredLanguage());
                    foreach (Language key in analysis2.analysisMap.Keys) {
                        Console.WriteLine("Alg. 2: key: {0} value: {1}", key, analysis2.analysisMap[key]);
                    }
                    if (analysis2.GetDiscoveredLanguage().Equals(language)) {
                        alg2SuccessfulDetectionCount++;
                    }
                }
                alg1SuccessfulDetection.Add(language, alg1SuccessfulDetectionCount);
                alg2SuccessfulDetection.Add(language, alg2SuccessfulDetectionCount);
            }

            string csvPath = "../../comparisons/alg_comparison_all_lang.csv";
            if (!File.Exists(csvPath)) {
                File.Create(csvPath).Close();
            }
            using (TextWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8)) {
                writer.WriteLine("Porównanie algorytmów 1 i 2 - wszystkie języki;;;;;;;");
                writer.WriteLine(";EN;DE;PL;FR;ES;PT;IT");
                writer.WriteLine("Alg. 1;" + alg1SuccessfulDetection[Language.English] + ";" 
                + alg1SuccessfulDetection[Language.German] + ";"
                + alg1SuccessfulDetection[Language.Polish] + ";"
                + alg1SuccessfulDetection[Language.French] + ";"
                + alg1SuccessfulDetection[Language.Spanish] + ";"
                + alg1SuccessfulDetection[Language.Portuguese] + ";"
                + alg1SuccessfulDetection[Language.Italian]);
                
                writer.WriteLine("Alg. 2;" + alg2SuccessfulDetection[Language.English] + ";" 
                + alg2SuccessfulDetection[Language.German] + ";"
                + alg2SuccessfulDetection[Language.Polish] + ";"
                + alg2SuccessfulDetection[Language.French] + ";"
                + alg2SuccessfulDetection[Language.Spanish] + ";"
                + alg2SuccessfulDetection[Language.Portuguese] + ";"
                + alg2SuccessfulDetection[Language.Italian]);
            }
        }

        private class Article {

            private string url {get; set;}

            public Language lang {get; set;}

            public Article(string url, Language lang) {
                this.url = url;
                this.lang = lang;
            }

        }

    }
}
