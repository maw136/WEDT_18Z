using System;
using Interfaces;

namespace PageService.VoxEuropa
{
    public class VoxEuropaSite : NewsSite
    {
        public VoxEuropaSite(VoxEuropaSiteParser newsSiteParser, IPageDownloadService pageDownloadService, IExtendedRandom extendedRandom)
            : base(newsSiteParser, pageDownloadService, extendedRandom)
        {
        }

        protected override string GetMainSiteUrlForLanguage(Language language)
        {
            if (language == Language.Unknown)
            {
                throw new ArgumentOutOfRangeException(nameof(language));
            }

            return $"https://voxeurop.eu/{LanguageCodeConverter.GetLanguageCode(language)}";
        }
    }
}