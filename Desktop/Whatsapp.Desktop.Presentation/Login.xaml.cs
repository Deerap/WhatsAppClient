using System;
using System.Windows;
using Whatsapp.Desktop.Business;
using System.Windows.Threading;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;

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
            //string identity = "";
            //string waNumber = "";

            try
            {
                //if (((Button)sender).Content.ToString().Contains("Request Token"))
                //{
                //    if (sendGetRequestToken(txtMobile.Text, out identity, out waNumber))
                //    {
                //        lblStatus.Text = "We have sent you an SMS with a code to the number above. To complete your phone number verification, please enter the 6-digit activation code.";
                //        txtMobile.IsEnabled = false;
                //        lblPhone.Foreground = new SolidColorBrush(Colors.Gray);

                //        txtPassword.IsEnabled = true;
                //        lblPassword.Foreground = new SolidColorBrush(Colors.White);

                //        cmdSignIn.Content = "Sign In";
                //    }
                //}
                //else
                //{
                    //lblStatus.Text = "Signing In....";
                    //txtPassword.IsEnabled = false;
                    //txtMobile.IsEnabled = false;
                    //cmdSignIn.IsEnabled = false;
                    //lblStatus.Foreground = new SolidColorBrush(Colors.Gray);

                    //string password = client.SendGetPassword(waNumber, txtPassword.Password,identity);

                    //Connection.Instance.Initialize(txtMobile.Text, password, "", false, false);
                    //Connection.Instance.Login();
                    //OnLoginPerformed();
                //}

                lblStatus.Text = "Signing In....";
                txtPassword.IsEnabled = false;
                txtMobile.IsEnabled = false;
                cmdSignIn.IsEnabled = false;
                lblStatus.Foreground = new SolidColorBrush(Colors.Gray);
                lblPhone.Foreground = new SolidColorBrush(Colors.Gray);

                Connection.Instance.Initialize(txtMobile.Text, txtPassword.Password, "", false, false);
                Connection.Instance.Login();
                OnLoginPerformed();
            }
            catch (Exception)
            {
                Dispatcher.Invoke(new Action(OnErrorOccured));
            }
        }

        private bool sendGetRequestToken(string number, out string identity, out string waNumber)
        {
            bool result = client.SendGetRequestToken(number,out identity, out waNumber);
            return result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtMobile.Text = "";
                txtPassword.Password = "";
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