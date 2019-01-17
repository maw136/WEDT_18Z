using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Interfaces;

namespace PageService
{
    public class ExtendedRandom : IExtendedRandom
    {
        private static readonly Random _random;
        private static readonly Language[] _languages;

        static ExtendedRandom()
        {
            var timestamp = Stopwatch.GetTimestamp();
            var hiBitsL = timestamp >> 32;
            int loBits = (int)timestamp;
            int hiBits = (int)hiBitsL;
            _random = new Random(loBits ^ hiBits);

            _languages = Enum.GetValues(typeof(Language))
                .Cast<Language>()
                .Where(l => l != Language.Unknown)
                .ToArray();
        }

        public Language NextLanguage()
        {
            return _languages[_random.Next(0, _languages.Length)];
        }

        public T NextEntry<T>(IReadOnlyList<T> collection)
        {
            return collection[_random.Next(0, collection.Count)];
        }
    }
}