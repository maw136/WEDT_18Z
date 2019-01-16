namespace LanguageDetector.Infrastructure
{
    internal interface IControllerFactory
    {
        IController GetController(Route route);
    }
}