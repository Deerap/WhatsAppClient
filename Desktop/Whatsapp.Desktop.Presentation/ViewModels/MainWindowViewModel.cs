using System;
using System.Linq;
using Whatsapp.Desktop.Business;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Whatsapp.Desktop.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public delegate void MessagesRecievedDelegate(object sender, object roster);
        public event MessagesRecievedDelegate OnMessagesRecieved;
        
        public MainWindowViewModel()
        {
            rosterInstance = Roster.Instance;
            rosterInstance.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(rosterInstance_PropertyChanged);
            rosterInstance.OnRosterMessageReceived += rosterInstance_OnRosterMessageReceived;
        }

        void rosterInstance_OnRosterMessageReceived(object sender)
        {
            if (this.OnMessagesRecieved != null)
                OnMessagesRecieved(this, sender);
        }

        void MainWindowViewModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.OnMessagesRecieved != null)
                this.OnMessagesRecieved(this, rosterInstance.SelectedItem);
        }

        void rosterInstance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedItem":
                    OnPropertyChanged("Messages");
                    break;
            }
        }

        private ObservableCollection<Message> _CurrentRosterMessages;

        public ObservableCollection<Message> CurrentRosterMessages
        {
            get 
            {
                return _CurrentRosterMessages;
            }
            set
            {
                _CurrentRosterMessages = value;
                OnPropertyChanged("CurrentRosterMessages");
            }
        }

        private Roster rosterInstance;//private Roster rosterInstance;

        public Roster RosterInstance
        {
            get
            {
                return this.rosterInstance;
            }
        }

        public CollectionView Items
        {
            get
            {
                CollectionView itemsView = (CollectionView)CollectionViewSource.GetDefaultView(rosterInstance.Items);
                if (this.InSearchMode)
                {
                    itemsView.Filter = item =>
                    {
                        RosterItem ritem = item as RosterItem;
                        if (ritem == null) return false;

                        return ritem.Name.ToLower().Contains(searchText.ToLower()) || ritem.Messages.Where(m => m.Text.ToLower().Contains(searchText.ToLower())).ToList().Count > 0;
                    };
                }
                else
                    itemsView.Filter = null;

                if (itemsView.Count > 0)
                {
                    if (!itemsView.Contains(rosterInstance.SelectedItem))
                        rosterInstance.SelectedItem = (RosterItem)itemsView.GetItemAt(0);
                }
                else
                    rosterInstance.SelectedItem = null;

                return itemsView;
            }
        }

        public CollectionView Messages
        {
            get
            {
                if (rosterInstance.SelectedItem != null)
                {
                    ObservableCollection<Message> currentRosterItemMessages = rosterInstance.SelectedItem.Messages;

                    CurrentRosterMessages = rosterInstance.SelectedItem.Messages;

                    //foreach (Message m in currentRosterItemMessages.Where(m => m.ReadByClient == false && m.MessageType == "normal").ToList<Message>())
                    //    m.ReadByClient = true;

                    CollectionView messageView = (CollectionView)CollectionViewSource.GetDefaultView(currentRosterItemMessages);

                    if (messageView.GroupDescriptions.Count == 0)
                    {
                        PropertyGroupDescription groupDescription = new PropertyGroupDescription("Day");
                        messageView.GroupDescriptions.Add(groupDescription);
                    }
                   
                    return messageView;
                }
                else
                    return null;
            }
        }

        private string searchText;
        public string SearchText
        {
            get
            {
                return this.searchText;
            }
            set
            {
                this.searchText = value;
                OnPropertyChanged("SearchText");
                OnPropertyChanged("InSearchMode");
                OnPropertyChanged("Messages");
                OnPropertyChanged("Items");
            }
        }

        public bool InSearchMode
        {
            get
            {
                if (String.IsNullOrEmpty(this.searchText))
                    return false;
                else
                    return true;
            }
        }       
    }
}