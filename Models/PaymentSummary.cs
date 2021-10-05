using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class PaymentSummary
    {
        public int _pid { get; set; }
        public string _policy_no{ get; set; }
        public string _gps_id{ get; set; }
        public int _period_no{ get; set; }
        public string _start_bill_date { get; set; }
        public string _end_bill_date { get; set; }
        public decimal _total_distance{ get; set; }
        public decimal _current_distance { get; set; }
        public decimal _previous_distance { get; set; }
        public decimal _total_amount { get; set; }
        public decimal _premium_per_km { get; set; }
        public decimal _total_discount { get; set; }
        public decimal _total_amount_insurer { get; set; }
        public string _payment_due_date { get; set; }
        public string _invoice_no{ get; set; }
        public string _payment_url{ get; set; }
        public string _payment_type{ get; set; }
        public string _payment_status{ get; set; }
        public string _paid_date { get; set; }
        public string _tax_invoice_url{ get; set; }
        public string _payment_channel{ get; set; }

        
    }
}
