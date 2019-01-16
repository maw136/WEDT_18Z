namespace LanguageDetector.Infrastructure
{
    internal interface IRouter
    {
        Route ParseCommand(string command);
    }
}