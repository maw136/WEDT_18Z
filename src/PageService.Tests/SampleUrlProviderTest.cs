using FluentAssertions;
using HtmlAgilityPack;
using Interfaces;
using Xunit;

namespace PageService.Tests
{
    public class SampleUrlProviderTest
    {
        private SampleUrlProvider _instance;
        public SampleUrlProviderTest()
        {
            _instance = new SampleUrlProvider();
        }

        [Fact]
        public void GetVoxEuropListForLanguage_English()
        {
            var link = _instance.GetVoxEuropListForLanguage(Language.English);
            link.Should().Be($"https://voxeurop.eu/en");
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
