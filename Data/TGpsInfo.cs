using System;
using System.Collections.Generic;

#nullable disable

namespace SmartMotor.Data
{
    public partial class TGpsInfo
    {
        public long Sid { get; set; }
        public string GpsId { get; set; }
        public string GpsStatus { get; set; }
        public DateTime? GpsRegister { get; set; }
        public string OrderPerfixId { get; set; }
        public DateTime? UseDate { get; set; }
        public string StoreCard { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
