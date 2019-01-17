using System.IO;
using System.Text;
using Interfaces;
using Analizers;
using System.Collections.Generic;
using System;
using PageService;
using PageService.EuroNews;
using System.Threading.Tasks;
using GoogleTranslateApiClient;

namespace Comparisons
{
    public class ComparisonCreator
    {
        private IEnumerable<LanguageDictionary> languageDictionaries;
        private Dictionary<Language, string> pathsToArticles;
        private List<Tuple<string, Language>> pathsToDictionaries;

        private Dictionary<string, Article> urlsToArticles;

        public ComparisonCreator(string basePath) {
            pathsToDictionaries = new List<Tuple<string, Language>>();
            pathsToDictionaries.Add(Tuple.Create($"{basePath}/words_base/english.txt", Language.English));
            pathsToDictionaries.Add(Tuple.Create($"{basePath}/words_base/polish.txt", Language.Polish));
            pathsToDictionaries.Add(Tuple.Create($"{basePath}/words_base/german.txt", Language.German));
            pathsToDictionaries.Add(Tuple.Create($"{basePath}/words_base/spanish.txt", Language.Spanish));
            pathsToDictionaries.Add(Tuple.Create($"{basePath}/words_base/portugese.txt", Language.Portuguese));
            pathsToDictionaries.Add(Tuple.Create($"{basePath}/words_base/italian.txt", Language.Italian));
            pathsToDictionaries.Add(Tuple.Create($"{basePath}/words_base/french.txt", Language.French));

            LanguageDictionaryFactory factory = new LanguageDictionaryFactory();
            this.languageDictionaries = factory.Create(pathsToDictionaries);

            this.pathsToArticles = new Dictionary<Language, string>();
            pathsToArticles.Add(Language.English,    $"{basePath}/articles/english.txt");
            pathsToArticles.Add(Language.German,     $"{basePath}/articles/german.txt");
            pathsToArticles.Add(Language.French,     $"{basePath}/articles/french.txt");
            pathsToArticles.Add(Language.Spanish,    $"{basePath}/articles/spanish.txt");
            pathsToArticles.Add(Language.Portuguese, $"{basePath}/articles/portugese.txt");
            pathsToArticles.Add(Language.Italian,    $"{basePath}/articles/italian.txt");

            // NOT pathsToArticles.Add(Language.Polish, "../../articles/polish.txt");

            urlsToArticles = cacheArticles().Result;
        }

        private async Task<Dictionary<string, Article>> cacheArticles() {
            var download = new PageDownloadService();
            var euroNewsSite = new EuroNewsSite(new EuroNewsSiteParser(), download, new ExtendedRandom());

            Dictionary<string, Article> cachedArticles = new Dictionary<string, Article>();
            foreach (Language language in pathsToArticles.Keys) {
                Console.WriteLine("Caching for language {0}", language);
                string[] urls = System.IO.File.ReadAllLines(pathsToArticles[language]);
                foreach (string url in urls) {
                    Console.WriteLine("Caching URL {0}", url);
                    Article article = await euroNewsSite.GetArticleAsync(url, language);
                    article.ActualLanguage = language;
                    cachedArticles.Add(url, article);
                }
            }
            return cachedArticles;
        }

        // Porównuje algorytmy 1 i 2 w zależności od liczby tokenów w artykule dla podanego języka
        public void CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language analyzedLanguage) {
            string path = pathsToArticles[analyzedLanguage];
            int numberOfArticlesToAnalyze = 10;

            // Dla jakiej długości artykułów (liczba tokenów) chcemy wykonać analizę
            List<int> numberOfTokensToAnalyze = new List<int>();
            for (int i = 10; i <= 300; i += 10) {
                numberOfTokensToAnalyze.Add(i);
            }

            // Długość artykułu (liczba tokenów) - liczba poprawnych wykryć języka
            Dictionary<int, int> alg1SuccessfulDetection = new Dictionary<int, int>();
            Dictionary<int, int> alg2SuccessfulDetection = new Dictionary<int, int>();

            Alg1Analizer alg1 = new Alg1Analizer(languageDictionaries);
            Alg2Analizer alg2 = new Alg2Analizer(languageDictionaries);

            // Analizujemy dla różnych długości artykułów
            foreach (int tokensNumber in numberOfTokensToAnalyze) {
                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;

                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string url in lines) {
                    string content = urlsToArticles[url].Content;

                    // Algorytm 1
                    Analysis analysis = alg1.Analize(content, tokensNumber);
                    if (analysis.GetDiscoveredLanguage().Equals(analyzedLanguage)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Algorytm 2
                    Analysis analysis2 = alg2.Analize(content, tokensNumber);
                    if (analysis2.GetDiscoveredLanguage().Equals(analyzedLanguage)) {
                        alg2SuccessfulDetectionCount++;
                    }
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
            for (int i = 20; i <= 1000; i += 20) {
                dictionariesSizeToAnalyze.Add(i);
            }

            // Wielkość słownika - liczba poprawnych wykryć języka
            Dictionary<int, int> alg1SuccessfulDetection = new Dictionary<int, int>();
            Dictionary<int, int> alg2SuccessfulDetection = new Dictionary<int, int>();

            LanguageDictionaryFactory factory = new LanguageDictionaryFactory();
            foreach (int dictionarySize in dictionariesSizeToAnalyze) {
                IEnumerable<LanguageDictionary> dictionaries = factory.Create(pathsToDictionaries, dictionarySize);
                Alg1Analizer alg1 = new Alg1Analizer(dictionaries);
                Alg2Analizer alg2 = new Alg2Analizer(dictionaries);
                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;

                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string url in lines) {
                    string content = urlsToArticles[url].Content;

                    // Algorytm 1
                    Analysis analysis = alg1.Analize(content);
                    if (analysis.GetDiscoveredLanguage().Equals(analyzedLanguage)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Algorytm 2
                    Analysis analysis2 = alg2.Analize(content);
                    if (analysis2.GetDiscoveredLanguage().Equals(analyzedLanguage)) {
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
            Dictionary<Language, int> googleSuccessfulDetection = new Dictionary<Language, int>();
            Alg1Analizer alg1 = new Alg1Analizer(languageDictionaries);
            Alg2Analizer alg2 = new Alg2Analizer(languageDictionaries);
            TranslateServiceClient translateServiceClient = new TranslateServiceClient();

            foreach (Language language in pathsToArticles.Keys) {
                int alg1SuccessfulDetectionCount = 0;
                int alg2SuccessfulDetectionCount = 0;
                int googleSuccessfulDetectionCount = 0;
                int numberOfArticlesToAnalyze = 10;

                string path = pathsToArticles[language];
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string url in lines) {
                    string content = urlsToArticles[url].Content;
                    content = content.Substring(0, content.Length/10);

                    // Algorytm 1
                    Analysis analysis = alg1.Analize(content);
                    if (analysis.GetDiscoveredLanguage().Equals(language)) {
                        alg1SuccessfulDetectionCount++;
                    }

                    // Algorytm 2
                    Analysis analysis2 = alg2.Analize(content);
                    if (analysis2.GetDiscoveredLanguage().Equals(language)) {
                        alg2SuccessfulDetectionCount++;
                    }

                    Console.WriteLine("Google: {0}", url);

                    Language googleLanguage = translateServiceClient.DetectLanguage(content);
                    if (googleLanguage.Equals(language)) {
                        googleSuccessfulDetectionCount++;
                    }
                }
                alg1SuccessfulDetection.Add(language, alg1SuccessfulDetectionCount);
                alg2SuccessfulDetection.Add(language, alg2SuccessfulDetectionCount);
                googleSuccessfulDetection.Add(language, googleSuccessfulDetectionCount);
            }

            string csvPath = "../../comparisons/alg_comparison_all_lang.csv";
            if (!File.Exists(csvPath)) {
                File.Create(csvPath).Close();
            }
            using (TextWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8)) {
                writer.WriteLine("Porównanie algorytmów 1 i 2 - wszystkie języki;;;;;;;");
                writer.WriteLine(";EN;DE;FR;ES;PT;IT");
                writer.WriteLine("Alg. 1;" + alg1SuccessfulDetection[Language.English] + ";"
                + alg1SuccessfulDetection[Language.German] + ";"
                // + alg1SuccessfulDetection[Language.Polish] + ";"
                + alg1SuccessfulDetection[Language.French] + ";"
                + alg1SuccessfulDetection[Language.Spanish] + ";"
                + alg1SuccessfulDetection[Language.Portuguese] + ";"
                + alg1SuccessfulDetection[Language.Italian]);

                writer.WriteLine("Alg. 2;" + alg2SuccessfulDetection[Language.English] + ";"
                + alg2SuccessfulDetection[Language.German] + ";"
                // + alg2SuccessfulDetection[Language.Polish] + ";"
                + alg2SuccessfulDetection[Language.French] + ";"
                + alg2SuccessfulDetection[Language.Spanish] + ";"
                + alg2SuccessfulDetection[Language.Portuguese] + ";"
                + alg2SuccessfulDetection[Language.Italian]);

                writer.WriteLine("Google API;" + googleSuccessfulDetection[Language.English] + ";"
                + googleSuccessfulDetection[Language.German] + ";"
                // + alg2SuccessfulDetection[Language.Polish] + ";"
                + googleSuccessfulDetection[Language.French] + ";"
                + googleSuccessfulDetection[Language.Spanish] + ";"
                + googleSuccessfulDetection[Language.Portuguese] + ";"
                + googleSuccessfulDetection[Language.Italian]);
            }
        }
    }
}
