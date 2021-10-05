using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class Message
    {
        public string mobileNo { get; set; }
        public string smsText { get; set; }
    }


    public class SMSMulti
    {
        public List<Message> message { get; set; }
    }

    public class MessagePart
    {
        public string MsgId { get; set; }
        public int PartId { get; set; }
        public string Text { get; set; }
    }

    public class MsgData
    {
        public string Number { get; set; }
        public List<MessagePart> MessageParts { get; set; }
    }

    public class SMSResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string JobId { get; set; }
        public List<MsgData> MessageData { get; set; }
    }
}
