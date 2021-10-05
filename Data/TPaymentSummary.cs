using System;
using System.Collections.Generic;

#nullable disable

namespace SmartMotor.Data
{
    public partial class TPaymentSummary
    {
        public long Pid { get; set; }
        public string PolicyNo { get; set; }
        public string GpsId { get; set; }
        public int PeriodNo { get; set; }
        public DateTime StartBillDate { get; set; }
        public DateTime EndBillDate { get; set; }
        public decimal? TotalDistance { get; set; }
        public decimal? CurrentDistance { get; set; }
        public decimal? PreviousDistance { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? PremiumPerKm { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalAmountInsurer { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public string InvoiceNo { get; set; }
        public string PaymentUrl { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? PaidDate { get; set; }
        public string TaxInvoiceUrl { get; set; }
        public string PaymentChannel { get; set; }
        public string Status { get; set; }
        public string FileName { get; set; }
        public DateTime? Created { get; set; }
        public string DateValue { get; set; }
    }
}
