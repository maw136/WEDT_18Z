using System.IO;
using System.Text;
using Interfaces;
using Analizers;
using System.Collections.Generic;
using System;

namespace ComparisonTests
{
    public class ComparisonCreator
    {
        public void CreateArticleLengthComparison(IEnumerable<LanguageDictionary> languageDictionaries) {
            string articlesPath = "../../articles/english.txt";          
            List<int> values = new List<int>();
            for (int i = 100; i <= 1000; i += 100) {
                values.Add(i);
            }

            // Number of words to successful detection
            Dictionary<int, int> alg1SuccessfulDetection = new Dictionary<int, int>();
            Dictionary<int, int> alg2SuccessfulDetection = new Dictionary<int, int>();

            Alg1Analizer alg1 = new Alg1Analizer(languageDictionaries);
            Alg2Analizer alg2 = new Alg2Analizer(languageDictionaries);
            foreach (int i in values) {
                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;

                string[] lines = System.IO.File.ReadAllLines(articlesPath);
                foreach (string url in lines) {
                    // TODO foreach article shorten to i tokens

                    // Alg 1
                    Analysis analysis = alg1.Analize(null); // TODO pass tokenizer and article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysis));
                    if (analysis.GetDiscoveredLanguage().Equals(Language.English)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Alg 2
                    Analysis analysis2 = alg2.Analize(null); // TODO pass tokenizer and article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysi));
                    if (analysis2.GetDiscoveredLanguage().Equals(Language.English)) {
                        alg2SuccessfulDetectionCount++;
                    }
                }
                alg1SuccessfulDetection.Add(i, alg1SuccessfulDetectionCount);
                alg2SuccessfulDetection.Add(i, alg2SuccessfulDetectionCount);
            }

            string path = "../../article_length_comparison.csv";
            if (!File.Exists(path)) {
                File.Create(path);
            }
            TextWriter writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine("Porównanie algorytmów 1 i 2 dla różnych długości artykułów dla języka: EN;;;;;;;");
            writer.WriteLine(";Alg. 1; Alg. 2;;;;;");
            foreach (int i in values) {
                writer.WriteLine(i + ";" + alg1SuccessfulDetection[i] + ";" + alg2SuccessfulDetection[i]);
            }
            writer.Close();
        }

public void CreateDictionaryLengthComparison(IEnumerable<LanguageDictionary> languageDictionaries) {
            string articlesPath = "../../articles/english.txt";          
            List<int> values = new List<int>();
            for (int i = 100; i <= 3000; i += 100) {
                values.Add(i);
            }

            LanguageDictionary englishDictionary;
            foreach (LanguageDictionary dictionary in languageDictionaries) {
                if (dictionary.Langauge.Equals(Language.English)) {
                    englishDictionary = dictionary;
                }
            } 

            // List<Tuple<Article, Analysis>> articlesWithAnalysisList = new List<Tuple<Article, Analysis>>();
            // Number of words to successful detection
            Dictionary<int, int> alg1SuccessfulDetection = new Dictionary<int, int>();
            Dictionary<int, int> alg2SuccessfulDetection = new Dictionary<int, int>();

            Alg1Analizer alg1 = new Alg1Analizer(languageDictionaries);
            Alg2Analizer alg2 = new Alg2Analizer(languageDictionaries);
            foreach (int i in values) {
                // Read dictionary in factory giving i as a param
                // LanguageDictionary shortenedEnglishDictionary = englishDictionary.Internal.Keys;

                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;

                string[] lines = System.IO.File.ReadAllLines(articlesPath);
                foreach (string url in lines) {
                    
                    // TODO foreach article shorten dictionary to 

                    // Alg 1
                    Analysis analysis = alg1.Analize(null); // TODO pass tokenizer and article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysis));
                    if (analysis.GetDiscoveredLanguage().Equals(Language.English)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Alg 2
                    Analysis analysis2 = alg2.Analize(null); // TODO pass tokenizer and article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysi));
                    if (analysis2.GetDiscoveredLanguage().Equals(Language.English)) {
                        alg2SuccessfulDetectionCount++;
                    }
                }
                alg1SuccessfulDetection.Add(i, alg1SuccessfulDetectionCount);
                alg2SuccessfulDetection.Add(i, alg2SuccessfulDetectionCount);
            }

            string path = "../../dictionary_length_comparison.csv";
            if (!File.Exists(path)) {
                File.Create(path);
            }
            TextWriter writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine("Porównanie algorytmów 1 i 2 dla różnych długości słownika dla języka: EN;;;;;;;");
            writer.WriteLine(";Alg. 1; Alg. 2;;;;;");
            foreach (int i in values) {
                writer.WriteLine(i + ";" + alg1SuccessfulDetection[i] + ";" + alg2SuccessfulDetection[i]);
            }
            writer.Close();
        }

        // TODO po 10 artykułów w każdym
        public void CreateAlg1AndAlg2Comparison(IEnumerable<LanguageDictionary> languageDictionaries) {
            List<Tuple<string, Language>> pathsToArticles = new List<Tuple<string, Language>>();
            pathsToArticles.Add(Tuple.Create("../../articles/english.txt", Language.English));            
            // pathsToArticles.Add(Tuple.Create("../../articles/german.txt", Language.German)); 
            // pathsToArticles.Add(Tuple.Create("../../articles/polish.txt", Language.Polish));
            // pathsToArticles.Add(Tuple.Create("../../articles/french.txt", Language.French)); 
            // pathsToArticles.Add(Tuple.Create("../../articles/spanish.txt", Language.Spanish)); 
            // pathsToArticles.Add(Tuple.Create("../../articles/portugese.txt", Language.Portuguese)); 
            // pathsToArticles.Add(Tuple.Create("../../articles/italian.txt", Language.Italian)); 

            List<Tuple<Article, Analysis>> articlesWithAnalysisList = new List<Tuple<Article, Analysis>>();
            Dictionary<Language, int> alg1SuccessfulDetection = new Dictionary<Language, int>();
            Dictionary<Language, int> alg2SuccessfulDetection = new Dictionary<Language, int>();
            Alg1Analizer alg1 = new Alg1Analizer(languageDictionaries);
            Alg2Analizer alg2 = new Alg2Analizer(languageDictionaries);
            foreach (Tuple<string, Language> tuple in pathsToArticles) {
                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;
                int maxArticles = 10;
                string[] lines = System.IO.File.ReadAllLines(tuple.Item1);
                foreach (string url in lines) {
                    maxArticles--;
                    // TODO foreach line (URL) detect language
                    Article article = new Article(url, tuple.Item2);

                    // Alg 1
                    Analysis analysis = alg1.Analize(null); // TODO pass tokenizer and article
                    articlesWithAnalysisList.Add(Tuple.Create(article, analysis));
                    if (analysis.GetDiscoveredLanguage().Equals(article.lang)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Alg 2
                    Analysis analysis2 = alg2.Analize(null); // TODO pass tokenizer and article
                    // articlesWithAnalysisList.Add(Tuple.Create(article, analysi));
                    if (analysis2.GetDiscoveredLanguage().Equals(article.lang)) {
                        alg2SuccessfulDetectionCount++;
                    }

                    if (maxArticles == 0) {
                        break;
                    }
                }
                alg1SuccessfulDetection.Add(tuple.Item2, alg1SuccessfulDetectionCount);
                alg2SuccessfulDetection.Add(tuple.Item2, alg2SuccessfulDetectionCount);
            }

            string path = "../../alg_comparison.csv";
            if (!File.Exists(path)) {
                File.Create(path);
            }
            TextWriter writer = new StreamWriter(path, false, Encoding.UTF8);
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

            writer.Close();
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
