using System.Threading.Tasks;

namespace PageService
{
    public interface INewsArticleProvider
    {
        Task<Article> GetNextArticleAsync();
    }
}