﻿using System;
using System.Text.RegularExpressions;

namespace LanguageDetector.Infrastructure
{
    internal class Router : IRouter
    {
        private static readonly Regex _commandRegex =
            new Regex(@"^(?<controller>\w+)\\.(?<action>\w+) (?<parameters>.*)$");

        public Route ParseCommand(string command)
        {
            try
            {
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