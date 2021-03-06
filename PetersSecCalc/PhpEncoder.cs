using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetersSecCalc
{
    public class PhpEncoder
    {
        static Regex regex = new Regex(@"(chr\((?<value>[0-9]{1,3})\)[ .]*)", RegexOptions.Compiled);

        public string ConvertToText(string phpEncoderCharEncoded)
        {
            if (string.IsNullOrWhiteSpace(phpEncoderCharEncoded)) return "";

            string result = "";
            var matches = regex.Matches(phpEncoderCharEncoded);
            if (matches.Count == 0) return "unable to convert";
            foreach (Match match in matches)
            {
                if (!match.Success) return "unable to convert";

                byte value;
                if (!byte.TryParse(match.Groups["value"].Value, out value))
                {
                    return "unable to convert";
                }

                result += (char)value;
            }

            return result;
        }

        public string ConvertToPhpEncoded(string phpEncoderText)
        {
            byte[] chars = Encoding.ASCII.GetBytes(phpEncoderText);
            string result = "";
            string concat = "";
            foreach (byte c in chars)
            {
                result += $"{concat}chr({c})";
                concat = ".";
            }

            return result;
        }
    }
}
