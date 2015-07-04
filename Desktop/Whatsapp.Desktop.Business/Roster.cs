using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace Whatsapp.Desktop.Business
{
    public class Roster : Model
    {
        private Roster()
        {
            this.items = new ObservableCollection<RosterItem>();
        }

        private static Roster instance;
        public static Roster Instance
        {
            get
            {
                if (instance == null)
                    instance = new Roster();
                return instance;
            }
        }

        private RosterItem selectedItem;
        public RosterItem SelectedItem
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

        private ObservableCollection<RosterItem> items;
        public ObservableCollection<RosterItem> Items
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

        public void Add(RosterItem rosterItem)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                rosterItem.OnMessageReceived += item_OnMessageReceived;
                Items.Add(rosterItem);
            });
        }

        public RosterItem Get(string jid)
        {
            return this.Items.FirstOrDefault<RosterItem>(i => i.JID == jid);
        }

        public bool Contains(string jid)
        {
            return this.Items.Any(item => item.JID == jid);
        }
    }
}
