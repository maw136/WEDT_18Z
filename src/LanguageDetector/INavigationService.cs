namespace LanguageDetector
{
    internal interface INavigationService
    {
        void Navigate(string controller, string action, string parameterLine);
    }
}