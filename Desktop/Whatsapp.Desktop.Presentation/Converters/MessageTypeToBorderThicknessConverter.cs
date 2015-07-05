﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Whatsapp.Desktop.Business.Enumerations;

namespace Whatsapp.Desktop.Presentation.Converters
{
    public class MessageTypeToBorderThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((MessageType)value) == MessageType.Incoming)
                return new Thickness(3, 1, 1, 1);
            else
                return new Thickness(1, 1, 3, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}