using System;
using WhatsAppApi;
using System.ComponentModel;
using System.Threading;
using WhatsAppApi.Helper;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;

namespace Whatsapp.Desktop.Business
{
    public class Connection
    {
        private volatile bool isRunning;
        private BackgroundWorker bgWorker;

        private WhatsApp client;

        public delegate void OnConnectionFailedDelegate(Exception ex);
        public event OnConnectionFailedDelegate OnConnectionFailed;

        public delegate void OnLoginFailedDelegate(string message);
        public event OnLoginFailedDelegate OnLoginFailed;

        public delegate void OnLoginSuccessDelegate();
        public event OnLoginSuccessDelegate OnLoginSuccess;

        private static Connection instance;
        public static Connection Instance
        {
            get
            {
                if (instance == null)
                    instance = new Connection();

                return instance;
            }
        }

        public void Initialize(string number, string password, string nick, bool debug, bool hidden)
        {
            client = new WhatsApp(number, password, nick, debug, hidden);

            client.OnConnectFailed += client_OnConnectFailed;
            client.OnConnectSuccess += client_OnConnectSuccess;
            client.OnDisconnect += client_OnDisconnect;
            client.OnError += client_OnError;
            client.OnLoginFailed += client_OnLoginFailed;
            client.OnLoginSuccess += client_OnLoginSuccess;

            client.OnGetContactName += client_OnGetContactName;
            client.OnGetLastSeen += client_OnGetLastSeen;




            client.OnGetGroupSubject += client_OnGetGroupSubject;
            client.OnGetGroups += client_OnGetGroups;
            client.OnGetGroupParticipants += client_OnGetGroupParticipants;
            client.OnGetParticipantAdded += client_OnGetParticipantAdded;
            client.OnGetParticipantRemoved += client_OnGetParticipantRemoved;
            client.OnGetParticipantRenamed += client_OnGetParticipantRenamed;

            client.OnGetMessage += client_OnGetMessage;
            client.OnGetMessageAudio += client_OnGetMessageAudio;
            client.OnGetMessageImage += client_OnGetMessageImage;
            client.OnGetMessageLocation += client_OnGetMessageLocation;
            client.OnGetMessageVcard += client_OnGetMessageVcard;
            client.OnGetMessageVideo += client_OnGetMessageVideo;

            client.OnGetPhotoPreview += client_OnGetPhotoPreview;
            client.OnGetPhoto += client_OnGetPhoto;
            client.OnGetPresence += client_OnGetPresence;
            client.OnGetStatus += client_OnGetStatus;
            client.OnGetTyping += client_OnGetTyping;

            client.OnGetMessageReceivedClient += client_OnGetMessageReceivedClient;
            client.OnGetMessageReceivedServer += client_OnGetMessageReceivedServer;

            client.OnNotificationPicture += client_OnNotificationPicture;


            client.OnGetSyncResult += client_OnGetSyncResult;
            client.OnGetPrivacySettings += client_OnGetPrivacySettings;
            client.OnGetPaused += client_OnGetPaused;

            this.bgWorker = new BackgroundWorker();

        }

        void client_OnNotificationPicture(string type, string waID, string id)
        {
        }

        void client_OnGetTyping(string jid)
        {
            try
            {
                //if (!rsRoster.Instance.Contains(jid))
                //    creatersRosterItem(jid);

                //if (rsRoster.Instance.Contains(jid))
                //    rsRoster.Instance.Get(jid).Typing = !rsRoster.Instance.Get(jid).Typing;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        void client_OnGetSyncResult(int index, string sid, Dictionary<string, string> existingUsers, string[] failedNumbers)
        {

        }

        void client_OnGetStatus(string from, string type, string name, string status)
        {
            //if (!rsRoster.Instance.Contains(from))
            //    creatersRosterItem(from, name);

            if (rsRoster.Instance.Contains(from) && type == "result")
                rsRoster.Instance.Get(from).Status = status;
        }

        void client_OnGetPrivacySettings(Dictionary<ApiBase.VisibilityCategory, ApiBase.VisibilitySetting> settings)
        {

        }

        void client_OnGetPresence(string from, string type)
        {
            //if (!rsRoster.Instance.Contains(from))
            //    creatersRosterItem(from);

            //if (rsRoster.Instance.Contains(from))
            //    rsRoster.Instance.Get(from).Online = true;
        }

        void client_OnGetPhotoPreview(string from, string id, byte[] data)
        {
            try
            {
                if (!rsRoster.Instance.Contains(from))
                    return;

                string strProfilePicturesPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Media\ProfilePictures";

                MemoryStream ms = new MemoryStream(data);
                Image profilePic = Image.FromStream(ms);
                profilePic.Save(strProfilePicturesPath + Path.DirectorySeparatorChar + from.Split('@')[0] + "_preview.jpg", ImageFormat.Jpeg);

                rsRoster.Instance.Get(from).AvatarPreviewURL = strProfilePicturesPath + Path.DirectorySeparatorChar + from.Split('@')[0] + "_preview.jpg";

            }
            catch (Exception ex)
            {

            }
        }

        void client_OnGetPhoto(string from, string id, byte[] data)
        {

        }

        void client_OnGetPaused(string from)
        {

        }

        void client_OnGetParticipantRenamed(string gjid, string oldJid, string newJid, DateTime time)
        {

        }

        void client_OnGetParticipantRemoved(string gjid, string jid, string author, DateTime time)
        {

        }

        void client_OnGetParticipantAdded(string gjid, string jid, DateTime time)
        {

        }

        void client_OnGetMessageVideo(ProtocolTreeNode mediaNode, string from, string id, string fileName, int fileSize, string url, byte[] preview)
        {

        }

        void client_OnGetMessageVcard(ProtocolTreeNode vcardNode, string from, string id, string name, byte[] data)
        {

        }

        void client_OnGetMessageReceivedServer(string from, string id)
        {
            //if (rsRoster.Instance.Contains(from))
            //    rsRoster.Instance.Get(from).Messages.FirstOrDefault(msg => msg.Id == id).DeliveredToServer = true;
        }

        void client_OnGetMessageReceivedClient(string from, string id)
        {
            //if (rsRoster.Instance.Contains(from))
            //    rsRoster.Instance.Get(from).Messages.FirstOrDefault(msg => msg.Id == id).DeliveredToClient = true;
        }

        void client_OnGetMessageLocation(ProtocolTreeNode locationNode, string from, string id, double lon, double lat, string url, string name, byte[] preview)
        {

        }

        void client_OnGetMessageImage(ProtocolTreeNode mediaNode, string from, string id, string fileName, int fileSize, string url, byte[] preview)
        {
            
        }

        void client_OnGetMessageAudio(ProtocolTreeNode mediaNode, string from, string id, string fileName, int fileSize, string url, byte[] preview)
        {

        }

        void client_OnGetLastSeen(string from, DateTime lastSeen)
        {
            try
            {
                if (rsRoster.Instance.Contains(from))
                    rsRoster.Instance.Get(from).LastActivity = lastSeen;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void client_OnGetGroupSubject(string gjid, string jid, string username, string subject, DateTime time)
        {

        }

        void client_OnGetGroups(WhatsAppApi.Response.WaGroupInfo[] groups)
        {
            foreach(var grp in groups)
            {
                
            }
        }

        void client_OnGetGroupParticipants(string gjid, string[] jids)
        {

        }

        void client_OnGetContactName(string from, string contactName)
        {
            try
            {
                //if (!rsRoster.Instance.Contains(from))
                //    creatersRosterItem(from, contactName);
                if (rsRoster.Instance.Contains(from))
                    rsRoster.Instance.Get(from).Name = contactName;
            }
            catch (Exception ex)
            {

            }
        }

        void client_OnError(string id, string from, int code, string text)
        {

        }

        private void ProcessMessages(object sender, DoWorkEventArgs args)
        {
            if (sender == null)
                return;

            while (this.isRunning)
            {
                if (!client.HasMessages())
                {
                    client.pollMessage(true);
                    
                    Thread.Sleep(100);
                    continue;
                }
            }
        }

        private Connection()
        {
        }

        private void client_OnConnectFailed(Exception ex)
        {
            if (this.OnConnectionFailed != null)
                this.OnConnectionFailed(ex);
        }

        void client_OnGetMessage(WhatsAppApi.Helper.ProtocolTreeNode messageNode, string from, string id, string name, string message, bool receipt_sent)
        {
            rsItemBase rsRosterItem = rsRoster.Instance.Get(from);

            if (rsRosterItem == null)
            {
                rsRosterItem = new rsItemBase()
                {
                    Jid = from,
                    Name = name,
                    Messages = new System.Collections.ObjectModel.ObservableCollection<rsMessage>()
                };
                rsRoster.Instance.Add(rsRosterItem);

                client.SendGetPhoto(from, "", false);
                client.SendGetStatuses(new string[] { from });
            }

            rsRosterItem.Add(new rsMessage()
                {
                    Text = message,
                    Time = DateTime.Now,
                    ID = id,
                    FromJid = from,
                    ToJid = "",
                    Direction = Enumerations.MessageDirection.Incoming
                });
        }

        public void Login()
        {
            try
            {
                client.Connect();


                var rsRosterItem1 = new rsItemBase()
                {
                    Jid = "919619464927@s.whatsapp.net",
                    Name = "Pradeep",
                    Messages = new System.Collections.ObjectModel.ObservableCollection<rsMessage>()
                };
                rsRoster.Instance.Add(rsRosterItem1);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SendMessage(string toNumber, string message)
        {
            string strMessageID = client.SendMessage(toNumber, message);
        }

        void client_OnDisconnect(Exception ex)
        {
            throw ex;
        }

        void client_OnLoginSuccess(string phoneNumber, byte[] data)
        {
            //var rsRosterItem1 = new rsItemBase()
            //{
            //    Jid = "919619464927@s.whatsapp.net",
            //    Name = "Pradeep",
            //    Messages = new System.Collections.ObjectModel.ObservableCollection<rsMessage>()
            //};
            //rsRoster.Instance.Add(rsRosterItem1);
            //client.SendGetPhoto(rsRosterItem1.Jid, "", false);
            //client.SendGetStatuses(new string[] { rsRosterItem1.Jid });

            #region :Commented:
            //var rsRosterItem = new rsRosterItem()
            //{
            //    ID = "918454084861",
            //    Name = "Dharmesh",
            //    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
            //};

            //var rsRosterItem1 = new rsRosterItem()
            //{
            //    ID = "919619464927",
            //    Name = "Pradeep",
            //    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
            //};

            //var rsRosterItem2 = new rsRosterItem()
            //{
            //    ID = "917506360307",
            //    Name = "Sumedh",
            //    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
            //};

            //var rsRosterItem4 = new rsRosterItem()
            //{
            //    ID = "919773478087",
            //    Name = "Omkar",
            //    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
            //};
            //rsRoster.Instance.Add(rsRosterItem);
            //rsRoster.Instance.Add(rsRosterItem1);
            //rsRoster.Instance.Add(rsRosterItem2);
            //rsRoster.Instance.Add(rsRosterItem4); 
            #endregion

            this.bgWorker.DoWork += ProcessMessages;
            this.bgWorker.RunWorkerAsync();
            this.isRunning = true;
            client.SendGetGroups();
        }

        void client_OnLoginFailed(string data)
        {
            if (this.OnLoginFailed != null)
                this.OnLoginFailed(data);
        }

        void client_OnConnectSuccess()
        {
            client.Login(null);
            Console.WriteLine("connected successfully");
        }

        //private void creatersRosterItem(string jid, string name = "")
        //{
        //    if (jid.Contains("9594991694"))
        //        return;

        //    if (!rsRoster.Instance.Contains(jid))
        //    {
        //        rsRoster.Instance.Items.Add(new rsRosterItem
        //        {
        //            JID = jid,
        //            Name = name
        //        });
        //    }

        //    client.SendGetPhoto(jid, "", false);
        //    client.SendGetStatuses(new string[] { jid });
        //}
    }
}

























#region :old:

//using System;
//using WhatsAppApi;
//using System.ComponentModel;
//using System.Threading;
//using WhatsAppApi.Helper;
//using System.Linq;
//using System.Collections.Generic;
//using System.IO;
//using System.Reflection;
//using System.Drawing;
//using System.Drawing.Imaging;

//namespace Whatsapp.Desktop.Business
//{
//    public class Connection
//    {
//        private volatile bool isRunning;
//        private BackgroundWorker bgWorker;

//        private WhatsApp client;

//        public delegate void OnConnectionFailedDelegate(Exception ex);
//        public event OnConnectionFailedDelegate OnConnectionFailed;

//        public delegate void OnLoginFailedDelegate(string message);
//        public event OnLoginFailedDelegate OnLoginFailed;

//        public delegate void OnLoginSuccessDelegate();
//        public event OnLoginSuccessDelegate OnLoginSuccess;

//        private static Connection instance;
//        public static Connection Instance
//        {
//            get
//            {
//                if (instance == null)
//                    instance = new Connection();

//                return instance;
//            }
//        }

//        public void Initialize(string number, string password, string nick, bool debug, bool hidden)
//        {
//            client = new WhatsApp(number, password, nick, debug, hidden);

//            client.OnConnectFailed += client_OnConnectFailed;
//            client.OnConnectSuccess += client_OnConnectSuccess;
//            client.OnDisconnect += client_OnDisconnect;
//            client.OnError += client_OnError;
//            client.OnLoginFailed += client_OnLoginFailed;
//            client.OnLoginSuccess += client_OnLoginSuccess;

//            client.OnGetContactName += client_OnGetContactName;
//            client.OnGetLastSeen += client_OnGetLastSeen;




//            client.OnGetGroupSubject += client_OnGetGroupSubject;
//            client.OnGetGroups += client_OnGetGroups;
//            client.OnGetGroupParticipants += client_OnGetGroupParticipants;
//            client.OnGetParticipantAdded += client_OnGetParticipantAdded;
//            client.OnGetParticipantRemoved += client_OnGetParticipantRemoved;
//            client.OnGetParticipantRenamed += client_OnGetParticipantRenamed;

//            client.OnGetMessage += client_OnGetMessage;
//            client.OnGetMessageAudio += client_OnGetMessageAudio;
//            client.OnGetMessageImage += client_OnGetMessageImage;
//            client.OnGetMessageLocation += client_OnGetMessageLocation;
//            client.OnGetMessageVcard += client_OnGetMessageVcard;
//            client.OnGetMessageVideo += client_OnGetMessageVideo;

//            client.OnGetPhotoPreview += client_OnGetPhotoPreview;
//            client.OnGetPhoto += client_OnGetPhoto;
//            client.OnGetPresence += client_OnGetPresence;
//            client.OnGetStatus += client_OnGetStatus;
//            client.OnGetTyping += client_OnGetTyping;

//            client.OnGetMessageReceivedClient += client_OnGetMessageReceivedClient;
//            client.OnGetMessageReceivedServer += client_OnGetMessageReceivedServer;

//            client.OnNotificationPicture += client_OnNotificationPicture;


//            client.OnGetSyncResult += client_OnGetSyncResult;
//            client.OnGetPrivacySettings += client_OnGetPrivacySettings;
//            client.OnGetPaused += client_OnGetPaused;

//            this.bgWorker = new BackgroundWorker();

//        }

//        void client_OnNotificationPicture(string type, string waID, string id)
//        {
//        }

//        void client_OnGetTyping(string jid)
//        {
//            try
//            {
//                //if (!Roster.Instance.Contains(jid))
//                //    createRosterItem(jid);

//                if (Roster.Instance.Contains(jid))
//                    Roster.Instance.Get(jid).Typing = !Roster.Instance.Get(jid).Typing;
//            }
//            catch (Exception ex)
//            {

//                throw;
//            }
//        }

//        void client_OnGetSyncResult(int index, string sid, Dictionary<string, string> existingUsers, string[] failedNumbers)
//        {

//        }

//        void client_OnGetStatus(string from, string type, string name, string status)
//        {
//            //if (!Roster.Instance.Contains(from))
//            //    createRosterItem(from, name);

//            if (Roster.Instance.Contains(from) && type == "result")
//                Roster.Instance.Get(from).Status = status;
//        }

//        void client_OnGetPrivacySettings(Dictionary<ApiBase.VisibilityCategory, ApiBase.VisibilitySetting> settings)
//        {

//        }

//        void client_OnGetPresence(string from, string type)
//        {
//            //if (!Roster.Instance.Contains(from))
//            //    createRosterItem(from);

//            if (Roster.Instance.Contains(from))
//                Roster.Instance.Get(from).Online = true;
//        }

//        void client_OnGetPhotoPreview(string from, string id, byte[] data)
//        {
//            try
//            {
//                if (!Roster.Instance.Contains(from))
//                    return;

//                string strProfilePicturesPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Media\ProfilePictures";

//                MemoryStream ms = new MemoryStream(data);
//                Image profilePic = Image.FromStream(ms);
//                profilePic.Save(strProfilePicturesPath + Path.DirectorySeparatorChar + from.Split('@')[0] + "_preview.jpg", ImageFormat.Jpeg);

//                Roster.Instance.Get(from).AvatarPreviewURL = strProfilePicturesPath + Path.DirectorySeparatorChar + from.Split('@')[0] + "_preview.jpg";

//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        void client_OnGetPhoto(string from, string id, byte[] data)
//        {

//        }

//        void client_OnGetPaused(string from)
//        {

//        }

//        void client_OnGetParticipantRenamed(string gjid, string oldJid, string newJid, DateTime time)
//        {

//        }

//        void client_OnGetParticipantRemoved(string gjid, string jid, string author, DateTime time)
//        {

//        }

//        void client_OnGetParticipantAdded(string gjid, string jid, DateTime time)
//        {

//        }

//        void client_OnGetMessageVideo(ProtocolTreeNode mediaNode, string from, string id, string fileName, int fileSize, string url, byte[] preview)
//        {

//        }

//        void client_OnGetMessageVcard(ProtocolTreeNode vcardNode, string from, string id, string name, byte[] data)
//        {

//        }

//        void client_OnGetMessageReceivedServer(string from, string id)
//        {
//            //if (Roster.Instance.Contains(from))
//            //    Roster.Instance.Get(from).Messages.FirstOrDefault(msg => msg.Id == id).DeliveredToServer = true;
//        }

//        void client_OnGetMessageReceivedClient(string from, string id)
//        {
//            //if (Roster.Instance.Contains(from))
//            //    Roster.Instance.Get(from).Messages.FirstOrDefault(msg => msg.Id == id).DeliveredToClient = true;
//        }

//        void client_OnGetMessageLocation(ProtocolTreeNode locationNode, string from, string id, double lon, double lat, string url, string name, byte[] preview)
//        {

//        }

//        void client_OnGetMessageImage(ProtocolTreeNode mediaNode, string from, string id, string fileName, int fileSize, string url, byte[] preview)
//        {

//        }

//        void client_OnGetMessageAudio(ProtocolTreeNode mediaNode, string from, string id, string fileName, int fileSize, string url, byte[] preview)
//        {

//        }

//        void client_OnGetLastSeen(string from, DateTime lastSeen)
//        {
//            try
//            {
//                if (Roster.Instance.Contains(from))
//                    Roster.Instance.Get(from).LastSeen = lastSeen;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        void client_OnGetGroupSubject(string gjid, string jid, string username, string subject, DateTime time)
//        {

//        }

//        void client_OnGetGroups(WhatsAppApi.Response.WaGroupInfo[] groups)
//        {
//            foreach(var grp in groups)
//            {

//            }
//        }

//        void client_OnGetGroupParticipants(string gjid, string[] jids)
//        {

//        }

//        void client_OnGetContactName(string from, string contactName)
//        {
//            try
//            {
//                //if (!Roster.Instance.Contains(from))
//                //    createRosterItem(from, contactName);
//                if (Roster.Instance.Contains(from))
//                    Roster.Instance.Get(from).Name = contactName;
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        void client_OnError(string id, string from, int code, string text)
//        {

//        }

//        private void ProcessMessages(object sender, DoWorkEventArgs args)
//        {
//            if (sender == null)
//                return;

//            while (this.isRunning)
//            {
//                if (!client.HasMessages())
//                {
//                    client.pollMessage(true);
//                    client.SendGetGroups();
//                    Thread.Sleep(100);
//                    continue;
//                }
//            }
//        }

//        private Connection()
//        {
//        }

//        private void client_OnConnectFailed(Exception ex)
//        {
//            if (this.OnConnectionFailed != null)
//                this.OnConnectionFailed(ex);
//        }

//        void client_OnGetMessage(WhatsAppApi.Helper.ProtocolTreeNode messageNode, string from, string id, string name, string message, bool receipt_sent)
//        {
//            RosterItem rosterItem = Roster.Instance.Get(from);

//            if (rosterItem == null)
//            {
//                rosterItem = new RosterItem()
//                {
//                    JID = from,
//                    Name = name,
//                    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
//                };
//                Roster.Instance.Add(rosterItem);

//                client.SendGetPhoto(from, "", false);
//                client.SendGetStatuses(new string[] { from });
//            }

//            rosterItem.Add(new Message()
//                {
//                    Text = message,
//                    Time = DateTime.Now,
//                    ReadByClient = false,
//                    Id = id,
//                    FromUser = from,
//                    ToAccount = "",
//                    MessageType = "chat"
//                });
//        }

//        public void Login()
//        {
//            try
//            {
//                client.Connect();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//        }

//        public void SendMessage(string toNumber, string message)
//        {
//            string strMessageID = client.SendMessage(toNumber, message);
//        }

//        void client_OnDisconnect(Exception ex)
//        {
//            throw ex;
//        }

//        void client_OnLoginSuccess(string phoneNumber, byte[] data)
//        {
//            var rosterItem1 = new RosterItem()
//            {
//                JID = "919619464927@s.whatsapp.net",
//                Name = "Pradeep",
//                Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
//            };
//            Roster.Instance.Add(rosterItem1);
//            client.SendGetPhoto(rosterItem1.JID, "", false);
//            client.SendGetStatuses(new string[] { rosterItem1.JID });

//            #region :Commented:
//            //var rosterItem = new RosterItem()
//            //{
//            //    ID = "918454084861",
//            //    Name = "Dharmesh",
//            //    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
//            //};

//            //var rosterItem1 = new RosterItem()
//            //{
//            //    ID = "919619464927",
//            //    Name = "Pradeep",
//            //    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
//            //};

//            //var rosterItem2 = new RosterItem()
//            //{
//            //    ID = "917506360307",
//            //    Name = "Sumedh",
//            //    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
//            //};

//            //var rosterItem4 = new RosterItem()
//            //{
//            //    ID = "919773478087",
//            //    Name = "Omkar",
//            //    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
//            //};
//            //Roster.Instance.Add(rosterItem);
//            //Roster.Instance.Add(rosterItem1);
//            //Roster.Instance.Add(rosterItem2);
//            //Roster.Instance.Add(rosterItem4); 
//            #endregion

//            this.bgWorker.DoWork += ProcessMessages;
//            this.bgWorker.RunWorkerAsync();
//            this.isRunning = true;
//        }

//        void client_OnLoginFailed(string data)
//        {
//            if (this.OnLoginFailed != null)
//                this.OnLoginFailed(data);
//        }

//        void client_OnConnectSuccess()
//        {
//            client.Login(null);
//            Console.WriteLine("connected successfully");
//        }

//        //private void createRosterItem(string jid, string name = "")
//        //{
//        //    if (jid.Contains("9594991694"))
//        //        return;

//        //    if (!Roster.Instance.Contains(jid))
//        //    {
//        //        Roster.Instance.Items.Add(new RosterItem
//        //        {
//        //            JID = jid,
//        //            Name = name
//        //        });
//        //    }

//        //    client.SendGetPhoto(jid, "", false);
//        //    client.SendGetStatuses(new string[] { jid });
//        //}
//    }
//} 
#endregion