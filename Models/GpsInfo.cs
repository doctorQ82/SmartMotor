using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class GpsInfo
    {
        public float SID { get; set; }
        public string GpsId { get; set; }

        [UIHint("ClientStatus")]
        public GpsStatus GpsStatus { get; set; }

        public DateTime Gps_Register { get; set; }

        public string OrderPerfixID { get; set; }

        public DateTime UseDate { get; set; }
    }

    public class GpsStatus
    {
        public string Status_Code { get; set; }

        public string Status { get; set; }

    }
}
