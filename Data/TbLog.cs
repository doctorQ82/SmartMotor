using System;
using System.Collections.Generic;

#nullable disable

namespace SmartMotor.Data
{
    public partial class TbLog
    {
        public int LogId { get; set; }
        public string PolicyType { get; set; }
        public int? StatusCode { get; set; }
        public string JsonBody { get; set; }
        public DateTime? Created { get; set; }
    }
}
