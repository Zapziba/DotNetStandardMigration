using System;
using System.Collections.Generic;
using System.Text;

namespace BaseClasses
{
    public enum MessageType
    {
        Added,
        Deleted,
        Changed,
    }
    public class Message
    {
        public MessageType MessageType { get; private set; }
        public object RecordID { get; private set; }
        public Message(object recordID, MessageType messageType)
        {
            RecordID = recordID;
            MessageType = messageType;
        }


    }
}
