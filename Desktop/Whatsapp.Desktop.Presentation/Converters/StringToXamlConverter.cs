using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;
using System.Security;
using System.IO;
using System.Xml;
using System.Windows.Markup;

namespace Whatsapp.Desktop.Presentation.Converters
{
    [ValueConversion(typeof(string), typeof(object))]
    public sealed class StringToXamlConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string containing valid XAML into WPF objects.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>A WPF object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = value as string;
            if (input != null)
            {
                string escapedXml = SecurityElement.Escape(input);
                string withTags = escapedXml.Replace("|~S~|", "<Run Style=\"{DynamicResource highlight}\">");
                withTags = withTags.Replace("|~E~|", "</Run>");

                string wrappedInput = string.Format("<TextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" TextWrapping=\"Wrap\">{0}</TextBlock>", withTags);

                using (StringReader stringReader = new StringReader(wrappedInput))
                {
                    using (XmlReader xmlReader = XmlReader.Create(stringReader))
                    {
                        return XamlReader.Load(xmlReader);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Converts WPF framework objects into a XAML string.
        /// </summary>
        /// <param name="value">The WPF Famework object to convert.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>A string containg XAML.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("This converter cannot be used in two-way binding.");
        }
    }
}
