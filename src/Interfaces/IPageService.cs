using HtmlAgilityPack;

namespace Interfaces
{
    public interface IPageService
    {
        HtmlDocument DownloadDocument(string url);
    }
}
