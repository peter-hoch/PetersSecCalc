using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetersSecCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataContainer DataContainer { get { return DataContext as DataContainer; } }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Text2HexConvert2Hex_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UiExceptionHandler(() =>
            {
                DataContainer.Warning = "";
                string text = DataContainer.Text2HexInput;
                string result = "";
                if (string.IsNullOrEmpty(text))
                {
                    result = "";
                }
                else
                {
                    switch (DataContainer.Text2HexSelectedTextEncoding)
                    {
                        case TextEncoding.Ascii:
                            result = Encoding.ASCII.GetBytes(text).ToHexString();
                            break;
                        case TextEncoding.Utf8:
                            result = Encoding.UTF8.GetBytes(text).ToHexString();
                            break;
                        case TextEncoding.Utf32:
                            result = Encoding.UTF32.GetBytes(text).ToHexString();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"unexpected value {DataContainer.Text2HexSelectedTextEncoding}");
                    }
                }

                DataContainer.Text2HexBinary = result;
            });
        }

        private void Text2HexConvert2Text_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UiExceptionHandler(() =>
            {
                DataContainer.Warning = "";
                string binary = DataContainer.Text2HexBinary;
                string result = "";
                if (string.IsNullOrEmpty(binary))
                {
                    result = "";
                }
                else
                {
                    Utils utils = new Utils();
                    var bytes = utils.FromHexString(binary);
                    switch (DataContainer.Text2HexSelectedTextEncoding)
                    {
                        case TextEncoding.Ascii:
                            result = Encoding.ASCII.GetString(bytes);
                            break;
                        case TextEncoding.Utf8:
                            result = Encoding.UTF8.GetString(bytes);
                            break;
                        case TextEncoding.Utf32:
                            result = Encoding.UTF32.GetString(bytes);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"unexpected value {DataContainer.Text2HexSelectedTextEncoding}");
                    }

                }

                if (result.Any(b => b == 0))
                {
                    DataContainer.Warning = $"There are null characters in string - possible wrong encoding?";
                }

                DataContainer.Text2HexInput = result;
            });
        }


        private void Always_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void UiExceptionHandler(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception caught {ex.Message}");
            }
        }

        private void Text2Base64BinaryConvert2Binary_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UiExceptionHandler(() =>
            {
                DataContainer.Text2Base64BinaryWarning = "";
                string text = DataContainer.Text2Base64BinaryInput;
                var encoding = DataContainer.Text2Base64BinarySelectedTextEncoding;

                byte[] result;
                if (string.IsNullOrEmpty(text))
                {
                    result = null;
                }
                else
                {
                    switch (encoding)
                    {
                        case TextEncoding.Ascii:
                            result = Encoding.ASCII.GetBytes(text);
                            break;
                        case TextEncoding.Utf8:
                            result = Encoding.UTF8.GetBytes(text);
                            break;
                        case TextEncoding.Utf32:
                            result = Encoding.UTF32.GetBytes(text);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"unexpected value {encoding}");
                    }
                }

                if (result != null)
                {
                    DataContainer.Text2Base64BinaryBinary = Convert.ToBase64String(result);
                }
            });

        }

        private void Text2Base64BinaryConvert2Text_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UiExceptionHandler(() =>
            {
                DataContainer.Text2Base64BinaryWarning = "";
                string binary = DataContainer.Text2Base64BinaryBinary;
                string result = "";
                var encoding = DataContainer.Text2Base64BinarySelectedTextEncoding;

                if (string.IsNullOrEmpty(binary))
                {
                    result = "";
                }
                else
                {
                    Utils utils = new Utils();
                    var bytes = Convert.FromBase64CharArray(binary.ToCharArray(), 0, binary.ToCharArray().Length);
                    switch (encoding)
                    {
                        case TextEncoding.Ascii:
                            result = Encoding.ASCII.GetString(bytes);
                            break;
                        case TextEncoding.Utf8:
                            result = Encoding.UTF8.GetString(bytes);
                            break;
                        case TextEncoding.Utf32:
                            result = Encoding.UTF32.GetString(bytes);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"unexpected value {encoding}");
                    }

                }

                if (result.Any(b => b == 0))
                {
                    DataContainer.Text2Base64BinaryWarning = $"There are null characters in string - possible wrong encoding?";
                }

                DataContainer.Text2Base64BinaryInput = result;
            });
        }

        private void CopyToClipboard_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UiExceptionHandler(() =>
            {
                var dataContext = (e.Source as FrameworkElement).DataContext;
                if (dataContext is string data)
                {
                    Clipboard.SetText(data);
                }
                else
                {
                    throw new Exception($"convert to string error {dataContext}");
                }
            });
        }

        private void Text2UrlEncodedConvert2Text_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var encoder = new UrlEncoder();
            DataContainer.UrlEncoderText = encoder.ConvertToText(DataContainer.UrlEncoderUrlEncoded);
        }

        private void Text2UrlEncodedConvert2UrlEncoded_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var encoder = new UrlEncoder();
            DataContainer.UrlEncoderUrlEncoded = encoder.ConvertToUrlEncoding(DataContainer.UrlEncoderText);
        }
    }
}
