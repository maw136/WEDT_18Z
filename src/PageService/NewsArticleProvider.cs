using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Interfaces;

namespace PageService
{
    public class NewsArticleProvider
    {
        private static readonly Random _random;
        private IPageService _pageService;
        private SampleUrlProvider _sampleUrlProvider;

        static NewsArticleProvider()
        {
            var timestamp = Stopwatch.GetTimestamp();
            var hiBitsL = timestamp >> 32;
            int loBits = (int) timestamp;
            int hiBits = (int) hiBitsL;
            _random = new Random(loBits ^ hiBits);
        }

        public NewsArticleProvider(IPageService pageService, SampleUrlProvider sampleUrlProvider)
        {
            _pageService = pageService ?? throw new ArgumentNullException(nameof(pageService));
            _sampleUrlProvider = sampleUrlProvider;
        }

        public Task<IEnumerable<string>> NextUrl()
        {
            var language = GetRandomLanguage();
            if (GetRandomBool())
            {
                return GetVoxEuropArticleUrlAsync(language);
            }
            else
            {
                return GetEuronewsArticleUrlAsync(language);
            }
        }

        private async Task<IEnumerable<string>> GetEuronewsArticleUrlAsync(Language language)
        {
            var mainSite = _sampleUrlProvider.GetEuronewsListForLanguage(language);
            var document = await _pageService.DownloadDocumentAsync(mainSite);
            return _sampleUrlProvider.ParseEuronewsMainSite(document);
        }

        private async Task<IEnumerable<string>> GetVoxEuropArticleUrlAsync(Language language)
        {
            var mainSite = _sampleUrlProvider.GetVoxEuropListForLanguage(language);
            var document = await _pageService.DownloadDocumentAsync(mainSite);
            return _sampleUrlProvider.ParseVoxEuropaMainSite(document);
        }

        private Language GetRandomLanguage()
        {
            return (Language) _random.Next(1, 8);
        }

        private bool GetRandomBool()
        {
            var buffer = new byte[1];
            _random.NextBytes(buffer);
            return buffer[0] > 128;
        }
    }
}
