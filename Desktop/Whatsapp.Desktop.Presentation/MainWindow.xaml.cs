using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Whatsapp.Desktop.Business;
using Whatsapp.Desktop.Presentation.ViewModels;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using Whatsapp.Desktop.Presentation.Resources;
using Whatsapp.Desktop.Business.Enumerations;

namespace Whatsapp.Desktop.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        Connection client;
        //private List<MainNotifyWindow> lstNotificationWindows;
        //System.Windows.Forms.NotifyIcon ni;


        public MainWindow()
        {
            try
            {
                InitializeComponent();
                //ni = new System.Windows.Forms.NotifyIcon();

                //ni.Icon = (Icon)Application.Cu;

                //ni.Visible = true;

                //ni.Click +=
                //    delegate(object sender, EventArgs args)
                //    {
                //        this.Show();
                //        this.WindowState = WindowState.Normal;
                //        this.Activate();
                //    };
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void OnErrorOccured()
        {
            try
            {
                MessageBox.Show("Some error has occured in MiWavez and application cannot continue.Please contact the Administrator?");
                Application.Current.Shutdown();
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void lvwRoster_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            try
            {
                ((GridView)lvwRoster.View).Columns[0].Width = lvwRoster.ActualWidth - 30;
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void lvwMessages_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                ((GridView)lvwMessages.View).Columns[0].Width = lvwMessages.ActualWidth - 30;
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtSearch.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel = new MainWindowViewModel();
                client = Connection.Instance;
                this.DataContext = viewModel;
                viewModel.OnMessagesRecieved += viewModel_OnMessagesRecieved;
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        void viewModel_OnMessagesRecieved(object sender, object rosterItem)
        {
            try
            {
                rsItemBase current = rosterItem as rsItemBase;
                MainWindowViewModel currentModel = (MainWindowViewModel)sender;

                //MainNotifyWindow nWindow = null;

                //if (this.WindowState == System.Windows.WindowState.Minimized)
                //{
                //    if (lstNotificationWindows == null)
                //        lstNotificationWindows = new List<MainNotifyWindow>();
                //    else
                //        nWindow = lstNotificationWindows.Where(win => win.WindowTitle == current.Name).FirstOrDefault();

                //    if (nWindow == null)
                //    {
                //        nWindow = new MainNotifyWindow()
                //        {
                //            WindowTitle = current.Name,
                //            Messages = current.Messages,
                //            NotificationIcon = ni
                //        };
                //        lstNotificationWindows.Add(nWindow);
                //        nWindow.ShowWindow();
                //    }
                //    else
                //    {
                //        nWindow.Messages = currentModel.CurrentRosterMessages;
                //        if (!((nWindow.PinButton.IsChecked != null) && ((bool)nWindow.PinButton.IsChecked)))
                //            nWindow.ShowWindow();
                //    }
                //}
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void btnSendChat_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtChatMessage.Text.Trim() != string.Empty)
                {
                    rsItemBase currentRosterItem = rsRoster.Instance.Get(rsRoster.Instance.SelectedItem.Jid);
                    currentRosterItem.Add(new rsMessage() { Text = txtChatMessage.Text, Time = DateTime.Now, Direction = MessageDirection.Outgoing });
                    client.SendMessage(currentRosterItem.Jid, txtChatMessage.Text);
                    txtChatMessage.Clear();
                }
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void txtChatMessage_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    if (txtChatMessage.Text.Trim() != string.Empty)
                    {
                        rsItemBase currentRosterItem = rsRoster.Instance.Get(rsRoster.Instance.SelectedItem.Jid);
                        currentRosterItem.Add(new rsMessage() { Text = txtChatMessage.Text, Time = DateTime.Now, Direction= MessageDirection.Outgoing});
                        client.SendMessage(currentRosterItem.Jid, txtChatMessage.Text);
                        txtChatMessage.Clear();
                    }
                }
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //ni.Visible = false;
                //ni.Dispose();
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            //if (this.WindowState == System.Windows.WindowState.Minimized)
            //    this.Hide();
        }
    }
}