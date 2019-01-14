using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Interfaces
{
    public interface IPageService
    {
        Task<HtmlDocument> DownloadDocumentAsync(string url);
    }
}
