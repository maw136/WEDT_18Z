using System.Collections.Generic;
using System.Xml.XPath;
using HtmlAgilityPack;

namespace PageService.VoxEuropa
{
    public class VoxEuropaSiteParser : NewsSiteParser
    {
        private readonly XPathExpression _voxEuropaArticleEntrySelector = XPathExpression.Compile("//li[@class=article]//a");

        private readonly XPathExpression _voxEuropaArticleTextSelector = XPathExpression.Compile("//article[@class=article-single]/div[@class='bodytext padb']//p");

        protected override XPathExpression ArticleEntrySelector => _voxEuropaArticleEntrySelector;

        protected override XPathExpression ArticleTextSelector => _voxEuropaArticleTextSelector;
    }
}