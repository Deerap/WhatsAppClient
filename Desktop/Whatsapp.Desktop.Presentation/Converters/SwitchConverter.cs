using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace Whatsapp.Desktop.Presentation.Converters
{
    [ContentProperty("Cases")]
    public class SwitchConverter : IValueConverter
    {
        List<SwitchConverterCase> _cases;

        public List<SwitchConverterCase> Cases { get { return _cases; } set { _cases = value; } }
        
        public SwitchConverter()
        {
            _cases = new List<SwitchConverterCase>();
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object results = null;

            if (value == null) throw new ArgumentNullException("value");

            if (_cases != null && _cases.Count > 0)
                for (int i = 0; i < _cases.Count; i++)
                {
                    SwitchConverterCase targetCase = _cases[i];

                    if (value == targetCase || value.ToString().ToUpper() == targetCase.When.ToString().ToUpper())
                    {
                        results = targetCase.Then;
                        break;
                    }
                }

            return results;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ContentProperty("Then")]
    public class SwitchConverterCase
    {
        string _when;
        object _then;

        public string When { get { return _when; } set { _when = value; } }
        public object Then { get { return _then; } set { _then = value; } }
        public SwitchConverterCase()
        {
        }
        public SwitchConverterCase(string when, object then)
        {
            this._then = then;
            this._when = when;
        }

        public override string ToString()
        {
            return string.Format("When={0}; Then={1}", When.ToString(), Then.ToString());
        }
    }
}
