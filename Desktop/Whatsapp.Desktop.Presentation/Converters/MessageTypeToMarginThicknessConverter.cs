using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Whatsapp.Desktop.Business.Enumerations;

namespace Whatsapp.Desktop.Presentation.Converters
{
    public class MessageTypeToMarginThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((MessageType)value) == MessageType.Incoming)
                return new Thickness(8, 0, 50, 0);
            else
                return new Thickness(50, 0, 8, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
