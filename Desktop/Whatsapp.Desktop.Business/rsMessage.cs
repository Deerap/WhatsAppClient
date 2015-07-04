using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Whatsapp.Desktop.Business
{
    public class rsMessage
    {
        public string ID { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

        public Enumerations.MessageDirection Direction 
        { 
            get; set; 
        }

        public string FromJid { get; set; }

        public string ToJid { get; set; }

        public string FromName { get; set; }

        public string MessageHeaderText 
        {
            get
            {
                if(this.GroupMessage)
                {
                    return String.Format("{0}{1}", "~", this.FromJid);
                }
                else
                {
                    return String.Empty;
                }
            }
        }

        public bool GroupMessage { get; set; }

        public System.Windows.Media.Brush BackgroundValue
        {
            get
            {
                if (this.Direction == Enumerations.MessageDirection.Outgoing)
                    return new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("LightYellow"));
                else
                    return new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("White"));
            }
        }

        public CornerRadius CornerRadiusValue
        {
            get
            {
                if(this.Direction == Enumerations.MessageDirection.Incoming)
                    return new CornerRadius(10, 0, 10, 10);
                else
                    return new CornerRadius(0, 10, 10, 10);
            }
        }

        public Thickness BorderThicknessValue
        {
            get
            {
                if (this.Direction == Enumerations.MessageDirection.Outgoing)
                    return new Thickness(1, 1, 3, 1);
                else
                    return new Thickness(3, 1, 1, 1);
            }
        }

        public Thickness MarginValue
        {
            get
            {
                if (this.Direction == Enumerations.MessageDirection.Outgoing)
                    return new Thickness(50, 0, 8, 0);
                else
                    return new Thickness(8, 0, 50, 0);
            }
        }
    }
}
