using FluentAssertions;
using NSubstitute;
using PageService.EuroNews;
using PageService.VoxEuropa;
using Xunit;

namespace PageService.Tests
{
    public class NewsArticleProvider_SingleRandomArticle_IntegrationTest
    {
        private NewsArticleProvider _instance;

        public NewsArticleProvider_SingleRandomArticle_IntegrationTest()
        {
            var random = Substitute.For<IRandom>();
            var download = new PageDownloadService();

            var sites = new NewsSite[]
            {
                new EuroNewsSite(new EuroNewsSiteParser(), download, random),
                new VoxEuropaSite(new VoxEuropaSiteParser(), download, random),
            };
            _instance= new NewsArticleProvider(sites, random);
        }

        [Fact]
        public async void SingleArticleDownloadTest()
        {
            var article = await _instance.GetNextArticleAsync();
            article.Should().NotBeNull();
            article.Content.Should().NotBeNullOrWhiteSpace();
        }
    }
}
