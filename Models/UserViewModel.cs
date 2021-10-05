using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string LogonName { get; set; }
        public string DisplayName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string GroupAgent { get; set; }
        public bool? IsActive { get; set; }

        [UIHint("ClientRole")]
        public RoleViewModel Role { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
    }

    //public class IsRole
    //{
    //    public int RoleID { get; set; }

    //    public string RoleName { get; set; }

    //}
}
