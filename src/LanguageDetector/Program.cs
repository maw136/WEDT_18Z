using System;
using IoC;
using Unity;
using LanguageDetector.Infrastructure;

namespace LanguageDetector
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                var container = new UnityContainer();
                container.ConfigureContainer();
                container.RegisterInfrastructure();
                var shell = container.Resolve<Shell>();
                shell.RunInteractive();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
