using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Whatsapp.Desktop.Business
{
    public class Message: Model
    {
        private string id;
        public string ID 
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Text { get; set; }

        private Enumerations.MessageStatus messageStatus;
        public Enumerations.MessageStatus MessageStatus 
        {
            get
            {
                return this.messageStatus;
            }
            set
            {
                this.messageStatus = value;
                base.OnPropertyChanged("MessageStatus");
            }
        }

        private DateTime time;
        public DateTime Time 
        {
            get
            {
                return time;
            }
            set
            {
                this.time = value;
            }
        }

        public string Day 
        {
            get { return this.time.Date.ToString("dd MMMM yyyy"); }
            
        }

        public Enumerations.MessageType MessageType 
        { 
            get; set; 
        }

        public string FromJid { get; set; }

        public string ToJid { get; set; }

        public string FromName { get; set; }

        public string FromInfo 
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
    }
}