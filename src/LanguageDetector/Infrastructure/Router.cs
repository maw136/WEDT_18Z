using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LanguageDetector.Infrastructure
{
    internal class Router : IRouter
    {
        private static readonly Regex _commandRegex =
            new Regex(@"^(?<controller>\w(\w|\d)*)\.(?<action>\w(\w|\d)*)( (?<parameters>.*))?$");

        public Route ParseCommand(string command)
        {
            try
            {
                if (command == "Exit" || command == "Quit")
                {
                    Process.GetCurrentProcess().Kill();
                }

                var matchedCommand = _commandRegex.Match(command);
                return new Route
                {
                    Controller = matchedCommand.Groups["controller"].Value,
                    Action = matchedCommand.Groups["action"].Value,
                    ParameterLine = matchedCommand.Groups["parameters"].Value
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(Route);
            }
        }
    }
}