using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetersSecCalc
{
    public class HexToAsciiEncoder
    {

        public string ConvertToAscii(string input, string regexText)
        {
            string result = "";

            Regex regex = new Regex(regexText);
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                if (!match.Success)
                {
                    result += $"({match.Value} error)";
                }
                else
                {
                    string text = match.Groups["value"].Value;
                    byte value;
                    if (!byte.TryParse(text, NumberStyles.HexNumber, null, out value))
                    {
                        result += $"({text} error)";
                    }
                    else
                    {
                        result += (char) value;
                    }
                }
            }


            return result;
        }
    }
}
