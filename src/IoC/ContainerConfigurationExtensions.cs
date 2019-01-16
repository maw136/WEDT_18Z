using Unity;
using Unity.RegistrationByConvention;

namespace IoC
{
    public static class ContainerConfigurationExtensions
    {
        public static IUnityContainer ConfigureContainer(this IUnityContainer container)
        {
            return container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromAllInterfaces,
                WithName.Default,
                WithLifetime.Transient);
        }
    }
}
