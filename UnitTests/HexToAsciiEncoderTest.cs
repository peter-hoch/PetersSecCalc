using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PetersSecCalc;

namespace UnitTests
{
    [TestFixture]
    public class HexToAsciiEncoderTest
    {
        [TestCase(@"\x6C\x65\x6E\x67\x74\x68", "(?<value>[0-9A-Fa-f]{2})", "length")]
        public void ConvertToAsciiTest(string input, string regex, string expectedResult)
        {
            HexToAsciiEncoder encoder = new HexToAsciiEncoder();

            string result = encoder.ConvertToAscii(input, regex);
            Assert.That(result, Is.EqualTo(expectedResult), $"compare error \"{result}\" expected \"{expectedResult}\"");
        }
    }
}
