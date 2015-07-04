using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using System.Drawing;

namespace Whatsapp.Desktop.Business
{
    public class RosterItem : Model
    {
        public RosterItem()
        {
            this.messages = new ObservableCollection<Message>();
        }

        private bool typing;
        public bool Typing
        {
            get
            {
                return this.typing;
            }
            set
            {
                this.typing = value;
                this.OnPropertyChanged("Presence");
            }
        }

        private bool online;
        public bool Online 
        {
            get 
            {
                return this.online;
            }
            set 
            {
                this.online = value;
                this.OnPropertyChanged("Presence");
            }
        }

        private string jid;
        public string JID
        {
            get
            {
                return jid;
            }
            set
            {
                this.jid = value;
            }
        }

        private string number;
        public string Number
        {
            get
            {
                return this.number;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

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

        private DateTime? lastSeen;
        public DateTime? LastSeen
        {
            get
            {
                return lastSeen;
            }
            set
            {
                lastSeen = value;
            }
        }

        private int unreadCount;
        public int UnreadCount
        {
            get
            {
                return this.unreadCount;
            }
            set
            {
                this.unreadCount = value;
            }
        }

        private string presence;
        public string Presence
        {
            get 
            {
                if (this.typing)
                    return "typing...";
                else if (this.online)
                    return "Online";
                else if(this.LastSeen.HasValue)
                    return this.lastSeen.Value.ToString("dd/MM/yyyy hh:mm");

                return "Unknown";
            }
            set 
            {
                this.presence = value;
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

        private const string blankUri = "Images/profile/blank.png";

        public string Message 
        {
            get 
            {
                if (this.Messages.Any())
                    return this.Messages.OrderByDescending(msg => msg.Time).FirstOrDefault().Text;
                else
                    return String.Empty;
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

        public delegate void OnMessageRecievedDelegate(object sender);
        public event OnMessageRecievedDelegate OnMessageReceived;

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
    }
}
