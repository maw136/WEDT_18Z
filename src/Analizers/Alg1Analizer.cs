﻿using System;
using System.Collections.Generic;

namespace Interfaces
{
    public class Alg1Analizer : IAnalizer
    {
        public Alg1Analizer(IEnumerable<LanguageDictionary> languageDictionaries)
        {

        }

        public Analysis Analize(ITokenizer tokenizer)
        {
            var tokens = tokenizer.Tokenize();
            // DO RZECZY
            // wypluj wynik
            return new Analysis();
        }
    }
}