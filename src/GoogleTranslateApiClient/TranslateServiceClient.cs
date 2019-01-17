using Google.Cloud.Translation.V2;
using Language = Interfaces.Language;

namespace GoogleTranslateApiClient
{
    public class TranslateServiceClient
    {
        public Language DetectLanguage(string input)
        {
            using (TranslationClient client = TranslationClient.Create())
            {
                var detection = client.DetectLanguage(text: input);
                return ToLanguageEnum(detection.Language);
            }
        }

        private static Language ToLanguageEnum(string detectionLanguage)
        {
            switch (detectionLanguage)
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
