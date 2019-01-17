using System;
using Interfaces;
using System.Collections.Generic;
using Comparisons;
using System.Threading.Tasks;
using IoC;
using Unity;
using LanguageDetector.Infrastructure;

using PageService;
using PageService.EuroNews;
using PageService.VoxEuropa;

namespace LanguageDetector
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            ComparisonCreator comparisonCreator = new ComparisonCreator();
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language.English);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language.German);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language.French);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language.Spanish);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language.Portuguese);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language.Italian);

            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language.English);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language.German);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language.French);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language.Spanish);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language.Portuguese);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language.Italian);
            
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
