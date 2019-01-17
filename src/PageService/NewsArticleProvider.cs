using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageService
{
    public class NewsArticleProvider : INewsArticleProvider
    {
        private readonly IExtendedRandom _extendedRandom;
        private readonly INewsSite[] _sites;

        public NewsArticleProvider(IEnumerable<INewsSite> sites, IExtendedRandom extendedRandom)
        {
            if (sites == null)
            {
                throw new ArgumentNullException(nameof(sites));
            }

            _extendedRandom = extendedRandom ?? throw new ArgumentNullException(nameof(extendedRandom));
            _sites = sites.ToArray();
            if (_sites.Length < 1)
            {
                throw new ArgumentException("Sites list cannot be empty", nameof(sites));
            }
        }

        public Task<Article> GetNextArticleAsync()
        {
            return _extendedRandom.NextEntry(_sites).GetNextArticleAsync();
        }
    }
}
