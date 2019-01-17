using System;
using System.Linq;
using Analizers;
using GoogleTranslateApiClient;
using Interfaces;
using PageService;

namespace LanguageDetector.Controllers
{
    public class Demo2Controller : IController
    {
        private readonly INewsArticleProvider _newsArticleProvider;
        private readonly TranslateServiceClient _translateServiceClient;

        public Demo2Controller(NewsArticleProviderFactory newsArticleProviderFactory, TranslateServiceClient translateServiceClient)
        {
            _newsArticleProvider = newsArticleProviderFactory.Create();
            _translateServiceClient = translateServiceClient;
        }

        public void Run(string basePath)
        {
            var task = _newsArticleProvider.GetNextArticleAsync();
            task.Wait();
            var article = task.Result;

            var alg1 = new Alg1Analizer(basePath);
            var alg2 = new Alg2Analizer(basePath);

            var analysis1 = alg1.Analize(article.Content);
            var analysis2 = alg2.Analize(article.Content);
            var googleDetected = _translateServiceClient.DetectLanguage(article.Content);

            Console.WriteLine("Article content:");
            Console.WriteLine(article.Content);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Actual lng: {article.ActualLanguage}");
            Console.WriteLine("Alg1 analysis:");
            PrintFullAnalysis(analysis1);
            Console.WriteLine("Alg2 analysis:");
            PrintFullAnalysis(analysis2);
            Console.WriteLine($"Google lng: {googleDetected}");
            Console.WriteLine("-----------------------------------------------");
        }

        private void PrintFullAnalysis(Analysis analysis)
        {
            var language = analysis.GetDiscoveredLanguage();
            Console.WriteLine($"Detected language: {language}");
            Console.WriteLine("-------");
            foreach (var entry in analysis.analysisMap.OrderByDescending(e=>e.Value))
            {
                Console.WriteLine($"Language: {entry.Key}, with confidence: {entry.Value}");
            }
            Console.WriteLine("-------");
        }
    }
}
