using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageDetector.Controllers
{
    public class HelpController : IController
    {
        public void PrintHelp()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("Demo.Run <path>");
            Console.WriteLine("Demo2.Run <path>");
            Console.WriteLine("Help.PrintHelp");
        }
    }
}
