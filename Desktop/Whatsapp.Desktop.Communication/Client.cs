using System;
using System.Linq;
using WhatsAppApi;

namespace Whatsapp.Desktop.Communication
{
    public class Client
    {
        private WhatsApp _connection;

        public delegate void OnConnectedDelegate();
        public event OnConnectedDelegate OnConnected;

        public delegate void OnDisconnectedDelegate();
        public event OnDisconnectedDelegate OnDisconnected;

        public delegate void OnMessageReceivedDelegate();
        public event OnMessageReceivedDelegate OnMessageReceived;

        public delegate void OnErrorDelegate(string id, string from, int code, string text);
        public event OnErrorDelegate OnError;

        public delegate void OnGetContactNameDelegate(string from, string contactName);
        public event OnGetContactNameDelegate OnGetContactName;

        public delegate void OnGetGroupParticipantsDelegate(string gjid, string[] jids);
        public event OnGetGroupParticipantsDelegate OnGetGroupParticipants;

        public delegate void OnGetGroupsDelegate(Models.Response.GroupInfo[] groups);
        public event OnGetGroupsDelegate OnGetGroups;

        public delegate void OnGetGroupSubjectDelegate(string gjid, string jid, string username, string subject, DateTime time);
        public event OnGetGroupSubjectDelegate OnGetGroupSubject;

        public delegate void OnGetLastSeenDelegate(string from, DateTime lastSeen);
        public event OnGetLastSeenDelegate OnGetLastSeen;

        public Client(string number,string password, string nickName,bool debug, bool hidden)
        {
            try
            {
                _connection = new WhatsApp(number, password, nickName, debug, hidden);

                _connection.OnConnectFailed += _connection_OnConnectFailed;
                _connection.OnConnectSuccess +=_connection_OnConnectSuccess;
                _connection.OnDisconnect += _connection_OnDisconnect;
                _connection.OnError += _connection_OnError;
                _connection.OnGetContactName += _connection_OnGetContactName;
                _connection.OnGetGroupParticipants += _connection_OnGetGroupParticipants;
                _connection.OnGetGroups += _connection_OnGetGroups;
                _connection.OnGetGroupSubject += _connection_OnGetGroupSubject;
                _connection.OnGetLastSeen += _connection_OnGetLastSeen;
                _connection.OnGetMessage += _connection_OnGetMessage;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        void _connection_OnGetMessage(WhatsAppApi.Helper.ProtocolTreeNode messageNode, string from, string id, string name, string message, bool receipt_sent)
        {
            throw new NotImplementedException();
        }

        void _connection_OnGetLastSeen(string from, DateTime lastSeen)
        {
            if (this.OnGetLastSeen != null)
                this.OnGetLastSeen(from, lastSeen);
        }

        void _connection_OnGetGroupSubject(string gjid, string jid, string username, string subject, DateTime time)
        {
            if (this.OnGetGroupSubject != null)
                this.OnGetGroupSubject(gjid, jid, username, subject, time);
        }

        void _connection_OnGetGroups(WhatsAppApi.Response.WaGroupInfo[] groups)
        {
            if (this.OnGetGroups == null)
                this.OnGetGroups(groups.ToList().Select(waGroup => new Models.Response.GroupInfo(waGroup)).ToArray<Models.Response.GroupInfo>());
        }

        void _connection_OnGetGroupParticipants(string gjid, string[] jids)
        {
            if (this.OnGetGroupParticipants != null)
                this.OnGetGroupParticipants(gjid, jids);
        }

        void _connection_OnGetContactName(string from, string contactName)
        {
            if (this.OnGetContactName != null)
                this.OnGetContactName(from,contactName);
        }

        void _connection_OnError(string id, string from, int code, string text)
        {
            if (this.OnError != null)
                this.OnError(id, from, code, text);
        }

        void _connection_OnDisconnect(Exception ex)
        {
            if (this.OnDisconnected != null)
                this.OnDisconnected();
        }

        private void _connection_OnConnectSuccess()
        {
            if (this.OnConnected != null)
                this.OnConnected();
        }

        void _connection_OnConnectFailed(Exception ex)
        {
            throw (ex);
        }

        void connection_OnPresence(object sender, Presence pres)
        {
            if (OnPresenceReceived != null)
                OnPresenceReceived(pres);
        }

        void connection_OnIq(object sender, IQ iq)
        {
            if (OnIqReceived != null)
                OnIqReceived(iq);
        }

        void connection_OnMessage(object sender, Message msg)
        {
            if (OnMessageReceived != null)
                OnMessageReceived(msg);            
        }

        void connection_OnStreamError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            throw new NotImplementedException();
        }

        void connection_OnSocketError(object sender, Exception ex)
        {
            throw ex;
        }

        void connection_OnError(object sender, Exception ex)
        {
            //throw ex;            
        }

        void connection_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            if (OnAuthorizationError != null)
                OnAuthorizationError();
        }

        private string server;
        public string Server
        {
            get
            {
                return this.server;
            }
            set
            {
                this.server = value;
                connection.Server = value;
            }
        }

        private int port;
        public int Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
                connection.Port = value;
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
                connection.Username = value;
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
                connection.Password = value;
            }
        }

        public void Connect()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SignOut()
        {
            connection.Close();
        }

        public void GetVCard(Jid jid)
        {
            VcardIq viq = new VcardIq(IqType.get, jid);
            connection.Send(viq);
        }

        void connection_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
        {
            if (OnRosterItemReceived != null)
                OnRosterItemReceived(item);
        }

        void connection_OnLogin(object sender)
        {
            if (OnLogin != null)
                OnLogin(sender);
        }

        public void Send(Jid toJid, string message)
        {
            Message chatMessage = new Message();

            chatMessage.Type = MessageType.chat;
            chatMessage.To = toJid;
            chatMessage.Body = message;

            connection.Send(chatMessage);
        }

        public bool SendDeliveryReciept(agsXMPP.protocol.client.Message message)
        {
            bool bSent = true;

            try
            {
                if (message.XEvent == null)
                    message.XEvent = new agsXMPP.protocol.x.Event();

                message.XEvent.Delivered = true;
                connection.Send(message);
            }
            catch (Exception)
            {
                bSent = false;
            }
            return bSent;
        }

        public bool SendReadReciept(agsXMPP.protocol.client.Message message)
        {
            bool bSent = true;

            try
            {
                if (message.XEvent == null)
                    message.XEvent = new agsXMPP.protocol.x.Event();

                message.XEvent.Displayed = true;
                connection.Send(message);
            }
            catch (Exception)
            {
                bSent = false;
            }
            return bSent;
        }


        public void SendIQ(agsXMPP.protocol.client.IQ iq)
        {
            connection.IqGrabber.SendIq(iq);
        }

        public void Discover()
        {
            DiscoManager discoManager = new DiscoManager(connection);
            discoManager.DiscoverItems(new Jid(connection.Server), new IqCB(OnDiscoServerResult), null);
        }

        private void OnDiscoServerResult(object sender, IQ iq, object data)
        {
            if (iq.Type == IqType.result)
            {
                Element query = iq.Query;
                if (query != null && query.GetType() == typeof(DiscoItems))
                {
                    DiscoItems items = query as DiscoItems;

                    if (items != null)
                    {
                        DiscoItem[] itms = items.GetDiscoItems();
                        foreach (DiscoItem itm in itms)
                        {
                            if (itm.Jid != null)
                            {

                            }
                        }

                    }
                }
            }
        }
    }
}