using System;
using Interfaces;
using System.Collections.Generic;
using Comparisons;

namespace LanguageDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ComparisonCreator comparisonCreator = new ComparisonCreator();
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnTokenNumberInArticle(Language.English);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessOnDictionaryLength(Language.English);
            comparisonCreator.CreateComparisonOfAlgorithmEffectivenessForAllLanguages();
            Console.WriteLine("Done");
        }
    }
}
