using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Whatsapp.Desktop.Business.Enumerations;

namespace Whatsapp.Desktop.Presentation.Converters
{
    public class MessageTypeToCornerRadiusConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((MessageType)value) == MessageType.Incoming)
                return new CornerRadius(10, 0, 10, 10);
            else
                return new CornerRadius(0, 10, 10, 10);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
