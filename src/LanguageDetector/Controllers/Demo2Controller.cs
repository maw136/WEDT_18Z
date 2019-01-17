using System;
using System.Collections.Generic;
using System.Text;
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
            _translateServiceClient.DetectLanguage(article.Content);
        }
    }
}
