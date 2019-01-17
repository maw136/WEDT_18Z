using System;
using System.Collections.Generic;
using Interfaces;

namespace LanguageDetector.Controllers
{
    public class DemoController : IController
    {
        public void Run(string basePath)
        {
            Console.WriteLine("Hello World!");

            List<Tuple<string, Language>> pathsAndLanguages = new List<Tuple<string, Language>>();
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/english.txt", Language.English));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/polish.txt", Language.Polish));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/german.txt", Language.German));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/spanish.txt", Language.Spanish));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/portugese.txt", Language.Portuguese));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/italian.txt", Language.Italian));
            pathsAndLanguages.Add(Tuple.Create($"{basePath}/words_base/french.txt", Language.French));

            LanguageDictionaryFactory factory = new LanguageDictionaryFactory();
            IEnumerable<LanguageDictionary> languageDitionaries = factory.Create(pathsAndLanguages);
        }
    }
}
