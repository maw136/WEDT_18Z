using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageService
{
    public class NewsArticleProvider : INewsArticleProvider
    {
        private readonly IRandom _random;
        private readonly INewsSite[] _sites;

        public NewsArticleProvider(IEnumerable<INewsSite> sites, IRandom random)
        {
            if (sites == null)
            {
                throw new ArgumentNullException(nameof(sites));
            }

            _random = random ?? throw new ArgumentNullException(nameof(random));
            _sites = sites.ToArray();
            if (_sites.Length < 1)
            {
                throw new ArgumentException("Sites list cannot be empty", nameof(sites));
            }
        }

        public Task<Article> GetNextArticleAsync()
        {
            return _random.NextEntry(_sites).GetNextArticleAsync();
        }
    }
}
