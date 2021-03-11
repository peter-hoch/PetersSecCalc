using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetersSecCalc
{
    public class UrlEncoder
    {
        const string CharactersToConvert = " !\\\"$%&/()=?`#'+*:,;<>|";

        public string ConvertToUrlEncoding(string text)
        {
            byte[] chars = Encoding.ASCII.GetBytes(text);
            string result = "";
            foreach (byte c in chars)
            {
                string test = "" + (char)c;
                if (CharactersToConvert.Contains(test))
                {
                    uint value = (uint) c;
                    result += $"%{value:X}";// {(char)c} ";
                }
                else
                {
                    result += (char)c;
                }
            }

            return result;
        }

        public string ConvertToText(string urlEncodedText)
        {
            string result = "";
            for(int idx=0; idx < urlEncodedText.Length;)
            {
                if(urlEncodedText[idx] == '%')
                {
                    if (urlEncodedText.Length > idx + 2)
                    {
                        string textValue = urlEncodedText.Substring(idx + 1, 2);
                        if (byte.TryParse(textValue, NumberStyles.AllowHexSpecifier, null, out var value))
                        {
                            result += (char) value;
                            idx += 3;
                        }
                        else
                        {
                            result += $"unable to convert \"{urlEncodedText.Substring(idx, 3)}\"";
                        }
                    }
                    else
                    {
                        result += urlEncodedText[idx];
                        idx++;
                    }
                }
                else
                {
                    result += urlEncodedText[idx];
                    idx++;
                }
            }

            return result;
        }
    }
}
