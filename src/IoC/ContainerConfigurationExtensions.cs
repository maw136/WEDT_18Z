using System;
using System.Linq;
using Interfaces;
using Unity;
using Unity.RegistrationByConvention;

namespace IoC
{
    public static class ContainerConfigurationExtensions
    {
        public static IUnityContainer ConfigureContainer(this IUnityContainer container)
        {
            return container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath().Where(FilterTypes),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);
        }

        private static bool FilterTypes(Type typeToRegister)
        {
            return !typeof(IAnalizer).IsAssignableFrom(typeToRegister);
        }
    }
}
