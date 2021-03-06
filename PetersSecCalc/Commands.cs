using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PetersSecCalc
{
    public class Commands
    {
        public static RoutedUICommand Text2HexConvert2Hex;
        public static RoutedUICommand Text2HexConvert2Text;
        public static RoutedUICommand Text2Base64BinaryConvert2Binary;
        public static RoutedUICommand Text2Base64BinaryConvert2Text;
        public static RoutedUICommand CopyToClipboard;
        public static RoutedUICommand Text2UrlEncodedConvert2UrlEncoded;
        public static RoutedUICommand Text2UrlEncodedConvert2Text;


        static Commands()
        {
            var gestures = new InputGestureCollection();
            gestures.Add(new KeyGesture(Key.T, ModifierKeys.Control));

            Text2HexConvert2Hex = new RoutedUICommand("Text2HexConvert2Hex", "Text2HexConvert2Hex", typeof(Commands));
            Text2HexConvert2Text = new RoutedUICommand("Text2HexConvert2Text", "Text2HexConvert2Text", typeof(Commands));
            Text2Base64BinaryConvert2Binary = new RoutedUICommand("Text2Base64BinaryConvert2Binary", "Text2Base64BinaryConvert2Binary", typeof(Commands));
            Text2Base64BinaryConvert2Text = new RoutedUICommand("Text2Base64BinaryConvert2Text", "Text2Base64BinaryConvert2Text", typeof(Commands));
            CopyToClipboard = new RoutedUICommand("CopyToClipboard", "CopyToClipboard", typeof(Commands));
            Text2UrlEncodedConvert2UrlEncoded = new RoutedUICommand("Text2UrlEncodedConvert2UrlEncoded", "Text2UrlEncodedConvert2UrlEncoded", typeof(Commands));
            Text2UrlEncodedConvert2Text = new RoutedUICommand("Text2UrlEncodedConvert2Text", "Text2UrlEncodedConvert2Text", typeof(Commands));
        }

    }
}
