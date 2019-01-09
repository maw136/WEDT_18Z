using HtmlAgilityPack;

namespace Interfaces
{
    public interface ITextFromHtmlExtractor
    {
        string ParsePage(HtmlDocument htmlText);
    }
}
