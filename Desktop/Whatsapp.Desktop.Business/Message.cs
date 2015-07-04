using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Whatsapp.Desktop.Business
{
    public class Message
    {
        private string id;
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        private bool bDeliveredToServer;
        public bool DeliveredToServer 
        {
            get
            {
                return bDeliveredToServer;
            }
            set
            {
                bDeliveredToServer = true;
            }
        }

        private bool bDeliveredToClient;
        public bool DeliveredToClient
        {
            get { return bDeliveredToClient; }
            set { bDeliveredToClient = value; }
        }

        private bool bReadByClient;
        public bool ReadByClient
        {
            get
            {
                return bReadByClient;
            }
            set
            {
                bReadByClient = value;
            }
        }

        private string text;
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        private bool isSent;
        public bool IsSent 
        {
            get 
            {
                return isSent; 
            }
            set 
            {
                isSent = value;
            }
        }

        private CornerRadius cornerRadius;
        public CornerRadius Corners
        {
            get
            {
                return new CornerRadius(10, 0, 10, 10);
            }
            set
            {
                cornerRadius = value;
            }
        }

        private Brush backgroundValue;
        public Brush BackgroundValue
        {
            get 
            {
                if (IsSent)
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("LightYellow"));
                else
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
            }
            set
            {
                this.backgroundValue = value;
            }
        }

        public string MessageHeader
        {
            get 
            {
                if (this.fromUser != null)
                {
                    return String.Format("{0} ~{1}", this.fromUser.Split('@')[0], "Pradeep Potdar");
                }
                else
                    return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        //private Enumerations.MessageDirection direction;
        //public Enumerations.MessageDirection Direction
        //{
        //    get 
        //    {
        //        return this.direction;
        //    }
        //    set 
        //    {
        //        this.direction = value;
        //    }
        //}

        private bool isGroupMessage;
        public bool IsGroupMessage
        {
            get { return this.isGroupMessage; }
            set { this.IsGroupMessage = value; }
        }

        private Thickness borderThicknessValue;
        public Thickness BorderThicknessValue
        {
            get
            {
                if (IsSent)
                    return new Thickness(1, 1, 3, 1);
                else
                    return new Thickness(3, 1, 1, 1);
            }
            set
            {
                this.borderThicknessValue = value;
            }
        }

        private Thickness marginValue;
        public Thickness MarginValue
        {
            get 
            {
                if(isSent) 
                    return new Thickness(50, 0, 8, 0);
                else
                    return new Thickness(8, 0, 50, 0);
            }
            set
            {
                this.marginValue = value;
            }
        }

        private DateTime time;
        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public DateTime Day
        {
            get
            {
                return new DateTime(this.Time.Year, this.Time.Month, this.Time.Day);
            }
        }

        private string fromUser;
        public string FromUser
        {
            get
            {
                return fromUser;
            }
            set
            {
                fromUser = value;
            }
        }

        private string toAccount;
        public string ToAccount
        {
            get { return toAccount; }
            set { toAccount = value; }
        }

        private string messageType;
        public string MessageType
        {
            get { return messageType; }
            set { messageType = value; }
        }
    }
}