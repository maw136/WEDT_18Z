using Unity;
using Unity.Lifetime;

namespace LanguageDetector.Infrastructure
{
    internal static class InfrastructureRegistrationExtensions
    {
        internal static IUnityContainer RegisterInfrastructure(this IUnityContainer container)
        {
            container.RegisterType<IControllerFactory, ControllerFactory>();
            container.RegisterType<IRouter, Router>();
            container.RegisterType<IO, ConsoleIO>();
            container.RegisterType<INavigationService, Shell>(new ContainerControlledLifetimeManager());

            return container;
        }
    }
}
