using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Whatsapp.Desktop.Business
{
    public class rsItemBase: Model
    {
        public rsItemBase()
        {
            this.messages = new ObservableCollection<rsMessage>();
        }

        public Enumerations.RosterItemType RosterItemType { get; set; }

        public string Jid { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public string Status { get; set; }

        private string avatarPreviewURL;
        public string AvatarPreviewURL
        {
            get
            {
                return this.avatarPreviewURL;
            }
            set
            {
                this.avatarPreviewURL = value;
                this.OnPropertyChanged("AvatarPreviewURL");
            }
        }

        private string avatarFullUrl;
        public string AvatarFullUrl
        {
            get
            {
                return this.avatarFullUrl;
            }
            set
            {
                this.avatarFullUrl = value;
                this.OnPropertyChanged("AvatarFullUrl");
            }
        }

        public DateTime? LastActivity { get; set; }

        public string Message
        {
            get 
            {
                if (this.messages.Any())
                    return this.messages.OrderByDescending(msg => msg.Time).FirstOrDefault().Text;
                else
                    return String.Empty;
            }
        }

        private ObservableCollection<rsMessage> messages;
        public ObservableCollection<rsMessage> Messages
        {
            get
            {
                return this.messages;
            }
            set
            {
                this.messages = value;
            }
        }

        public void Add(rsMessage message)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                Messages.Add(message);
                this.OnPropertyChanged("Message");
                if (this.OnMessageReceived != null)
                    this.OnMessageReceived(this);
            });
        }

        public delegate void OnMessageRecievedDelegate(object sender);
        public event OnMessageRecievedDelegate OnMessageReceived;
    }
}
