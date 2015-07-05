using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Whatsapp.Desktop.Business
{
    public class RosterItem: Model
    {
        public RosterItem()
        {
            this.messages = new ObservableCollection<Message>();
        }

        public Enumerations.RosterItemType RosterItemType { get; set; }

        public string Jid { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        private string status;
        public string Status 
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
                this.OnPropertyChanged("Status");
            }
        }

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

        public Message Message
        {
            get 
            {
                if (this.messages.Any())
                    return this.messages.OrderByDescending(msg => msg.Time).FirstOrDefault();
                else
                    return new Message();
            }
        }
    
        public int UnreadCount 
        {
            get 
            {
                //return this.messages.Where(msg => !msg.IsRead).Count();
                return 0;
            }
        }

        private ObservableCollection<Message> messages;
        public ObservableCollection<Message> Messages
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

        public void Add(Message message)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                Messages.Add(message);
                this.OnPropertyChanged("Message");
                if (this.OnMessageReceived != null)
                    this.OnMessageReceived(this);
            });
        }

        private bool isOnline;
        public bool IsOnline
        {
            get { return this.isOnline; }
            set
            {
                this.isOnline = value;
                OnPropertyChanged("Presence");
            }
        }

        public string Presence
        {
            get
            {
                if (this.isOnline)
                    return "Online";
                else
                {
                    if (this.LastActivity.HasValue)
                        return this.LastActivity.Value.ToString("hh:mm");
                    else
                        return "N/A";
                }
            }
        }

        public delegate void OnMessageRecievedDelegate(object sender);
        public event OnMessageRecievedDelegate OnMessageReceived;

    }
}
