using System.Collections.Generic;
using System.Linq;
using System;

namespace Interfaces
{

    public class LanguageDictionaryFactory
    {        
        public IEnumerable<LanguageDictionary> Create(IEnumerable<Tuple<string, Language>> tuples) {
            List<LanguageDictionary> dictionaries = new List<LanguageDictionary>();
            
            foreach (Tuple<string, Language> tuple in tuples) {
                dictionaries.Add(Create(tuple.Item1, tuple.Item2));
            }
            return dictionaries;
        }

        public IEnumerable<LanguageDictionary> Create(IEnumerable<Tuple<string, Language>> tuples, int limit) {
            List<LanguageDictionary> dictionaries = new List<LanguageDictionary>();
            
            foreach (Tuple<string, Language> tuple in tuples) {
                dictionaries.Add(Create(tuple.Item1, tuple.Item2, limit));
            }
            return dictionaries;
        }           

        public LanguageDictionary Create(string path, Language language) {
            LanguageDictionary languageDictionary = new LanguageDictionary();
            languageDictionary.Langauge = language;

            string[] lines = System.IO.File.ReadAllLines(path);
            Console.WriteLine("Read {0} lines for lang: {1}", lines.Count().ToString(), language.ToString());
            foreach (string line in lines ) {
                if (!string.IsNullOrEmpty(line)) {
                    string[] splittedStrings = line.Split(null);
                    // Console.WriteLine("Line: {0}; Splitted: {1}|{2}", line, splittedStrings[0], splittedStrings[1]);
                    languageDictionary.Internal.Add(splittedStrings[0].Trim(), Int32.Parse(splittedStrings[1].Trim()));
                }
            }
            Console.WriteLine("Words read: {0}", languageDictionary.Internal.Count);
            return languageDictionary;
        }

        public LanguageDictionary Create(string path, Language language, int limit) {
            LanguageDictionary languageDictionary = new LanguageDictionary();
            languageDictionary.Langauge = language;

            string[] lines = System.IO.File.ReadAllLines(path);
            string[] limitedLines = new string[limit];
            Array.Copy(lines, limitedLines, limit);
            // Console.WriteLine("Read {0} lines for lang: {1}", lines.Count().ToString(), language.ToString());
            foreach (string line in limitedLines ) {
                if (!string.IsNullOrEmpty(line)) {
                    string[] splittedStrings = line.Split(null);
                    // Console.WriteLine("Line: {0}; Splitted: {1}|{2}", line, splittedStrings[0], splittedStrings[1]);
                    languageDictionary.Internal.Add(splittedStrings[0].Trim(), Int32.Parse(splittedStrings[1].Trim()));
                }
            }
            // Console.WriteLine("Words read: {0}", languageDictionary.Internal.Count);
            return languageDictionary;
        }
    }

}
