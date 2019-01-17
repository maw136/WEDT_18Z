using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.RegistrationByConvention;

namespace LanguageDetector.Infrastructure
{
    internal class ControllerFactory : IControllerFactory
    {
        private readonly IUnityContainer _currentContainer;
        private readonly Dictionary<string, Type> _controllers;
        private static readonly string ControllerPrefix = $"{CurrentAssembly.FullName}.Controllers";

        private static Assembly CurrentAssembly => Assembly.GetExecutingAssembly();

        public ControllerFactory(IUnityContainer currentContainer)
        {
            _currentContainer = currentContainer;
            _controllers = new Dictionary<string, Type>();
        }

        public IController GetController(Route route)
        {
            if (!_controllers.TryGetValue(route.Controller, out Type controllerType))
            {
                var potentialControllerName = route.Controller + "Controller";
                controllerType = AllClasses.FromAssembliesInBasePath().FirstOrDefault(t => t.Name == potentialControllerName);

                //controllerType = CurrentAssembly.GetType($"{ControllerPrefix}.{route.Controller}Controller");
                _controllers.Add(route.Controller, controllerType);
            }

            return controllerType == null
                ? null
                : (IController) _currentContainer.CreateChildContainer().Resolve(controllerType);
        }
    }
}