using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tokenizer.Tests
{
    public class Tokenize_PositiveScenarios
    {
        public static IEnumerable<object[]> Tokenize_PositiveScenarios_TestData =new []
        {
           new object[]{ "" },
           new object[]{ "" },
           new object[]{ "" },
           new object[]{ "" },
           new object[]{ "" },
           new object[]{ "" },
        };

        [Theory]
        [MemberData(nameof(Tokenize_PositiveScenarios_TestData))]
        public void Test1(string data)
        {
            var tokenizer = new Tokenizer(data);

            var tokens = tokenizer.Tokenize().ToList();

            tokens.Should().NotBeNullOrEmpty();
        }
    }
}
