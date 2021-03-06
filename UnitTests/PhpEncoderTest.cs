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
    public class PhpEncoderTest
    {
        [TestCase("1234", "chr(49).chr(50).chr(51).chr(52)", true)]
        [TestCase("", "", true)]
        [TestCase(" !\\\"$%&'()*+,-./", "chr(32).chr(33).chr(92).chr(34).chr(36).chr(37).chr(38).chr(39).chr(40).chr(41).chr(42).chr(43).chr(44).chr(45).chr(46).chr(47)", true)]
        public void ConvertToPhpEncoded(string text, string expectedResult, bool back)
        {
            PhpEncoder encoder = new PhpEncoder();
            var result = encoder.ConvertToPhpEncoded(text);
            Assert.That(result, Is.EqualTo(expectedResult), $"compare error {result}  expected {expectedResult}");

            if (back)
            {
                var backResult = encoder.ConvertToText(result);
                Assert.That(backResult, Is.EqualTo(text), $"back compare error {backResult}  expected {text}");
            }
        }
    }
}
