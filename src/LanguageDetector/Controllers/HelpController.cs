using System;

namespace LanguageDetector.Controllers
{
    public class HelpController : IController
    {
        public void PrintHelp()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Available commands, this is interactive mode:");
            Console.WriteLine("Demo.Run <path>");
            Console.WriteLine("Demo2.Run <path>");
            Console.WriteLine("Comparisons.Run <path>");
            Console.WriteLine("Help.PrintHelp");
            Console.WriteLine("Exit | Quit");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
        }
    }
}
