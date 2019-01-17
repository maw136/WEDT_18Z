using System.Xml.XPath;

namespace PageService.EuroNews
{
    public class EuroNewsSiteParser : NewsSiteParser
    {
        private readonly XPathExpression _euronewsArticleEntrySelector = XPathExpression.Compile("//article//a[@class='media__body__link']");

        private readonly XPathExpression _euronewsArticleTextSelector = XPathExpression.Compile("//article/section//p");

        protected override XPathExpression ArticleEntrySelector => _euronewsArticleEntrySelector;

        protected override XPathExpression ArticleTextSelector => _euronewsArticleTextSelector;
    }
}