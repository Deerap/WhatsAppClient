using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace Whatsapp.Desktop.Presentation.Converters
{
    public class IntegerToFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if ((Int32)value > 0)
            {
                return FontWeights.ExtraBold;
            }
            else
                return FontWeights.Normal;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
