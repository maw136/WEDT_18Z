using HtmlAgilityPack;
using Interfaces;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PageService
{
    public class PageDownloadService : IPageDownloadService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<HtmlDocument> DownloadDocumentAsync(string url)
        {
            Stream content = await _httpClient.GetStreamAsync(url);
            var document = new HtmlDocument();
            document.Load(content);
            return document;
        }
    }
}
