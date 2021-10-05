using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class SendSMSSecurePay
    {
        public Int64 _pid { get; set; }
        public string _invoiceno { get; set; }
        public string _policyNo { get; set; }
        public string _userIdentity { get; set; }
        public string _total_distance { get; set; }
        public string _total_amount { get; set; }
        public string _payment_url { get; set; }
        public string _DueDate { get; set; }
        public string _Message_Type { get; set; }
        public string _Payment_Type { get; set; }
        public string _SecurePay { get; set; }
        public string _SMS_Message { get; set; }
        public string _Mobile_No { get; set; }
    }
}


