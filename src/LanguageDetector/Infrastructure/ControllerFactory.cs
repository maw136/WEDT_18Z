using System;
using System.Collections.Generic;
using System.Reflection;

namespace LanguageDetector.Infrastructure
{
    internal class ControllerFactory : IControllerFactory
    {
        private readonly Dictionary<string, Type> _controllers;
        private static readonly string ControllerPrefix = $"{CurrentAssembly.FullName}.Controllers";

        private static Assembly CurrentAssembly => Assembly.GetExecutingAssembly();

        public ControllerFactory()
        {
            _controllers = new Dictionary<string, Type>();
        }

        public IController GetController(Route route)
        {
            if (!_controllers.TryGetValue(route.Controller, out Type controllerType))
            {
                controllerType = CurrentAssembly.GetType($"{ControllerPrefix}.{route.Controller}");
                _controllers.Add(route.Controller, controllerType);
            }

            return (IController)Activator.CreateInstance(controllerType);
        }
    }
}