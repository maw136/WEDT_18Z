using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Interfaces;

namespace PageService
{
    public abstract class NewsSite : INewsSite
    {
        private readonly IExtendedRandom _extendedRandom;
        private readonly IPageDownloadService _pageDownloadService;
        private readonly NewsSiteParser _newsSiteParser;

        protected NewsSite(NewsSiteParser newsSiteParser, IPageDownloadService pageDownloadService, IExtendedRandom extendedRandom)
        {
            _extendedRandom = extendedRandom ?? throw new ArgumentNullException(nameof(extendedRandom));
            _pageDownloadService = pageDownloadService ?? throw new ArgumentNullException(nameof(pageDownloadService));
            _newsSiteParser = newsSiteParser ?? throw new ArgumentNullException(nameof(newsSiteParser));
        }

        protected abstract string GetMainSiteUrlForLanguage(Language language);

        private string ToAbsoluteUrl(string mainUri, string articleUrl) =>
            new Uri(new Uri(mainUri), articleUrl).ToString();

        public async Task<Article> GetNextArticleAsync()
        {
            Language language = _extendedRandom.NextLanguage();
            string mainSiteUrl = GetMainSiteUrlForLanguage(language);
            HtmlDocument mainSite = await _pageDownloadService.DownloadDocumentAsync(mainSiteUrl);
            List<string> articleUrls = _newsSiteParser.ParseMainSite(mainSite).ToList();
            string articleUrl = _extendedRandom.NextEntry(articleUrls);
            string articleAbsoluteUrl = ToAbsoluteUrl(mainSiteUrl, articleUrl);
            HtmlDocument articleHtml = await _pageDownloadService.DownloadDocumentAsync(articleAbsoluteUrl);
            Article article = _newsSiteParser.ParseArticleSite(articleHtml);
            article.ActualLanguage = language;
            return article;
        }

        public async Task<List<string>> GetUrlsForLanguage(Language language) {
            string mainSiteUrl = GetMainSiteUrlForLanguage(language);
            HtmlDocument mainSite = await _pageDownloadService.DownloadDocumentAsync(mainSiteUrl);
            List<string> articleUrls = _newsSiteParser.ParseMainSite(mainSite).ToList();
            List<string> absoluteUrls = new List<string>();
            foreach (string url in articleUrls) {
                absoluteUrls.Add(ToAbsoluteUrl(mainSiteUrl, url));
            }
            return absoluteUrls;
        }

        public async Task<Article> GetArticleAsync(string url, Language articleLanguage) {
            HtmlDocument articleHtml = await _pageDownloadService.DownloadDocumentAsync(url);
            Article article = _newsSiteParser.ParseArticleSite(articleHtml);
            article.ActualLanguage = articleLanguage;
            return article;
        }
    }
}