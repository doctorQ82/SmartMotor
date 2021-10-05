using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMotor.Models;
namespace SmartMotor.Services
{
    interface IChangePayment
    {
        IEnumerable<ChangePaymentUnPaid> UnPaidRead();
        void UpdatePaymentType(long pid, string paymentUrl, string PaymentType);

        void DeleteQPLink(string qpid);

        void SendSMSChangePayment(long pid);

        void GenQuickPay(long pid);

        Int64 InsertSMSLogAlert(SendSMSSecurePay pay);

        IEnumerable<string> GetPaymentType();

        IEnumerable<string> GetStatusPayment();

        void UpdateMobile(ChangePaymentUnPaid data);

        void InsPaymentSummaryLog(Int64 PID, string invoiceNo, string qpid, string LogType);
    }
}
