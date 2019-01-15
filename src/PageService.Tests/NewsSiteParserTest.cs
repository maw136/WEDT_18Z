using System;
using System.Collections.Generic;
using System.Xml.XPath;
using FluentAssertions;
using HtmlAgilityPack;
using NSubstitute;
using Xunit;

namespace PageService.Tests
{
    public class NewsSiteParserTest
    {
        internal class NewsSiteParser_ForTest : NewsSiteParser
        {
            protected override XPathExpression ArticleEntrySelector => throw new NotSupportedException();
            protected override XPathExpression ArticleTextSelector => throw new NotSupportedException();

            public new IEnumerable<string> GetHrefs(HtmlNodeCollection nodes)
            {
                return base.GetHrefs(nodes);
            }
        }

        private NewsSiteParser_ForTest _instance;

        public NewsSiteParserTest()
        {
            _instance = new NewsSiteParser_ForTest();
        }

        [Fact]
        public void GetUrls_SingleAnchor()
        {
            var node = HtmlNode.CreateNode(
                "<p><a href=\"/abc\">link1</a><a href=\"/abc\">link2</a><a href=\"/abc\">link3</a></p>");
            var nodes = node.ChildNodes;
            var urls = _instance.GetHrefs(nodes);
            urls.Should().BeEquivalentTo("/abc", "/abc", "/abc");
        }
    }
}
