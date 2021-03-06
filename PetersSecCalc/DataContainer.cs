using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PetersSecCalc
{
    public enum TextEncoding
    {
        Ascii,
        Utf8,
        Utf32,
    }

    public class DataContainer : INotifyPropertyChanged
    {
        public DataContainer()
        {
            Text2HexInput = "Sample text";
            Text2HexBinary = "Sample text";

            Text2HexTextEncoding = Enum.GetValues(typeof(TextEncoding));
            Text2Base64BinaryTextEncoding = Enum.GetValues(typeof(TextEncoding));
        }

        #region Text2HexInput

        private string _text2HexInput;

        public string Text2HexInput
        {
            get { return _text2HexInput; }
            set
            {
                _text2HexInput = value;
                OnPropertyChanged("Text2HexInput");
            }
        }

        #endregion

        #region Text2HexBinary

        private string _text2HexBinary;

        public string Text2HexBinary
        {
            get { return _text2HexBinary; }
            set
            {
                _text2HexBinary = value;
                OnPropertyChanged("Text2HexBinary");
            }
        }

        #endregion

        #region Text2HexTextEncoding

        private Array _text2HexTextEncoding;

        public Array Text2HexTextEncoding
        {
            get { return _text2HexTextEncoding; }
            set
            {
                _text2HexTextEncoding = value;
                OnPropertyChanged("Text2HexTextEncoding");
            }
        }

        #endregion

        #region Text2HexSelectedTextEncoding

        private TextEncoding _text2HexSelectedTextEncoding;

        public TextEncoding Text2HexSelectedTextEncoding
        {
            get { return _text2HexSelectedTextEncoding; }
            set
            {
                _text2HexSelectedTextEncoding = value;
                OnPropertyChanged("Text2HexSelectedTextEncoding");
            }
        }

        #endregion

        #region Warning

        private string _warning;

        public string Warning
        {
            get { return _warning; }
            set
            {
                _warning = value;
                OnPropertyChanged("Warning");
            }
        }

        #endregion

        #region Text2Base64BinaryBinary

        private string _text2Base64BinaryBinary;

        public string Text2Base64BinaryBinary
        {
            get { return _text2Base64BinaryBinary; }
            set
            {
                _text2Base64BinaryBinary = value;
                OnPropertyChanged("Text2Base64BinaryBinary");
            }
        }

        #endregion

        #region Text2Base64BinaryInput

        private string _text2Base64BinaryInput;

        public string Text2Base64BinaryInput
        {
            get { return _text2Base64BinaryInput; }
            set
            {
                _text2Base64BinaryInput = value;
                OnPropertyChanged("Text2Base64BinaryInput");
            }
        }

        #endregion

        #region Text2Base64BinaryWarning

        private string _text2Base64BinaryWarning;

        public string Text2Base64BinaryWarning
        {
            get { return _text2Base64BinaryWarning; }
            set
            {
                _text2Base64BinaryWarning = value;
                OnPropertyChanged("Text2Base64BinaryWarning");
            }
        }

        #endregion

        #region Text2Base64BinaryTextEncoding

        private Array _text2Base64BinaryTextEncoding;

        public Array Text2Base64BinaryTextEncoding
        {
            get { return _text2Base64BinaryTextEncoding; }
            set
            {
                _text2Base64BinaryTextEncoding = value;
                OnPropertyChanged("Text2Base64BinaryTextEncoding");
            }
        }

        #endregion

        #region Text2Base64BinarySelectedTextEncoding

        private TextEncoding _text2Base64BinarySelectedTextEncoding;

        public TextEncoding Text2Base64BinarySelectedTextEncoding
        {
            get { return _text2Base64BinarySelectedTextEncoding; }
            set
            {
                _text2Base64BinarySelectedTextEncoding = value;
                OnPropertyChanged("Text2Base64BinarySelectedTextEncoding");
            }
        }

        #endregion

        #region UrlEncoderUrlEncoded

        private string _text2UrlEncoderUrlEncoded;

        public string UrlEncoderUrlEncoded
        {
            get { return _text2UrlEncoderUrlEncoded; }
            set
            {
                _text2UrlEncoderUrlEncoded = value;
                OnPropertyChanged("UrlEncoderUrlEncoded");
            }
        }

        #endregion

        #region UrlEncoderText

        private string _urlEncoderText;

        public string UrlEncoderText
        {
            get { return _urlEncoderText; }
            set
            {
                _urlEncoderText = value;
                OnPropertyChanged("UrlEncoderText");
            }
        }

        #endregion

        #region PhpEncoderCharEncoded

        private string _phpEncoderCharEncoded;

        public string PhpEncoderCharEncoded
        {
            get { return _phpEncoderCharEncoded; }
            set
            {
                _phpEncoderCharEncoded = value;
                OnPropertyChanged("PhpEncoderCharEncoded");
            }
        }

        #endregion

        #region PhpEncoderText

        private string _phpEncoderText;

        public string PhpEncoderText
        {
            get { return _phpEncoderText; }
            set
            {
                _phpEncoderText = value;
                OnPropertyChanged("PhpEncoderText");
            }
        }

        #endregion



#region event

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(name);
                PropertyChanged(this, args);
            }
        }

        #endregion


    }
}
