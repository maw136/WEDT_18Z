using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageDetector.Controllers
{
    public class HelpController : IController
    {
        public void PrintHelp()
        {
            Console.WriteLine("Available commands, this is interactive mode:");
            Console.WriteLine("Demo.Run <path>");
            Console.WriteLine("Demo2.Run <path>");
            Console.WriteLine("Help.PrintHelp");
            Console.WriteLine("Exit | Quit");
        }
    }
}
