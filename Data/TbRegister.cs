using System;
using System.Collections.Generic;

#nullable disable

namespace SmartMotor.Data
{
    public partial class TbRegister
    {
        public int RnNo { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public int? VehicleYear { get; set; }
        public string VehicleSubModel { get; set; }
        public int? VehicleCc { get; set; }
        public int? CarRegisYear { get; set; }
        public DateTime? PolicyExpiry { get; set; }
        public int? UseDistance { get; set; }
        public bool? IsFci { get; set; }
        public bool? IsConsent { get; set; }
        public DateTime? Created { get; set; }
        public int? CarYear { get; set; }
    }
}
