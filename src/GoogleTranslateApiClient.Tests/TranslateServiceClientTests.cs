using System;
using FluentAssertions;
using Interfaces;
using Xunit;

namespace GoogleTranslateApiClient.Tests
{
    public class TranslateServiceClientTests
    {
        private readonly TranslateServiceClient _instance;

        public TranslateServiceClientTests()
        {
            _instance = new TranslateServiceClient();
        }

        [Theory]
        [InlineData("Ala ma kota, kot ma wszy a babajaga patrzy.", Language.Polish)]
        [InlineData("It's a beautiful morning, at a dawn of mankind, emperor of men would be pleased.", Language.English)]
        public void DetectLanguage_ShortInputText_ProperLanguageDetected(string input, Language expected)
        {
            var actual = _instance.DetectLanguage(input);
            actual.Should().Be(expected);
        }
    }
}
