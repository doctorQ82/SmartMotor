using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class PolicyViewModel
    {
        public string assuredName { get; set; }
        public string policyNo { get; set; }
        public string policyStartDate { get; set; }
        public string policyEndDate { get; set; }
        public string policyBasePremium { get; set; }
        public string policyPremiumPerKm { get; set; }
        public string carRegistrationNo { get; set; }
        public string gpsId { get; set; }
        public string carModel { get; set; }
        public string PolicyStatus { get; set; }
        public string PolicyType { get; set; }

    }

    public class PolicyInquiryViewModel
    {
        public Int32 rnPolicy { get; set; }
        public string assuredName { get; set; }
        public string policyNo { get; set; }
        public string carRegistrationNo { get; set; }

        public string policyStartDate { get; set; }
        public string policyEndDate { get; set; }
        public string policyBasePremium { get; set; }
        public string policyPremiumPerKm { get; set; }
        public string PolicyType { get; set; }
        public string PolicyStatus { get; set; }

        public string gpsId { get; set; }
        public string carModel { get; set; }
    }

    public class PolicyPaymentDetail
    {
        public string start_bill_date { get; set; }
        public string end_bill_date { get; set; }
        public string period_no { get; set; }
        public string invoice_no { get; set; }
        public string payment_due_date { get; set; }
        public string status { get; set; }
        public string payment_type { get; set; }
        public string payment_status { get; set; }
        public string paid_date { get; set; }
        public string total_distance { get; set; }
        public string premium_per_km { get; set; }
        public string total_amount_insurer { get; set; }

        public string gps_id { get; set; }
    }

    public class PolicyTransaction
    {
        public string LogType { get; set; }
        public string atDate { get; set; }
        public string id { get; set; }
        public string policyNo { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }

    public class NotificationAlert
    {
        public string RunNo { get; set; }
        public string policy_no { get; set; }
        public string invoice_no { get; set; }
        public string due_date { get; set; }
        public string Message_Type { get; set; }
        public string MessageText { get; set; }
        public string SendDate { get; set; }
    }

}

