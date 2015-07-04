using System;
using System.Windows;
using Whatsapp.Desktop.Business;
using System.Windows.Threading;
using System.IO;

namespace Whatsapp.Desktop.Presentation
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Connection client;
        bool bIsLoginPerformed;

        public Login()
        {
            try
            {
                InitializeComponent();
                
                client = Connection.Instance;
                client.OnLoginSuccess += new Connection.OnLoginSuccessDelegate(client_OnLogin);
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        void client_OnLogin()
        {
            try
            {
                if (!bIsLoginPerformed)
                    Dispatcher.Invoke(new Action(OnLoginPerformed));
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
                MessageBox.Show("Some error has occured in Whatsapp and application cannot continue.Please contact the Administrator?");
                Application.Current.Shutdown();
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void OnLoginFailed()
        {
            try
            {
                lblStatus.Text = "Invalid Credentials! Please try again.";
                txtPassword.IsEnabled = true;
                txtMobile.IsEnabled = true;
                cmdSignIn.IsEnabled = true;
                txtMobile.Focus();
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void OnLoginPerformed()
        {
            try
            {
                MainWindow mainWindow;
                mainWindow = new MainWindow();

                mainWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                mainWindow.Show();

                this.Close();
                Application.Current.MainWindow = mainWindow;
                bIsLoginPerformed = true;
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private void cmdSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblStatus.Text = "Signing In....";
                txtPassword.IsEnabled = false;
                txtMobile.IsEnabled = false;
                cmdSignIn.IsEnabled = false;
                Connection.Instance.Initialize(txtMobile.Text, txtPassword.Password, "", false, false);
                Connection.Instance.Login();
                OnLoginPerformed();
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
                txtMobile.Text = "<YourNumber>";
                txtPassword.Password = "<YourPassword>";
                lblStatus.Text = "Enter Your Credentials to Sign In.";
                cmdSignIn.Focus();
                bIsLoginPerformed = false;
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        //public void client_OnAuthorizationError()
        //{
        //    try
        //    {
        //        Dispatcher.Invoke(new Action(OnLoginFailed));
        //    }
        //    catch (Exception)
        //    {
        //        Dispatcher.Invoke(new Action(OnErrorOccured));
        //    }
        //}
    }
}