using Interfaces;
using PageService.EuroNews;
using PageService.VoxEuropa;

namespace PageService
{
    public class NewsArticleProviderFactory
    {
        private readonly IPageDownloadService _pageDownloadService;
        private readonly IExtendedRandom _extendedRandom;

        public NewsArticleProviderFactory(IPageDownloadService pageDownloadService, IExtendedRandom extendedRandom)
        {
            _pageDownloadService = pageDownloadService;
            _extendedRandom = extendedRandom;
        }

        public INewsArticleProvider Create()
        {
            var sites = new NewsSite[]
            {
                new EuroNewsSite(new EuroNewsSiteParser(), _pageDownloadService, _extendedRandom),
                new VoxEuropaSite(new VoxEuropaSiteParser(), _pageDownloadService, _extendedRandom),
            };
            return new NewsArticleProvider(sites, _extendedRandom);
        }
    }
}
