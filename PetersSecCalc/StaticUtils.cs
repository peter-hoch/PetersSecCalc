using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace PetersSecCalc
{
    public static class StaticUtils
    {

        public static string ToHexString(this byte[] me)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in me)
            {
                sb.Append($"{b:X2}");
            }

            return sb.ToString();
        }
    }

    public class Utils
    {
        static Regex _regex = new Regex("(?<byte>[0-9a-fA-F]{2})", RegexOptions.Compiled);

        public byte[] FromHexString(string binaryText)
        {
            List<byte> bytes = new List<byte>();
            var matches = _regex.Matches(binaryText);
            foreach (Match match in matches)
            {
                bytes.Add(byte.Parse(match.Groups["byte"].Value, NumberStyles.HexNumber));
            }
            return bytes.ToArray();
        }
    }
}
