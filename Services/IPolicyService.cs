using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMotor.Models;
namespace SmartMotor.Services
{
    interface IPolicyService
    {
        IEnumerable<PolicyInquiryViewModel> Inquiry(string search);

        IEnumerable<PolicyInquiryViewModel> InqTransaction(string search);

        IEnumerable<PolicyPaymentDetail> InqDetail(Int64 rnPolicy);

        IEnumerable<PolicyTransaction> TransactionLog(string policyNo);

        void ChangeGPS(Int64 rnPolicy, string gpsID, string invoiceNo);
    }
}
