using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Interfaces
{
    public interface IPageDownloadService
    {
        Task<HtmlDocument> DownloadDocumentAsync(string url);
    }
}
