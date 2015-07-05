namespace Whatsapp.Desktop.Business.Enumerations
{
    public enum MessageType : short
    {
        Incoming,
        Outgoing
    }

    public enum RosterItemType
    {
        Contact,
        Group
    }

    public enum MessageStatus : short
    {
        None = 0,
        Sent,
        DeliveredToServer,
        DeliveredToClient,
        ReadByClient
    }
}