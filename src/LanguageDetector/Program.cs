using System;
using Interfaces;
using System.Collections.Generic;
using Comparisons;
using System.Threading.Tasks;
using IoC;
using Unity;
using LanguageDetector.Infrastructure;

namespace LanguageDetector
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            ComparisonCreator comparisonCreator = new ComparisonCreator();
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language.English);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language.English);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessForAllLanguages();
            Console.WriteLine("Comparisons done.");

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
