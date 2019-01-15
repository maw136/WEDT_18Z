﻿using System;
using Interfaces;

namespace PageService.EuroNews
{
    public class EuroNewsSite : NewsSite
    {
        public EuroNewsSite(EuroNewsSiteParser newsSiteParser, IPageDownloadService pageDownloadService, IRandom random)
            : base(newsSiteParser, pageDownloadService, random)
        {
        }

        protected override string GetMainSiteUrlForLanguage(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return "https://www.euronews.com/";
                case Language.Unknown:
                    throw new ArgumentOutOfRangeException(nameof(language));
                default:
                    return $"https://{LanguageCodeConverter.GetLanguageCode(language)}.euronews.com/";
            }
        }
    }
}