using System;
using System.ComponentModel;
using LanguageDetector.Controllers;
using LanguageDetector.Infrastructure;

namespace LanguageDetector
{
    internal class Shell : INavigationService
    {
        private static int instances = 0;

        private readonly IControllerFactory _controllerFactory;
        private readonly IRouter _router;
        private readonly IO _io;

        public Shell(IControllerFactory controllerFactory, IRouter router, IO io)
        {
            _controllerFactory = controllerFactory;
            _router = router;
            _io = io;

            ++instances;

            if (instances > 1)
            {
                throw new NotSupportedException();
            }
        }

        public void RunInteractive()
        {
            new HelpController().PrintHelp();

            bool running = true;
            while (running)
            {
                var line = _io.ReadLine();
                var route = _router.ParseCommand(line);
                var controller = _controllerFactory.GetController(route);
                InvokeRoute(controller, route);
            }
        }

        private void InvokeRoute(IController controller, Route route)
        {
            if (controller == null)
            {
                new HelpController().PrintHelp();
                return;
            }

            var method = controller.GetType().GetMethod(route.Action);
            var parameterValues = route.ParameterLine?.Split(' ') ?? new string[0];
            var parameters = method.GetParameters();

            var callingValues = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; ++i)
            {
                var parameter = parameters[i];
                if (i < parameterValues.Length)
                {
                    TypeConverter typeConverter = TypeDescriptor.GetConverter(parameter.ParameterType);
                    callingValues[i] = typeConverter.ConvertFromString(parameterValues[i]);
                }
                else
                {
                    callingValues[i] = CreateDefaultValue(parameter.ParameterType);
                }
            }

            method.Invoke(controller, callingValues);
        }

        private object CreateDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        public void Navigate(string controller, string action, string parameterLine)
        {

        }
    }
}
