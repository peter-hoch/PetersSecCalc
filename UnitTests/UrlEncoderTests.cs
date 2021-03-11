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
    public class UrlEncoderTests
    {
        // https://www.urlencoder.org/
        [TestCase("", "", true)]
        [TestCase("a%", "a%25", true)]
        [TestCase("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890", true)]
        [TestCase(" a!\\\"$%&/()=?`#'+*~-_.:,;<>|", "%20a%21%5C%22%24%25%26%2F%28%29%3D%3F%60%23%27%2B%2A~-_.%3A%2C%3B%3C%3E%7C", true)]
        public void ConvertToUrlEncodingTest(string text, string expectedResult, bool andBack)
        {
            UrlEncoder encoder = new UrlEncoder();
            string result = encoder.ConvertToUrlEncoding(text);
            Assert.That(result, Is.EqualTo(expectedResult), $"Text2Url conversion error \"{result}\" expected \"{expectedResult}\"");

            if (andBack)
            {
                string backText = encoder.ConvertToText(result);
                Assert.That(backText, Is.EqualTo(text), $"Url2TText conversion error \"{backText}\" expected \"{text}\"");
            }
        }

        [TestCase("a%25", "a%")]
        [TestCase("a%25%36", "a%6")]
        [TestCase("a%25%3", "a%%3")]
        [TestCase("a%25%", "a%%")]
        public void ConvertToText(string encodedText, string expectedResult)
        {
            UrlEncoder encoder = new UrlEncoder();
            string result = encoder.ConvertToText(encodedText);
            Assert.That(result, Is.EqualTo(expectedResult), $"Url2TText conversion error \"{result}\" expected \"{expectedResult}\"");
        }

    }
}
