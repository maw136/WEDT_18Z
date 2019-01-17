using System;
using Comparisons;
using Interfaces;

namespace LanguageDetector.Controllers
{
    public class ComparisonsController : IController
    {
        public void Run(string basePath)
        {
            ComparisonCreator comparisonCreator = new ComparisonCreator(basePath);
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
        }
    }
}
