using WhatsAppApi.Response;

namespace Whatsapp.Desktop.Communication.Models.Response
{
    public class GroupInfo
    {
        public long Creation { get; set; }
        public string ID { get; set; }
        public string Owner { get; set; }
        public string Subject { get; set; }
        public string SubjectChanged { get; set; }
        public long SubjectChangedTime { get; set; }

        public GroupInfo(WaGroupInfo waGroupInfo) 
        {
            this.Creation = waGroupInfo.creation;
            this.ID = waGroupInfo.id;
            this.Owner = waGroupInfo.owner;
            this.Subject = waGroupInfo.subject;
            this.SubjectChanged = SubjectChanged;
            this.SubjectChangedTime = SubjectChangedTime;
        }
    }
}
