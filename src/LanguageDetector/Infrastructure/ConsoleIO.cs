using System;

namespace LanguageDetector.Infrastructure
{
    internal class ConsoleIO : IO
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}