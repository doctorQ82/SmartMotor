using System;
using System.Collections.Generic;

#nullable disable

namespace SmartMotor.Data
{
    public partial class User
    {
        public int UserId { get; set; }
        public string LogonName { get; set; }
        public string DisplayName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string GroupAgent { get; set; }
        public bool? IsActive { get; set; }
        public int? IsRole { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
