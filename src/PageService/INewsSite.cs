using System.Threading.Tasks;

namespace PageService
{
    public interface INewsSite
    {
        Task<Article> GetNextArticleAsync();
    }
}