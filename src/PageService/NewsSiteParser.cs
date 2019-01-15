using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using HtmlAgilityPack;

namespace PageService
{
    public abstract class NewsSiteParser
    {
        public virtual IEnumerable<string> ParseMainSite(HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes(ArticleEntrySelector);
            return GetHrefs(nodes);
        }

        public virtual Article ParseArticleSite(HtmlDocument articleHtml)
        {
            var paragraphs = articleHtml.DocumentNode.SelectNodes(ArticleTextSelector);
            var text = string.Join("\n", paragraphs.Select(p => p.InnerText));;

            return new Article
            {
                Content = text
            };
        }

        protected abstract XPathExpression ArticleEntrySelector { get; }

        protected abstract XPathExpression ArticleTextSelector { get; }

        protected IEnumerable<string> GetHrefs(HtmlNodeCollection nodes)
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