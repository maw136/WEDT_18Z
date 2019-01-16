using System;

namespace Interfaces
{
    public static class LanguageCodeConverter
    {
        public static string GetLanguageCode(Language language)
        {
            switch (language)
            {
                case Language.Unknown:
                    return null;

                case Language.English:
                    return "en";
                case Language.Polish:
                    return "pl";
                case Language.German:
                    return "de";
                case Language.French:
                    return "fr";
                case Language.Spanish:
                    return "es";
                case Language.Italian:
                    return "it";
                case Language.Portuguese:
                    return "pt";
                default:
                    throw new ArgumentOutOfRangeException(nameof(language), language, null);
            }
        }

        public static Language GetLanguage(string lang)
        {
            switch (lang)
            {
                case "pl":
                    return Language.Polish;
                case "en":
                    return Language.English;
                case "de":
                    return Language.German;
                case "fr":
                    return Language.French;
                case "es":
                    return Language.Spanish;
                case "it":
                    return Language.Italian;
                case "pt":
                    return Language.Portuguese;
                default:
                    return Language.Unknown;
            }
        }
    }
}
