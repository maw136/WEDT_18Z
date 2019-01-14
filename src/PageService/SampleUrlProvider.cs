using System;
using System.Collections.Generic;
using System.Xml.XPath;
using HtmlAgilityPack;
using Interfaces;

namespace PageService
{
    public class SampleUrlProvider
    {
        private XPathExpression _voxEuropaArticleSelector = XPathExpression.Compile("//li[@class=article]//a");
        private XPathExpression _euronewsArticleSelector = XPathExpression.Compile("//article//a[@class=media__body__link]");

        public string GetVoxEuropListForLanguage(Language language)
        {
            if (language == Language.Unknown)
            {
                throw new ArgumentOutOfRangeException(nameof(language));
            }

            return $"https://voxeurop.eu/{LanguageCodeConverter.GetLanguageCode(language)}";
        }

        public IEnumerable<string> ParseVoxEuropaMainSite(HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes(_voxEuropaArticleSelector);
            return GetHrefs(nodes);
        }

        public string GetEuronewsListForLanguage(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return "https://www.euronews.com/";
                case Language.Unknown:
                    throw new ArgumentOutOfRangeException(nameof(language));
                default:
                    return $"https://{LanguageCodeConverter.GetLanguageCode(language)}.euronews.com/";
            }
        }

        public IEnumerable<string> ParseEuronewsMainSite(HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes(_euronewsArticleSelector);
            return GetHrefs(nodes);
        }

        public IEnumerable<string> GetHrefs(HtmlNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                if (node.Name != "a")
                {
                    continue;
                }
                var href = node.GetAttributeValue("href", null);
                if (!string.IsNullOrEmpty(href))
                {
                    yield return href;
                }
            }
        }
    }
}
