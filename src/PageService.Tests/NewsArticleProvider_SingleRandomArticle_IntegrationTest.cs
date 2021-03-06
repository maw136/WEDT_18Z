﻿using System.Collections.Generic;
using FluentAssertions;
using Interfaces;
using NSubstitute;
using PageService.EuroNews;
using PageService.VoxEuropa;
using Xunit;
using Xunit.Abstractions;

namespace PageService.Tests
{
    public class NewsArticleProvider_SingleRandomArticle_IntegrationTest
    {
        private readonly ITestOutputHelper _output;

        private readonly IExtendedRandom _extendedRandom;

        private readonly NewsArticleProvider _instance;

        public NewsArticleProvider_SingleRandomArticle_IntegrationTest(ITestOutputHelper output)
        {
            _output = output;
            _extendedRandom = Substitute.For<IExtendedRandom>();
            var download = new PageDownloadService();

            var sites = new NewsSite[]
            {
                new EuroNewsSite(new EuroNewsSiteParser(), download, _extendedRandom),
                new VoxEuropaSite(new VoxEuropaSiteParser(), download, _extendedRandom),
            };
            _instance= new NewsArticleProvider(sites, _extendedRandom);
        }

        [Theory]
        [InlineData(0, Language.English, 0)]
        [InlineData(1, Language.English, 0)]
        [InlineData(0, Language.English, 1)]
        [InlineData(1, Language.English, 1)]
        [InlineData(0, Language.English, 2)]
        [InlineData(1, Language.English, 2)]
        [InlineData(0, Language.German, 0)]
        [InlineData(1, Language.German, 0)]
        [InlineData(0, Language.German, 1)]
        [InlineData(1, Language.German, 1)]
        [InlineData(0, Language.German, 2)]
        [InlineData(1, Language.German, 2)]
        public async void SingleArticleDownloadTest(int site, Language lang, int link)
        {
            _extendedRandom.NextLanguage().Returns(lang);
            _extendedRandom.NextEntry(Arg.Any<IReadOnlyList<string>>())
                .Returns(ci => ((IReadOnlyList<string>) ci[0])[link]);
            _extendedRandom.NextEntry(Arg.Any<IReadOnlyList<INewsSite>>())
                .Returns(ci => ((IReadOnlyList<INewsSite>) ci[0])[site]);

            var article = await _instance.GetNextArticleAsync();
            article.Should().NotBeNull();
            article.ActualLanguage.Should().Be(lang);
            article.Content.Should().NotBeNullOrWhiteSpace();
            _output.WriteLine("language: {0}\n Content:\n{1}",
                article.ActualLanguage, article.Content);
        }
    }
}
