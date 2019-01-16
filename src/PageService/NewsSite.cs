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
        private readonly IRandom _random;
        private readonly IPageDownloadService _pageDownloadService;
        private readonly NewsSiteParser _newsSiteParser;

        protected NewsSite(NewsSiteParser newsSiteParser, IPageDownloadService pageDownloadService, IRandom random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _pageDownloadService = pageDownloadService ?? throw new ArgumentNullException(nameof(pageDownloadService));
            _newsSiteParser = newsSiteParser ?? throw new ArgumentNullException(nameof(newsSiteParser));
        }

        protected abstract string GetMainSiteUrlForLanguage(Language language);

        private string ToAbsoluteUrl(string mainUri, string articleUrl) =>
            new Uri(new Uri(mainUri), articleUrl).ToString();

        public async Task<Article> GetNextArticleAsync()
        {
            Language language = _random.NextLanguage();
            string mainSiteUrl = GetMainSiteUrlForLanguage(language);
            HtmlDocument mainSite = await _pageDownloadService.DownloadDocumentAsync(mainSiteUrl);
            List<string> articleUrls = _newsSiteParser.ParseMainSite(mainSite).ToList();
            string articleUrl = _random.NextEntry(articleUrls);
            string articleAbsoluteUrl = ToAbsoluteUrl(mainSiteUrl, articleUrl);
            HtmlDocument articleHtml = await _pageDownloadService.DownloadDocumentAsync(articleAbsoluteUrl);
            Article article = _newsSiteParser.ParseArticleSite(articleHtml);
            article.ActualLanguage = language;
            return article;
        }
    }
}