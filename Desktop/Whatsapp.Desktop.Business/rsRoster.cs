using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Whatsapp.Desktop.Business
{
    public class rsRoster : Model
    {
        private rsRoster()
        {
            this.items = new ObservableCollection<rsItemBase>();
        }

        private static rsRoster instance;
        public static rsRoster Instance
        {
            get
            {
                if (instance == null)
                    instance = new rsRoster();
                return instance;
            }
        }

        private rsItemBase selectedItem;
        public rsItemBase SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<rsItemBase> items;
        public ObservableCollection<rsItemBase> Items
        {
            get
            {
                return this.items;
            }
        }

        public delegate void OnRosterMessageReceivedDelegate(object sender);
        public event OnRosterMessageReceivedDelegate OnRosterMessageReceived;

        void item_OnMessageReceived(object sender)
        {
            if (this.OnRosterMessageReceived != null)
                OnRosterMessageReceived(sender);
        }

        public void Add(rsItemBase rosterItem)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                rosterItem.OnMessageReceived += item_OnMessageReceived;
                Items.Add(rosterItem);
            });
        }

        public rsItemBase Get(string jid)
        {
            return this.Items.FirstOrDefault<rsItemBase>(i => i.Jid == jid);
        }

        public bool Contains(string jid)
        {
            return this.Items.Any(item => item.Jid == jid);
        }
    }
}
