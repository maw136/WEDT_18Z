using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Article> GetNextArticleAsync()
        {
            var language = _random.NextLanguage();
            var mainSiteUrl = GetMainSiteUrlForLanguage(language);
            var mainSite = await _pageDownloadService.DownloadDocumentAsync(mainSiteUrl);
            var articleUrls = _newsSiteParser.ParseMainSite(mainSite).ToList();
            var articleUrl = _random.NextEntry(articleUrls);
            var articleHtml = await _pageDownloadService.DownloadDocumentAsync(articleUrl);
            return _newsSiteParser.ParseArticleSite(articleHtml);
        }
    }
}