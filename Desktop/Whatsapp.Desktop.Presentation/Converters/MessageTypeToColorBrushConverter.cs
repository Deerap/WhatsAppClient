using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using Whatsapp.Desktop.Business.Enumerations;

namespace Whatsapp.Desktop.Presentation.Converters
{
    public class MessageTypeToColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var converter = new System.Windows.Media.BrushConverter();

            if(((MessageType)value) == MessageType.Incoming)
                return (System.Windows.Media.Brush)converter.ConvertFromString("#FCFBF8");
            else
                return (System.Windows.Media.Brush)converter.ConvertFromString("#EBFECE");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
