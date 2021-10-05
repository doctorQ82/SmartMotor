using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class PaymentUnPaid
    {
        public int _pid { get; set; }
        public string _policy_no { get; set; }
        public string _gps_id { get; set; }
        public int _period_no { get; set; }
        public string _start_bill_date { get; set; }
        public string _end_bill_date { get; set; }
        public decimal _total_amount { get; set; }
        public decimal _premium_per_km { get; set; }

        public decimal _total_amount_insurer { get; set; }
        public string _payment_due_date { get; set; }
        public string _invoice_no { get; set; }

        public string _payment_type { get; set; }
        public string _payment_status { get; set; }
        public string _assuredName { get; set; }
        public string _PolicyType { get; set; }
        public string _PolicyStatus { get; set; }
        public string _PaymentUrl { get; set; }

        public string _carRegistrationNo { get; set; }
    }


    public class ChangePaymentUnPaid
    {
        public Int64 pid { get; set; }
        public string Policy_no { get; set; }
        public string start_bill_date { get; set; }
        public string end_bill_date { get; set; }
        public decimal total_distance { get; set; }
        public decimal total_amount { get; set; }
        public string payment_due_date { get; set; }
        public string invoice_no { get; set; }
        public string payment_url { get; set; }

        public string payment_type { get; set; }

        public string assuredName { get; set; }

        public string carRegistrationNo { get; set; }

        public string PayMode { get; set; }

        public string Mobile_No { get; set; }
        
        public string qpID { get; set; }
        public string SecurePay { get; set; }
        public string ConcatData { get; set; }

        public bool IsChange { get; set; }

        public bool IsQP { get; set; }

        public string payment_status { get; set; }
        public string userIdentity { get; set; }
        
    }          
}
