using System;
using System.Collections.Generic;

#nullable disable

namespace SmartMotor.Data
{
    public partial class TPolicyInfo
    {
        public long RnPolicy { get; set; }
        public string PolicyNo { get; set; }
        public string GpsId { get; set; }
        public string PolicyStatus { get; set; }
        public decimal? PolicyBasePremium { get; set; }
        public decimal? PolicyPremiumPerKm { get; set; }
        public string AssuredName { get; set; }
        public string PolicyType { get; set; }
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public string CarRegistrationNo { get; set; }
        public string ProvinceCode { get; set; }
        public string CarModel { get; set; }
        public decimal? CapMaxMonth { get; set; }
        public decimal? CapMaxYear { get; set; }
        public string UserIdentity { get; set; }
        public string PreviousPolicy { get; set; }
        public DateTime? TransferOutDate { get; set; }
        public DateTime? TransferInDate { get; set; }
        public bool? FlagSend { get; set; }
        public DateTime? SendDate { get; set; }
    }
}
