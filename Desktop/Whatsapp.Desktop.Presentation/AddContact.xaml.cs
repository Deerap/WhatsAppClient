using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Whatsapp.Desktop.Business;

namespace Whatsapp.Desktop.Presentation
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
        }

        private void btnSaveContact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!String.IsNullOrEmpty(txtNumber.Text))
                {
                    var rosterItem = new RosterItem()
                    {
                        Jid = txtNumber.Text + "@s.whatsapp.net",
                        Name = txtName.Text,
                        Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
                    };
                    Roster.Instance.Add(rosterItem);
                    Roster.Instance.SelectedItem = rosterItem;
                    Connection.Instance.SendGetPhoto(rosterItem.Jid);
                    Connection.Instance.SendGetStatus(rosterItem.Jid);
                }

                this.Close();
            }
            catch(Exception)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
